using System.Maths;
using System.Physics.Constraints.DefaultImplementations;
using System.Physics.Constraints.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Constraints
{
    [DefaultImplementationType(typeof(DefaultPointOnLineJoint))]
    public interface IPointOnLineJoint : IDescriptible<PointOnLineJointDescriptor>, ITwoRigidBodiesConstraint, IVisitableLeaf
    {
        Vector3 AnchorPositionALocal { get; }
        Vector3 AxisALocal { get; }
        Vector3 AnchorPositionBLocal { get; }
        float MaximumDistance { get; }
        float MinimumDistance { get; }
        float Distance { get; }
    }
}
