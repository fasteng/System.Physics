using System.Maths;
using System.Physics.Factories;
using System.Physics.Fixtures;
using System.Physics.Materials;
using System.Physics.PhysX.RigidBodies;
using System.Physics.Shapes;
using System.Physics.Shapes.Descriptors;
using StillDesign.PhysX;

namespace System.Physics.PhysX.Fixtures
{
    public partial class SimpleFixture : BaseSimpleFixture, ISeteableRealPose
    {
        private RigidBody _rigidBody;
        private Matrix4x4 _pose;
        private Matrix4x4 _realPose;
        private Matrix4x4 _realParentPose;

        internal SimpleFixture(RigidBody rigidBody, FixtureDescriptor descriptor, Matrix4x4 realParentPose)
        {
            _rigidBody = rigidBody;
            _pose = descriptor.Pose;
            _realParentPose = realParentPose;
            _realPose = GMath.mul(_pose, _realParentPose);
            ShapeFactory = new SimpleFixtureShapeFactory(this);
            MaterialFactory = new SimpleFixtureMaterialFactory(this);
            UserData = descriptor.UserData;
        }

        public override Matrix4x4 Pose
        {
            get { return _pose; }
            set
            {
                _pose = value;
                _realPose = GMath.mul(_pose, _realParentPose);
                UpdateShapePose();
            }
        }

        void ISeteableRealPose.SetRealParentPose(Matrix4x4 value)
        {
            _realParentPose = value;
            _realPose = GMath.mul(_pose, _realParentPose);
            UpdateShapePose();
        }

        private void UpdateShapePose()
        {
            ((ISeteableRealPose) ShapeFactory.Element).SetRealParentPose(_realPose);
        }

        public override ISingleFactory<IMaterial> MaterialFactory { get; protected set; }

        public override ISingleFactory<IShape> ShapeFactory { get; protected set; }

    }
}