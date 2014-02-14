using System.Maths;
using System.Physics.Factories;
using System.Physics.Materials;
using System.Physics.Shapes;

namespace System.Physics.Fixtures
{
    public struct FixtureDescriptor : IDescriptor
    {
        public Matrix4x4 Pose { get; set; }
         
        public FixtureDescriptor(Matrix4x4 pose, object userData = null): this()
        {
            Pose = pose;
            UserData = userData;
        }

        public void ToDefault()
        {
            UserData = null;
            Pose = Matrices.I;
        }

        public object UserData { get; set; }
    }
}
