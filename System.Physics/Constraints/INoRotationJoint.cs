using System.Maths;
using System.Physics.Constraints.DefaultImplementations;
using System.Physics.Constraints.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Constraints
{
    [DefaultImplementationType(typeof(DefaultNoRotationJoint))]
    public interface INoRotationJoint : IDescriptible<NoRotationJointDescriptor>, ITwoRigidBodiesConstraint, IVisitableLeaf
    {
        Matrix3x3 AnchorOrientationALocal { get; }
        Matrix3x3 AnchorOrientationBLocal { get; }
    }
}
