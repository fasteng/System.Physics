using System.Maths;
using System.Physics.Constraints.Descriptors;
using System.Physics.RigidBodies;
using System.Physics.Visitor;

namespace System.Physics.Constraints.BaseImplementations
{
    public abstract class BaseFixedJoint : BaseUserDataStorer, IFixedJoint
    {
        public FixedJointDescriptor Descriptor
        {
            get { return new FixedJointDescriptor(AnchorPoseALocal, AnchorPoseBLocal, RigidBodyA, RigidBodyB, UserData); }
            set
            {
                UserData = value.UserData;
            }
        }
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<IFixedJoint>(this);
        }

        public abstract IRigidBody RigidBodyA { get; }
        public abstract IRigidBody RigidBodyB { get; }
        public abstract Matrix4x4 AnchorPoseALocal { get;  }
        public abstract Matrix4x4 AnchorPoseBLocal { get; }
        
    }
}