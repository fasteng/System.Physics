using System.Maths;
using System.Physics.Factories;
using System.Physics.Fixtures;
using System.Physics.PhysX.RigidBodies;

namespace System.Physics.PhysX.Fixtures
{
    public class CompositeFixture : BaseCompositeFixture, ISeteableRealPose
    {
        private RigidBody _rigidBody;
        private Matrix4x4 _pose;
        private Matrix4x4 _realPose;
        private Matrix4x4 _realParentPose;

        internal CompositeFixture(RigidBody rigidBody, FixtureDescriptor descriptor, Matrix4x4 realParentPose)
        {
            _rigidBody = rigidBody;
            _pose = descriptor.Pose;
            _realParentPose = realParentPose;
            _realPose = GMath.mul(_pose, _realParentPose);
            FixtureFactory = new CompositeFixtureFixtureFactory(this);
            UserData = descriptor.UserData;
        }

        public override Matrix4x4 Pose
        {
            get { return _pose; }
            set
            {
                _pose = value;
                _realPose = GMath.mul(_pose, _realParentPose);
                UpdateChildren();
            }
        }

        void ISeteableRealPose.SetRealParentPose(Matrix4x4 value)
        {
            _realParentPose = value;
            _realPose = GMath.mul(_pose, _realParentPose);
            UpdateChildren();
        }

        private void UpdateChildren()
        {
            foreach (var element in FixtureFactory.Elements)
                ((ISeteableRealPose) element).SetRealParentPose(_realPose);
        }

        public override IMultipleFactory<IFixture> FixtureFactory { get; protected set; }

        internal class CompositeFixtureFixtureFactory : BaseMultipleFactory<IFixture>,
                                                        IFactoryOf<ISimpleFixture, FixtureDescriptor>,
                                                        IFactoryOf<ICompositeFixture, FixtureDescriptor>
        {
            private CompositeFixture _compositeFixture;

            public CompositeFixtureFixtureFactory(CompositeFixture compositeFixture)
            {
                _compositeFixture = compositeFixture;
            }

            ISimpleFixture IFactoryOf<ISimpleFixture, FixtureDescriptor>.Create(FixtureDescriptor descriptor)
            {
                return new SimpleFixture(_compositeFixture._rigidBody, descriptor, _compositeFixture._realPose);
            }

            ICompositeFixture IFactoryOf<ICompositeFixture, FixtureDescriptor>.Create(FixtureDescriptor descriptor)
            {
                return new CompositeFixture(_compositeFixture._rigidBody, descriptor, _compositeFixture._realPose);
            }
        }
    }
}