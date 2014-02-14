using System.Maths;
using System.Physics.Constraints.DefaultImplementations;
using System.Physics.Constraints.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Constraints
{
    [DefaultImplementationType(typeof(DefaultCylindricalJoint))]
    public interface ICylindricalJoint : IDescriptible<CylindricalJointDescriptor>, ITwoRigidBodiesConstraint, IVisitableLeaf
    {
        Matrix4x4 AnchorPoseALocal { get;}
        Matrix4x4 AnchorPoseBLocal { get;}
        float MaximumAngle { get; }
        float MinimumAngle { get; }
        float MaximumDistance { get; }
        float MinimumDistance { get; }
    }
}
