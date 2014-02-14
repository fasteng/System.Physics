using System.Maths;
using System.Physics.Constraints.Descriptors;
using System.Physics.RigidBodies;
using System.Physics.Visitor;

namespace System.Physics.Constraints.BaseImplementations
{
    public abstract class BasePrismaticJoint : BaseUserDataStorer, IPrismaticJoint
    {
        
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<IPrismaticJoint>(this);
        }
        public PrismaticJointDescriptor Descriptor
        {
            get
            {
                return new PrismaticJointDescriptor(AnchorPoseALocal, AnchorPoseBLocal, MaximumDistance, MinimumDistance,  RigidBodyA, RigidBodyB, UserData);
            }
            set
            {

                UserData = value.UserData;
            }
        }

        public abstract IRigidBody RigidBodyA { get; }
        public abstract IRigidBody RigidBodyB { get; }
        public abstract Matrix4x4 AnchorPoseALocal { get;  }
        public abstract Matrix4x4 AnchorPoseBLocal { get;  }
        public abstract float MaximumDistance { get; }
        public abstract float MinimumDistance { get;  }
    }
}