using System.Maths;

namespace System.Physics.PhysX.Fixtures
{
    internal interface ISeteableRealPose
    {
        void SetRealParentPose(Matrix4x4 value);
    }
}