using System;
using System.Collections.Generic;
using System.Linq;
using System.Maths;
using System.Physics;
using System.Physics.Fixtures;
using System.Physics.RigidBodies;
using System.Physics.Shapes;
using System.Physics.Visitor;
using System.Rendering;
using System.Rendering.Effects;
using System.Rendering.Forms;
using System.Rendering.Modeling;
using System.Text;

namespace Tutorials.MyFirstScene
{
    class RenderingVisitor : BaseVisitor,

        ITreeStartVisitorOf<IRigidBody>,
        ITreeEndVisitorOf<IRigidBody>,
        ITreeStartVisitorOf<ISimpleFixture>,
        ITreeEndVisitorOf<ISimpleFixture>,
        ITreeStartVisitorOf<ICompositeFixture>,
        ITreeEndVisitorOf<ICompositeFixture>,
        ITreeStartVisitorOf<ICompositeShape>,
        ITreeEndVisitorOf<ICompositeShape>,
        ITreeStartVisitorOf<IShapePositioner>,
        ITreeEndVisitorOf<IShapePositioner>,   

        ILeafVisitorOf<ISphereShape>,
        ILeafVisitorOf<IBoxShape>,
        ILeafVisitorOf<ICylinderShape>,
        ILeafVisitorOf<ICapsuleShape>,
        ILeafVisitorOf<IPlaneShape>,
        ILeafVisitorOf<ICircleShape>,
        ILeafVisitorOf<IRectangleShape>
    {
        private readonly IControlRenderDevice _render;
        private Stack<Matrix4x4> _posesStack = new Stack<Matrix4x4>();
        private Stack<Material> _materialsStack = new Stack<Material>();
        readonly Dictionary<IShape, IModel> _allocatedModels = new Dictionary<IShape, IModel>();

        public RenderingVisitor(IControlRenderDevice render)
        {
            _render = render;
            _materialsStack.Push(Materials.GreenYellow.Glossy.Shinness.Glossy.Shinness);
        }

        #region helper methods

        private void TryPushMaterial(IUserDataStorer rigidBody)
        {
            var material = rigidBody.UserData as Material;
            if (material != null) _materialsStack.Push(material);
        }

        private void TryPopMaterial(IUserDataStorer rigidBody)
        {
            var material = rigidBody.UserData as Material;
            if (material != null) _materialsStack.Pop();
        }

        private void DrawShape(IShape shape, IModel model)
        {
            TryPushMaterial(shape);
            DrawModel(model);
            TryPopMaterial(shape);
        }

        private void DrawModel(IModel model)
        {
            _render.Draw(model, new Transforming(_posesStack.Peek()), _materialsStack.Peek());
        }

        private void PushPose(Matrix4x4 pose)
        {
            Matrix4x4 actualPose = _posesStack.Count == 0? 
                                    pose:
                                    GMath.mul(pose, _posesStack.Peek());
            _posesStack.Push(actualPose);
        }

        #endregion

        #region tree visits
        void ITreeStartVisitorOf<IRigidBody>.StartVisit(IRigidBody rigidBody)
        {
            PushPose(rigidBody.Pose);
            TryPushMaterial(rigidBody);
        }

        void ITreeEndVisitorOf<IRigidBody>.EndVisit(IRigidBody rigidBody)
        {
            _posesStack.Pop();
            TryPopMaterial(rigidBody);
        }

        void ITreeStartVisitorOf<ISimpleFixture>.StartVisit(ISimpleFixture simpleFixture)
        {
            PushPose(simpleFixture.Pose);
            TryPushMaterial(simpleFixture);
        }

        void ITreeEndVisitorOf<ISimpleFixture>.EndVisit(ISimpleFixture simpleFixture)
        {
            _posesStack.Pop();
            TryPopMaterial(simpleFixture);
        }

        void ITreeStartVisitorOf<ICompositeFixture>.StartVisit(ICompositeFixture compositeFixture)
        {
            PushPose(compositeFixture.Pose);
            TryPushMaterial(compositeFixture);
        }

        void ITreeEndVisitorOf<ICompositeFixture>.EndVisit(ICompositeFixture compositeFixture)
        {
            _posesStack.Pop();
            TryPopMaterial(compositeFixture);
        }

        void ITreeStartVisitorOf<ICompositeShape>.StartVisit(ICompositeShape compositeShape)
        {
            TryPushMaterial(compositeShape);
        }

        void ITreeEndVisitorOf<ICompositeShape>.EndVisit(ICompositeShape compositeShape)
        {
            TryPopMaterial(compositeShape);
        }

        void ITreeStartVisitorOf<IShapePositioner>.StartVisit(IShapePositioner shapePositioner)
        {
            PushPose(shapePositioner.Pose);
            TryPushMaterial(shapePositioner);
        }

        void ITreeEndVisitorOf<IShapePositioner>.EndVisit(IShapePositioner shapePositioner)
        {
            _posesStack.Pop();
            TryPopMaterial(shapePositioner);
        }
        #endregion

        #region leaf visits
        void ILeafVisitorOf<ISphereShape>.Visit(ISphereShape sphereShape)
        {
            IModel model;
            if (!_allocatedModels.TryGetValue(sphereShape, out model)) 
                model = _allocatedModels[sphereShape] = Models.Sphere.Scaled(sphereShape.Radius, sphereShape.Radius, sphereShape.Radius);
            DrawShape(sphereShape, model);
        }

        void ILeafVisitorOf<IBoxShape>.Visit(IBoxShape boxShape)
        {
            IModel model;
            if (!_allocatedModels.TryGetValue(boxShape, out model)) 
                model = _allocatedModels[boxShape] =  Models.Cube.Translated(-0.5f, -0.5f, -0.5f).Scaled(boxShape.Descriptor.WidthX,
                                                                                                 boxShape.Descriptor.WidthY,
                                                                                                 boxShape.Descriptor.WidthZ);
            DrawShape(boxShape, model);
        }

        void ILeafVisitorOf<ICylinderShape>.Visit(ICylinderShape cylinderShape)
        {
            IModel model;
            if (!_allocatedModels.TryGetValue(cylinderShape, out model)) 
                model = _allocatedModels[cylinderShape] =  Models.Cylinder.Translated(0,-.5f,0).Scaled(cylinderShape.Descriptor.Radius,
                                                                                               cylinderShape.Descriptor.Height, 
                                                                                               cylinderShape.Descriptor.Radius);
            DrawShape(cylinderShape, model);
        }

        void ILeafVisitorOf<ICapsuleShape>.Visit(ICapsuleShape capsuleShape)
        {
            IModel model;
            if (!_allocatedModels.TryGetValue(capsuleShape, out model))
            {
                IModel cylinder = Models.Cylinder.Translated(0, -.5f, 0).Scaled(capsuleShape.Descriptor.Radius,
                                                                                capsuleShape.Descriptor.Height - (capsuleShape.Descriptor.Radius*2),
                                                                                capsuleShape.Descriptor.Radius);
                IModel sphere = Models.Sphere.Scaled(capsuleShape.Descriptor.Radius,
                                                     capsuleShape.Descriptor.Radius,
                                                     capsuleShape.Descriptor.Radius);
                float zOffset = capsuleShape.Descriptor.Height/2 - capsuleShape.Descriptor.Radius;
                IModel topSphere = sphere.Translated(0, zOffset, 0);
                IModel bottomSphere = sphere.Translated(0, -zOffset, 0);
                model = _allocatedModels[capsuleShape] = Models.Group(cylinder,topSphere,bottomSphere).Allocate(_render);
            }
            DrawShape(capsuleShape, model);
        }

        void ILeafVisitorOf<IPlaneShape>.Visit(IPlaneShape planeShape)
        {
            IModel model;
            if (!_allocatedModels.TryGetValue(planeShape, out model))
                model = _allocatedModels[planeShape] = Models.PlaneXZ.Scaled(10, 1, 6);

            Matrix4x4 rotationZ = Matrices.RotateZ((float)Math.Atan2(planeShape.Normal.X, planeShape.Normal.Y));
            Matrix4x4 rotationX = Matrices.RotateX(-(float)Math.Atan2(planeShape.Normal.Z, planeShape.Normal.Y));
            Matrix4x4 finalRotation = GMath.mul(rotationZ,rotationX);
            Matrix4x4 translation = Matrices.Translate(planeShape.DistanceFromOrigin * planeShape.Normal);
            Matrix4x4 finalTransformation = GMath.mul(finalRotation, translation);
            
            PushPose(finalTransformation);

            DrawShape(planeShape, model);

            _posesStack.Pop();
        }

        void ILeafVisitorOf<ICircleShape>.Visit(ICircleShape circleShape)
        {
            IModel model;
            if (!_allocatedModels.TryGetValue(circleShape, out model))
                model = _allocatedModels[circleShape] = Models.Cylinder.Scaled(circleShape.Descriptor.Radius,
                                                                        0.1f,
                                                                        circleShape.Descriptor.Radius).Rotated(GMath.Pi/2,Vectors.XAxis);

            DrawShape(circleShape, model);
        }

        void ILeafVisitorOf<IRectangleShape>.Visit(IRectangleShape rectangleShape)
        {

            IModel model;
            if (!_allocatedModels.TryGetValue(rectangleShape, out model))
                model = _allocatedModels[rectangleShape] = Models.Cube.Translated(-0.5f, -0.5f, -0.5f).Scaled(rectangleShape.Descriptor.WidthX,
                                                               rectangleShape.Descriptor.WidthY,
                                                               0.1f);
            DrawShape(rectangleShape, model);
        }
        #endregion
    }
}
