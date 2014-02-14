using System.Maths;
using System.Physics.Constraints.DefaultImplementations;
using System.Physics.Constraints.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Constraints
{
    [DefaultImplementationType(typeof(DefaultPrismaticJoint))]
    public interface IPrismaticJoint : IDescriptible<PrismaticJointDescriptor>, ITwoRigidBodiesConstraint, IVisitableLeaf
    {
        Matrix4x4 AnchorPoseALocal { get; }
        Matrix4x4 AnchorPoseBLocal { get; }
        float MaximumDistance { get; }
        float MinimumDistance { get; }
    }
}
