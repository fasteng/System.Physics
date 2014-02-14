using System.Maths;
using System.Physics.Constraints.DefaultImplementations;
using System.Physics.Constraints.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Constraints
{
    [DefaultImplementationType(typeof(DefaultSphericalJoint))]
    public interface ISphericalJoint : IDescriptible<SphericalJointDescriptor>, ITwoRigidBodiesConstraint, IVisitableLeaf
    {
        Vector3 AnchorPositionALocal { get;  }
        Vector3 AnchorPositionBLocal { get;  }
    }
}
