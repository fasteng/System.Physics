using System.Maths;
using System.Physics.PhysX.Fixtures;
using System.Physics.PhysX.RigidBodies;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;
using StillDesign.PhysX;
using Material = System.Physics.PhysX.Materials.Material;

namespace System.Physics.PhysX.Shapes
{
    internal class PlaneShape : BasePlaneShape, ISeteableRealPose
    {
        private StillDesign.PhysX.PlaneShape _wrappedPlaneShape;
        Vector3 _normal;
        float _distanceFromOrigin;
        Matrix4x4 _pose;

        public PlaneShape(RigidBody rigidBody, Matrix4x4 realParentPose, Material material, PlaneShapeDescriptor descriptor)
        {
            var planeShapeDescription = new PlaneShapeDescription(descriptor.Normal.ToPhysX(), descriptor.DistanceFromOrigin) { Material = material._wrappedMaterial };
            _wrappedPlaneShape =
                (StillDesign.PhysX.PlaneShape)
                rigidBody.WrappedActor.CreateShape(planeShapeDescription);
            _normal = descriptor.Normal;
            _distanceFromOrigin = descriptor.DistanceFromOrigin;
            _pose = realParentPose;

            SetRealParentPose(realParentPose);


            UserData = descriptor.UserData;
            if (rigidBody.HasDefaultShape)
            {
                rigidBody.WrappedActor.Shapes[0].Dispose();
                rigidBody.HasDefaultShape = false;
            }
        }

        public override Maths.Vector3 Normal
        {
            get { return _normal; }
            set
            {
                _normal = value;
                UpdatePlane();
            }
        }

        private void UpdatePlane()
        {
            Vector3 p = DistanceFromOrigin * _normal;
            Vector4 pWith1 = new Vector4(p.X, p.Y, p.Z, 1);
            Vector4 pPrimeWiht1 = GMath.mul(pWith1, _pose);
            Vector3 pPrime = new Vector3(pPrimeWiht1.X, pPrimeWiht1.Y, pPrimeWiht1.Z);

            Vector4 nWith0 = new Vector4(_normal.X, _normal.Y, _normal.Z, 0);
            Vector4 nPrimeWith0 = GMath.mul(nWith0, _pose.Transpose.Inverse);
            Vector3 nPrime = new Vector3(nPrimeWith0.X, nPrimeWith0.Y, nPrimeWith0.Z);

            float d = GMath.dot(pPrime, nPrime);
            _wrappedPlaneShape.Normal = nPrime.ToPhysX();

            _wrappedPlaneShape.Distance = d;
        }

        public override float DistanceFromOrigin
        {
            get { return _distanceFromOrigin; }
            set
            {
                _distanceFromOrigin = value;
                UpdatePlane();
            }
        }

        public void SetRealParentPose(Matrix4x4 value)
        {
            _pose = value;
            UpdatePlane();
        }
    }
}