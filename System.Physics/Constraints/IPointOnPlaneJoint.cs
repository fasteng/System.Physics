using System.Maths;
using System.Physics.Constraints.DefaultImplementations;
using System.Physics.Constraints.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Constraints
{
    [DefaultImplementationType(typeof(DefaultPointOnPlaneJoint))]
    public interface IPointOnPlaneJoint : IDescriptible<PointOnPlaneJointDescriptor>, ITwoRigidBodiesConstraint, IVisitableLeaf
    {
        Vector3 AnchorPositionALocal { get; }
        Vector3 XAxisALocal { get; }
        Vector3 YAxisALocal { get; }
        Vector3 AnchorPositionBLocal { get; }
        float MaximumDistanceX { get; }
        float MinimumDistanceX { get; }
        float MaximumDistanceY { get; }
        float MinimumDistanceY { get; }
        Vector2 RelativePosition { get; }
    }
}
