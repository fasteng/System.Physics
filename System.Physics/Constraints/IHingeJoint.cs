using System.Maths;
using System.Physics.Constraints.DefaultImplementations;
using System.Physics.Constraints.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Constraints
{
    [DefaultImplementationType(typeof(DefaultHingeJoint))]
    public interface IHingeJoint : IDescriptible<HingeJointDescriptor>, ITwoRigidBodiesConstraint, IVisitableLeaf
    {
        Matrix4x4 AnchorPoseALocal { get; }
        Matrix4x4 AnchorPoseBLocal { get; }
        float MaximumAngle { get; }
        float MinimumAngle { get;  }
        float Angle { get; }
        float RelativeAngularVelocity { get; }
    }
}
