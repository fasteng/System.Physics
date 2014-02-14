using System.Maths;
using System.Physics.Constraints.DefaultImplementations;
using System.Physics.Constraints.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Constraints
{
    [DefaultImplementationType(typeof(DefaultFixedJoint))]
    public interface IFixedJoint : IDescriptible<FixedJointDescriptor>, ITwoRigidBodiesConstraint, IVisitableLeaf
    {
        Matrix4x4 AnchorPoseALocal { get; }
        Matrix4x4 AnchorPoseBLocal { get; }
    }
}
