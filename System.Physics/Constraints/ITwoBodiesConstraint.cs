using System.Physics.RigidBodies;

namespace System.Physics.Constraints
{
    public interface ITwoRigidBodiesConstraint : IConstraint
    {
        IRigidBody RigidBodyA { get; }
        IRigidBody RigidBodyB { get; }
    }
}
