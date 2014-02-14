using System.Maths;
using System.Physics.Constraints.Descriptors;
using System.Physics.RigidBodies;
using System.Physics.Visitor;

namespace System.Physics.Constraints.BaseImplementations
{
    public abstract class BaseHingeJoint : BaseUserDataStorer, IHingeJoint
    {
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<IHingeJoint>(this);
        }

        public HingeJointDescriptor Descriptor
        {
            get
            {
                return new HingeJointDescriptor(AnchorPoseALocal, AnchorPoseBLocal, MaximumAngle, MinimumAngle, RigidBodyA, RigidBodyB, UserData);
            }
            set
            {
                UserData = value.UserData;
            }
        }

        public abstract IRigidBody RigidBodyA { get;  }
        public abstract IRigidBody RigidBodyB { get;  }
        public abstract Matrix4x4 AnchorPoseALocal { get;  }
        public abstract Matrix4x4 AnchorPoseBLocal { get;  }
        public abstract float MaximumAngle { get;  }
        public abstract float MinimumAngle { get;  }
        public abstract float Angle { get; }
        public abstract float RelativeAngularVelocity { get; }
    }
}