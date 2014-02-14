using System.Maths;
using System.Physics.Constraints.DefaultImplementations;
using System.Physics.Constraints.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Constraints
{
    [DefaultImplementationType(typeof(DefaultDistanceRangeJoint))]
    public interface IDistanceRangeJoint : IDescriptible<DistanceRangeJointDescriptor>, ITwoRigidBodiesConstraint, IVisitableLeaf
    {
        Vector3 AnchorPositionALocal { get; }
        Vector3 AnchorPositionBLocal { get; }
        float MinimumDistance { get; }
        float MaximumDistance { get; }
    } 
}
