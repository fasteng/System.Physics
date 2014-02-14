using System.Maths;
using System.Physics.Constraints.Descriptors;
using System.Physics.RigidBodies;
using System.Physics.Visitor;

namespace System.Physics.Constraints.BaseImplementations
{
    public abstract class BaseNoRotationJoint : BaseUserDataStorer, INoRotationJoint
    {
        
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<INoRotationJoint>(this);
        }
        public NoRotationJointDescriptor Descriptor
        {
            get { return new NoRotationJointDescriptor(AnchorOrientationALocal, AnchorOrientationBLocal,  RigidBodyA, RigidBodyB, UserData); }
            set
            {
                UserData = value.UserData;
            }
        }

        public abstract IRigidBody RigidBodyA { get; }
        public abstract IRigidBody RigidBodyB { get; }
        public abstract Matrix3x3 AnchorOrientationALocal { get;  }
        public abstract Matrix3x3 AnchorOrientationBLocal { get;  }
    }
}