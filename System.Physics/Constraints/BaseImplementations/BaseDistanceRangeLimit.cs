using System.Maths;
using System.Physics.Constraints.Descriptors;
using System.Physics.RigidBodies;
using System.Physics.Visitor;

namespace System.Physics.Constraints.BaseImplementations
{
    public abstract class BaseDistanceRangeJoint : BaseUserDataStorer, IDistanceRangeJoint
    {
        
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<IDistanceRangeJoint>(this);
        }
        public DistanceRangeJointDescriptor Descriptor
        {
            get { return new DistanceRangeJointDescriptor(AnchorPositionALocal, AnchorPositionBLocal, MinimumDistance, MaximumDistance,  RigidBodyA, RigidBodyB, UserData); }
            set
            {


                UserData = value.UserData;
            }
        }

        public abstract IRigidBody RigidBodyA { get; }
        public abstract IRigidBody RigidBodyB { get; }
        public abstract Vector3 AnchorPositionALocal { get;  }
        public abstract Vector3 AnchorPositionBLocal { get;  }
        public abstract float MinimumDistance { get;  }
        public abstract float MaximumDistance { get;  }
    }
}