using System.Collections.Generic;
using System.Maths;
using System.Physics.DigitalRune.RigidBodies;
using System.Physics.DigitalRune;
using System.Physics.Factories;
using System.Physics.Fixtures;
using System.Physics.Shapes;
using DigitalRune.Collections;
using DigitalRune.Geometry;
using DigitalRune.Geometry.Shapes;
using DigitalRune.Physics.Materials;
using IMaterial = System.Physics.Materials.IMaterial;
using DR = DigitalRune.Physics;

namespace System.Physics.DigitalRune.Fixtures
{
    internal partial class 
        SimpleFixture : BaseSimpleFixture
    {
        private DR.RigidBody _wrappedRigidBody;//para el material ctor1

        private List<UniformMaterial> _materialCollection;//para el material ctor2
        private UniformMaterial _material;//para el material ctor2

        private GeometricObject _wrappedGeometricObject;//para la shape
        private Matrix4x4 _pose;
        private Matrix4x4 _realParentPose;
        private bool _root;

        public 
            SimpleFixture(DR.RigidBody wrappedRigidBody, FixtureDescriptor descriptor)
        {
            _wrappedRigidBody = wrappedRigidBody;
            _wrappedGeometricObject = new GeometricObject(new EmptyShape(), descriptor.Pose.ToDigitalRune());
            _wrappedRigidBody.Shape = new TransformedShape(_wrappedGeometricObject);
            _wrappedRigidBody.Material = new UniformMaterial();
            UserData = descriptor.UserData;
            _pose = descriptor.Pose;
            ShapeFactory = new SimpleFixtureShapeFactory(this);
            _root = true;
            MaterialFactory = new SimpleFixtureMaterialFactory(this);
        }

        public SimpleFixture(GeometricObject geometricObject, List<UniformMaterial> materialCollection, UniformMaterial material, FixtureDescriptor descriptor, Matrix4x4 realParentPose)
        {
            _wrappedGeometricObject = geometricObject;
            _materialCollection = materialCollection;
            _material = material;
            UserData = descriptor.UserData;
            ShapeFactory = new SimpleFixtureShapeFactory(this);
            MaterialFactory = new SimpleFixtureMaterialFactory(this);
            _pose = descriptor.Pose;
            _root = false;
            _realParentPose = realParentPose;
        }

        public override ISingleFactory<IMaterial> MaterialFactory { get; protected set; }

        public override  ISingleFactory<IShape> ShapeFactory { get; protected set; }

        public override Matrix4x4 Pose
        {
            get { return _pose; } 
            set
            {
                _pose = value;
                var realPose = _root ? _pose : GMath.mul( _pose,_realParentPose );
                _wrappedGeometricObject.Pose = realPose.ToDigitalRune();
            }
        }

        public void SetRealParentPose(Matrix4x4 value)
        {
            _realParentPose = value;
        }
    }
}
