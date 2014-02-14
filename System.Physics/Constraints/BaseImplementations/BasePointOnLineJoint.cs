using System.Maths;
using System.Physics.Constraints.Descriptors;
using System.Physics.RigidBodies;
using System.Physics.Visitor;

namespace System.Physics.Constraints.BaseImplementations
{
    public abstract class BasePointOnLineJoint : BaseUserDataStorer, IPointOnLineJoint
    {
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<IPointOnLineJoint>(this);
        }

        public PointOnLineJointDescriptor Descriptor
        {
            get { return new PointOnLineJointDescriptor(AnchorPositionALocal, AxisALocal, AnchorPositionBLocal, MaximumDistance, MinimumDistance, RigidBodyA, RigidBodyB, UserData); }
            set
            {
                UserData = value.UserData;
            }
        }

        public abstract IRigidBody RigidBodyA { get;}
        public abstract IRigidBody RigidBodyB { get;}
        public abstract Vector3 AnchorPositionALocal { get;}
        public abstract Vector3 AxisALocal { get; }
        public abstract Vector3 AnchorPositionBLocal { get; }
        public abstract float MaximumDistance { get;  }
        public abstract float MinimumDistance { get;  }
        public abstract float Distance { get; }
    }
}