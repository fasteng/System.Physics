using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Physics;
using System.Physics.Factories;
using System.Physics.RigidBodies;
using System.Physics.Constraints;
using System.Physics.Constraints.Descriptors;
using System.Physics.DigitalRune.Simulators;
using System.Physics.Fixtures;
using System.Physics.Materials;
using System.Physics.RigidBodies;
using System.Physics.Shapes;
using System.Physics.Shapes.DefaultImplementations;
using System.Physics.Shapes.Descriptors;
using System.Physics.Simulators;
using System.Rendering.Effects;
using System.Rendering.Forms;
using System.Windows.Forms;
using System.Rendering;
using System.Maths;
using Vector3 = System.Maths.Vector3;

namespace Tutorials.MyFirstScene
{
    public partial class Form1 : Form 
    {
        private ISimulator _simulator;
        private int _startTickCount;
        private int _framesCount;
        private int _previousTickCount;
        readonly Dictionary<IShape,IModel> _allocatedModels = new Dictionary<IShape, IModel>();
        private IControlRenderDevice _render;
        private List<IRigidBody> _forceBodies;

        public Form1()
        {
            InitializeComponent();
            renderedControl1.Render = new System.Rendering.Direct3D9.Direct3DRender();
        }

        private void renderedControl1_InitializeRender(object sender, RenderEventArgs e)
        {
            _render = e.Render;

            #region Creating the physics scene

            //creating the simulation
            _simulator = new DigitalRuneSimulator();

            //definig a material
            var materialDescriptor = new MaterialDescriptor(0.5f, 0.7f);

            //creating the ground
            CreateGroud(materialDescriptor);

            //creating a Tower
            for (int i = 0; i < 3; i++)
            {
                CreateTower<IBoxShape, BoxShapeDescriptor>(materialDescriptor, new BoxShapeDescriptor(1, 3, 1),
                                                           xCount: 1, yCount: 3, zCount: 1,
                                                           xSpace: 1, ySpace: 3, zSpace: 1,
                                                           xOffset: 3 * i, yOffset:10+ 9 / 2f, zOffset: 0);
            }


            ////creating a chain
            //var constraintDescriptor = new DistanceRangeJointDescriptor(new Vector3(0),new Vector3(0),1f,1.1f,false);
            //CreateChain<ISphereShape, SphereShapeDescriptor>(materialDescriptor, new SphereShapeDescriptor(0.5f), constraintDescriptor,
            //                                                 count: 8, space: 1.1f, staticBall: 7,
            //                                                 xOffset:-10, yOffset: 9,zOffset: 0);

            //creating a composite
            CreateComposite();

            //playing with the mass
            // CreateMassTesting(-5,1, 1);
            //CreateMassTesting(0,1, 10);
            //CreateMassTesting(5,2, 100000);

            #endregion

            //initializing the timer
            _previousTickCount = Environment.TickCount;
            _startTickCount = _previousTickCount;
        }

        private void CreateComposite()
        {
            var compositeRigidBodyDescriptor = new RigidBodyDescriptor(MotionType.Dynamic, Matrices.Translate(0f, 10, 0), true);
            IRigidBody composite = _simulator.ActorsFactory.CreateRigidBody(compositeRigidBodyDescriptor);
            var sphereFixture =
                composite.FixtureFactory.CreateSimpleFixture(new FixtureDescriptor(Matrices.I));
            sphereFixture.MaterialFactory.CreateMaterial(new MaterialDescriptor(0.01f, 1.01f));
            var compositeShape =
                sphereFixture.ShapeFactory.CreateComposite(new CompositeShapeDescriptor());
            var shapePositionerCenter =
                compositeShape.ShapePositionerFactory.CreateShapePositioner(
                    new ShapePositionerDescriptor(Matrices.I));
            shapePositionerCenter.ShapeFactory.CreateSphere(new SphereShapeDescriptor(1.5f));
            var shapePositionerLeft =
                compositeShape.ShapePositionerFactory.CreateShapePositioner(
                    new ShapePositionerDescriptor(Matrices.Translate(-2.5f, 0, 0)));
            shapePositionerLeft.ShapeFactory.CreateSphere(new SphereShapeDescriptor(0.5f));
            var shapePositionerRight =
                compositeShape.ShapePositionerFactory.CreateShapePositioner(
                    new ShapePositionerDescriptor(Matrices.Translate(2.5f, 0, 0)));
            shapePositionerRight.ShapeFactory.CreateSphere(new SphereShapeDescriptor(0.5f));
        }

        private void CreateMassTesting(float xPosition,float side, float mass)
        {
            var rigidBodyDescriptor = new RigidBodyDescriptor(MotionType.Dynamic, Matrices.Translate(xPosition, 10, 0),true);
            IRigidBody rigidBody = _simulator.ActorsFactory.Create<IRigidBody, RigidBodyDescriptor>(rigidBodyDescriptor);
            var fixture = rigidBody.FixtureFactory.Create<ISimpleFixture, FixtureDescriptor>(new FixtureDescriptor(Matrices.I));
            fixture.MaterialFactory.Create<IMaterial, MaterialDescriptor>(new MaterialDescriptor(0.01f, 1.01f));
            fixture.ShapeFactory.Create<IBoxShape, BoxShapeDescriptor>(new BoxShapeDescriptor(side, side, side));
            rigidBody.MassFrame.Mass = mass;
        }

        private void CreateChain<TShape, TShapeDescriptor>(MaterialDescriptor materialDescriptor,
                                                           TShapeDescriptor shapeDescriptor, 
                                                           DistanceRangeJointDescriptor constraintDescriptor, 
                                                           int count, float space, int staticBall, float xOffset, float yOffset, float zOffset)
        where TShapeDescriptor : struct, IDescriptor
        where TShape : IShape, IDescriptible<TShapeDescriptor>
        {
            var bodies = new IRigidBody[count];
            var rigidBodyDescriptor = new RigidBodyDescriptor(MotionType.Static, Matrices.I, true);
            for (int i = 0; i < count; i++)
            {
                
                rigidBodyDescriptor.Pose = Matrices.Translate(xOffset + (space + i * space - ((count - 1) * space / 2)), yOffset, zOffset);
                bodies[i] = _simulator.ActorsFactory.Create<IRigidBody, RigidBodyDescriptor>(rigidBodyDescriptor);
                bodies[i].UserData = String.Format("chain {0}", i);
                var fixture = bodies[i].FixtureFactory.Create<ISimpleFixture, FixtureDescriptor>(new FixtureDescriptor(Matrices.I));
                fixture.ShapeFactory.Create<TShape, TShapeDescriptor>(shapeDescriptor);
                fixture.MaterialFactory.Create<IMaterial, MaterialDescriptor>(materialDescriptor);
                if (i > 0)
                {
                    constraintDescriptor.RigidBodyA = bodies[i - 1];
                    constraintDescriptor.RigidBodyB = bodies[i];
                    _simulator.ConstraintsFactory.Create<IDistanceRangeJoint, DistanceRangeJointDescriptor>(
                        constraintDescriptor);
                }
                else
                    rigidBodyDescriptor.MotionType = MotionType.Static;
            }
        }

        private void CreateTower<TShape, TShapeDescriptor>(MaterialDescriptor materialDescriptor, TShapeDescriptor descriptor, int xCount, int yCount, int zCount, float xSpace, float ySpace, float zSpace, float xOffset, float yOffset, float zOffset)
        where TShapeDescriptor : struct, IDescriptor
        where TShape : IShape, IDescriptible<TShapeDescriptor>
        {
            var rigidBodyDescriptor = new RigidBodyDescriptor(MotionType.Dynamic, Matrices.I, true);
            for (int x = 0; x < xCount; x++)
                for (int y = 0; y < yCount; y++)
                    for (int z = 0; z < zCount; z++)
                    {
                        rigidBodyDescriptor.Pose = Matrices.Translate(xOffset + x*xSpace - ((xCount - 1)*xSpace/2),
                                                                 yOffset + y*ySpace - ((yCount - 1)*ySpace/2),
                                                                 zOffset + z*zSpace - ((zCount - 1)*zSpace/2));
                        var rigidBody = _simulator.ActorsFactory.Create<IRigidBody, RigidBodyDescriptor>(rigidBodyDescriptor);
                        var fixture =
                            rigidBody.FixtureFactory.Create<ISimpleFixture, FixtureDescriptor>(new FixtureDescriptor(Matrices.I));
                        fixture.ShapeFactory.Create<TShape, TShapeDescriptor>(descriptor);
                        fixture.MaterialFactory.Create<IMaterial, MaterialDescriptor>(materialDescriptor);
                    }
        }

        private void CreateGroud(MaterialDescriptor materialDescriptor)
        {
            var groundRigidBodyDescriptor = new RigidBodyDescriptor(MotionType.Static, Matrices.I, true);
            var ground = _simulator.ActorsFactory.CreateRigidBody(groundRigidBodyDescriptor);
            var groundFixture = ground.FixtureFactory.CreateSimpleFixture(new FixtureDescriptor(Matrices.I));
            groundFixture.ShapeFactory.CreatePlane(new PlaneShapeDescriptor(new Vector3(0, 1, 0),                                                                                           0));
            groundFixture.MaterialFactory.CreateMaterial(materialDescriptor);
        }

        private void renderedControl1_Rendered(object sender, RenderEventArgs e)
        {
            //update simulation
            
            int tickCount = Environment.TickCount;
            float deltaTime = (tickCount - _previousTickCount) / 1000f;
            _previousTickCount = tickCount;
            
            _simulator.Update(deltaTime);
            _framesCount++;
            int secondsCount = (tickCount - _startTickCount)/1000;
            if(secondsCount != 0)
                label.Text = String.Format("FPS: {0}", _framesCount / secondsCount);
            //add forces
            //foreach (IRigidBody forceRigidBody in _forceBodies)
            //{
            //    forceRigidBody.Forces.AddForce(1000 * Vectors.ZAxis);
            //}
            

            //draw scene 
            var render = e.Render;
            render.BeginScene();

            render.Draw(() =>
                {
                    foreach (IRigidBody rigidBody in _simulator.ActorsFactory.Elements)
                    {
                        if (rigidBody.FixtureFactory.Element is ISimpleFixture)
                        {
                            var simpleFixture = (ISimpleFixture)rigidBody.FixtureFactory.Element;
                            DrawSimpleFixture(simpleFixture, render, rigidBody);
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }
                },
                Lights.Point(new Vector3(0, 5, -6), new Vector3(1, 1, 1)),
                Cameras.LookAt(new Vector3(0, 15, -30), new Vector3(0, 0, 0), new Vector3(0, 1, 0)),
                Cameras.Perspective(render.GetAspectRatio()),
                Buffers.Clear(0.2f, 0.2f, 0.4f, 1),
                Buffers.ClearDepth(),
                               Shaders.Phong
                );

            render.EndScene();

            renderedControl1.Invalidate();
        }

        //todo: por ahora esta asumiendo q la shape esta en el origen del rigidBody sin transformaciones
        private void DrawSimpleFixture(ISimpleFixture simpleFixture, IControlRenderDevice render, IRigidBody rigidBody)
        {
            IShape shape = simpleFixture.ShapeFactory.Element;
            IModel model = ExtractModel(shape);
            render.Draw(model, new Transforming(rigidBody.Descriptor.Pose),
            Materials.DeepPink.Glossy.Shinness.Glossy.Shinness);
        }

        private IModel ExtractModel(IShape shape)
        {
            IModel model;
            if (_allocatedModels.TryGetValue(shape, out model)) 
                return model;

            if(shape is ISphereShape)
            {
                var sphere = (ISphereShape)shape;
                return _allocatedModels[shape] = Models.Sphere.Scaled(sphere.Descriptor.Radius,
                                                                      sphere.Descriptor.Radius,
                                                                      sphere.Descriptor.Radius);
            }

            if (shape is IRectangleShape)
            {
                var rectangle = (IRectangleShape)shape;
                return _allocatedModels[shape] = Models.Cube.Translated(-0.5f, -0.5f, -0.5f).Scaled(rectangle.Descriptor.WidthX,
                                                                                                    rectangle.Descriptor.WidthY,
                                                                                                    0.01f);
            }
            if (shape is IBoxShape)
            {
                var box = (IBoxShape)shape;
                return _allocatedModels[shape] = Models.Cube.Translated(-0.5f, -0.5f, -0.5f).Scaled(box.Descriptor.WidthX,
                                                                                                    box.Descriptor.WidthY,
                                                                                                    box.Descriptor.WidthZ);
            }
            if (shape is ICylinderShape)
            {
                var cylinder = (ICylinderShape)shape;
                return _allocatedModels[shape] = Models.Cylinder.Translated(0,-.5f,0).Scaled(cylinder.Descriptor.Radius,
                                                                                             cylinder.Descriptor.Height, 
                                                                                             cylinder.Descriptor.Radius);
            }
            if (shape is ICapsuleShape)
            {
                var capsule = (ICapsuleShape)shape;
                IModel cylinder = Models.Cylinder.Translated(0, -.5f, 0).Scaled(capsule.Descriptor.Radius,
                                                                             capsule.Descriptor.Height - (capsule.Descriptor.Radius*2),
                                                                             capsule.Descriptor.Radius);
                IModel sphere = Models.Sphere.Scaled(capsule.Descriptor.Radius,
                                                     capsule.Descriptor.Radius,
                                                     capsule.Descriptor.Radius);
                float sphereZ = capsule.Descriptor.Height/2 - capsule.Descriptor.Radius;
                IModel topSphere = sphere.Translated(0, sphereZ, 0);
                IModel bottomSphere = sphere.Translated(0, -sphereZ, 0);
                return _allocatedModels[shape] = Models.Group(cylinder,topSphere,bottomSphere).Allocate(_render);
            }
            if (shape is ICompositeShape)
            {
                IModel centerSphere = Models.Sphere.Scaled(1.5f,1.5f,1.5f);
                IModel leftSphere = Models.Sphere.Scaled(0.5f, 0.5f, 0.5f).Translated(-2.5f, 0, 0);
                IModel rightSphere = Models.Sphere.Scaled(0.5f, 0.5f, 0.5f).Translated(2.5f, 0, 0);
                return _allocatedModels[shape] = Models.Group(centerSphere, leftSphere, rightSphere).Allocate(_render);
            }
            if (shape is IPlaneShape)
            {
                return _allocatedModels[shape] = Models.PlaneXZ.Scaled(1, 1, 1);//todo arreglar para q coja bien el plano
            }
            if (shape is ICircleShape)
            {
                var circle = (ICircleShape) shape;
                return _allocatedModels[shape] = Models.Cylinder.Scaled(circle.Descriptor.Radius,
                                                                        0.01f,
                                                                        circle.Descriptor.Radius);
            }
            throw new NotImplementedException();
        }

    }
}
