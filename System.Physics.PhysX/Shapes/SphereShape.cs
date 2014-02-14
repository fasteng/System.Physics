using System.Maths;
using System.Physics.Materials;
using System.Physics.PhysX.Fixtures;
using System.Physics.PhysX.RigidBodies;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;
using StillDesign.PhysX;
using Material = System.Physics.PhysX.Materials.Material;

namespace System.Physics.PhysX.Shapes
{
    internal class SphereShape : BaseSphereShape, ISeteableRealPose
    {
        private StillDesign.PhysX.SphereShape _wrappedSphereShape;

        public SphereShape(RigidBody rigidBody, Matrix4x4 realParentPose, Material material, SphereShapeDescriptor descriptor)
        {
            var sphereShapeDescription = new SphereShapeDescription(descriptor.Radius)
                                             {Material = material._wrappedMaterial};
            _wrappedSphereShape =
                (StillDesign.PhysX.SphereShape)rigidBody.WrappedActor.CreateShape(sphereShapeDescription);
            SetRealParentPose(realParentPose);
            UserData = descriptor.UserData;
            if (rigidBody.HasDefaultShape)
            {
                rigidBody.WrappedActor.Shapes[0].Dispose();
                rigidBody.HasDefaultShape = false;
            }
        }

        public override float Radius
        {
            get { return _wrappedSphereShape.Radius; }
            set { _wrappedSphereShape.Radius = value; }
        }

        public void SetRealParentPose(Matrix4x4 value)
        {
            _wrappedSphereShape.LocalPose = value.ToPhysX();
        }
    }
}