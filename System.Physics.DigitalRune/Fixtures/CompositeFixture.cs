using System.Maths;
using System.Physics.Factories;
using System.Physics.Fixtures;
using DigitalRune.Geometry;
using DigitalRune.Geometry.Shapes;
using DigitalRune.Physics.Materials;
using DR = DigitalRune.Physics;


namespace System.Physics.DigitalRune.Fixtures
{
    public partial class CompositeFixture : BaseCompositeFixture
    {
        private bool _root;
        
        private Matrix4x4 _realPose;
        private CompositeShape _wrappedCompositeShape; //para la creacion de Fixtures
        private CompositeMaterial _wrappedCompositeMaterial;//para los materiales de las Fixtures
        private Matrix4x4 _pose;

        public CompositeFixture(DR.RigidBody wrappedRigidBody, FixtureDescriptor descriptor)
        {
            _root = true;
            _pose = descriptor.Pose;
            _realPose = _pose;
            _wrappedCompositeMaterial = new CompositeMaterial();
            wrappedRigidBody.Material = _wrappedCompositeMaterial;
            _wrappedCompositeShape = new CompositeShape();
            wrappedRigidBody.Shape = _wrappedCompositeShape;
            UserData = descriptor.UserData;
            FixtureFactory = new CompositeFixtureFixtureFactory(this);
        }

        private CompositeFixture(CompositeShape wrappedCompositeShape, CompositeMaterial wrappedCompositeMaterial, Matrix4x4 realParentPose, FixtureDescriptor descriptor)
        {
            _root = false;
            _realParentPose = realParentPose;
            _pose = descriptor.Pose;
            _realPose = GMath.mul( _pose ,_realParentPose);
            UserData = descriptor.UserData;
            _wrappedCompositeMaterial = wrappedCompositeMaterial;
            _wrappedCompositeShape = wrappedCompositeShape;
            FixtureFactory = new CompositeFixtureFixtureFactory(this);
        }

        private Matrix4x4 _realParentPose;

        //this method is designed to be called  
        //by the parent when its _realPose is changed
        internal void SetRealParentPose(Matrix4x4 value) 
        {
            _realParentPose = value;
            _realPose = GMath.mul( _pose ,_realParentPose);
            foreach (var simpleFixture in FixtureFactory.GetElements<ISimpleFixture>())
                ((SimpleFixture)simpleFixture).SetRealParentPose(_realPose);
            foreach (var compositeFixture in FixtureFactory.GetElements<ICompositeFixture>())
                ((CompositeFixture)compositeFixture).SetRealParentPose(_realPose);
        } 

        public override Matrix4x4 Pose
        {
            get { return _pose; }
            set
            {
                _pose = value;
                _realPose = _root? _pose : GMath.mul(_pose, _realParentPose );
                foreach (var simpleFixture in FixtureFactory.GetElements<ISimpleFixture>())
                    ((SimpleFixture) simpleFixture).SetRealParentPose(_realPose);
                foreach (var compositeFixture in FixtureFactory.GetElements<ICompositeFixture>())
                    ((CompositeFixture)compositeFixture).SetRealParentPose(_realPose);
            }
        }

        public override IMultipleFactory<IFixture> FixtureFactory { get; protected set; }
    }
}