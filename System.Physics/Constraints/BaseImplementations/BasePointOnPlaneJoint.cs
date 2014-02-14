using System.Maths;
using System.Physics.Constraints.Descriptors;
using System.Physics.RigidBodies;
using System.Physics.Visitor;

namespace System.Physics.Constraints.BaseImplementations
{
    public abstract class BasePointOnPlaneJoint : BaseUserDataStorer, IPointOnPlaneJoint
    {
        
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<IPointOnPlaneJoint>(this);
        }
        public PointOnPlaneJointDescriptor Descriptor
        {
            get
            {
                return new PointOnPlaneJointDescriptor(AnchorPositionALocal, XAxisALocal, YAxisALocal, AnchorPositionBLocal,
                                                       MaximumDistanceX, MinimumDistanceX, MaximumDistanceY, MinimumDistanceY,  RigidBodyA, RigidBodyB, UserData);
            }
            set
            {
                UserData = value.UserData;
            }
        }

        public abstract IRigidBody RigidBodyA { get;}
        public abstract IRigidBody RigidBodyB { get;}
        public abstract Vector3 AnchorPositionALocal { get;  }
        public abstract Vector3 XAxisALocal { get;  }
        public abstract Vector3 YAxisALocal { get;  }
        public abstract Vector3 AnchorPositionBLocal { get;  }
        public abstract float MaximumDistanceX { get;  }
        public abstract float MinimumDistanceX { get;  }
        public abstract float MaximumDistanceY { get;  }
        public abstract float MinimumDistanceY { get;  }
        public abstract Vector2 RelativePosition { get; }
    }
}