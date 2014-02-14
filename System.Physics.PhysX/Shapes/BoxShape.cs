using System.Maths;
using System.Physics.PhysX.Fixtures;
using System.Physics.PhysX.RigidBodies;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;
using StillDesign.PhysX;
using Material = System.Physics.PhysX.Materials.Material;

namespace System.Physics.PhysX.Shapes
{
    internal class BoxShape : BaseBoxShape, ISeteableRealPose
    {
        private StillDesign.PhysX.BoxShape _wrappedBoxShape;

        public BoxShape(RigidBody rigidBody, Matrix4x4 realParentPose, Material material, BoxShapeDescriptor descriptor)
        {
            var boxShapeDescription = new BoxShapeDescription(descriptor.WidthX, descriptor.WidthY, descriptor.WidthZ)
                                          {
                                              Material = material._wrappedMaterial
                                          };

            _wrappedBoxShape =
                (StillDesign.PhysX.BoxShape)
                rigidBody.WrappedActor.CreateShape(boxShapeDescription);
            SetRealParentPose(realParentPose);
            UserData = descriptor.UserData;
            if (rigidBody.HasDefaultShape)
            {
                rigidBody.WrappedActor.Shapes[0].Dispose();
                rigidBody.HasDefaultShape = false;
            }
        }

        public override float WidthX
        {
            get { return _wrappedBoxShape.Size.X; }
            set { _wrappedBoxShape.Size = new Maths.Vector3(value, WidthY, WidthZ).ToPhysX(); }
        }

        public override float WidthY
        {
            get { return _wrappedBoxShape.Size.Y; }
            set { _wrappedBoxShape.Size = new Maths.Vector3(WidthX, value, WidthZ).ToPhysX(); }
        }

        public override float WidthZ
        {
            get { return _wrappedBoxShape.Size.Z; }
            set { _wrappedBoxShape.Size = new Maths.Vector3(WidthX, WidthY, value).ToPhysX(); }
        }

        public void SetRealParentPose(Matrix4x4 value)
        {
            _wrappedBoxShape.LocalPose = value.ToPhysX();
        }
    }
}