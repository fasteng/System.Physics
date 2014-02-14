using System.Maths;
using System.Physics.Constraints.Descriptors;
using System.Physics.RigidBodies;
using System.Physics.Visitor;

namespace System.Physics.Constraints.BaseImplementations
{
    public abstract class BaseCylindricalJoint : BaseUserDataStorer, ICylindricalJoint
    {
       
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<ICylindricalJoint>(this);
        }
        public CylindricalJointDescriptor Descriptor
        {
            get { return new CylindricalJointDescriptor(AnchorPoseALocal, AnchorPoseBLocal, MaximumAngle, MinimumAngle, MaximumDistance,MinimumDistance,  RigidBodyA, RigidBodyB, UserData); }
            set
            {
                UserData = value.UserData;
 
            }
        }

        public abstract IRigidBody RigidBodyA { get; }
        public abstract IRigidBody RigidBodyB { get; }
        public abstract Matrix4x4 AnchorPoseALocal { get;  }
        public abstract Matrix4x4 AnchorPoseBLocal { get;  }
        public abstract float MaximumAngle { get;  }
        public abstract float MinimumAngle { get;  }
        public abstract float MaximumDistance { get;  }
        public abstract float MinimumDistance { get;  }
    }
}