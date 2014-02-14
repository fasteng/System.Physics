using System.Maths;
using System.Physics.Constraints.Descriptors;
using System.Physics.RigidBodies;
using System.Physics.Visitor;

namespace System.Physics.Constraints.BaseImplementations
{
    public abstract class BaseSphericalJoint : BaseUserDataStorer, ISphericalJoint
    {
        
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<ISphericalJoint>(this);
        }
        public SphericalJointDescriptor Descriptor
        {
            get { return new SphericalJointDescriptor(AnchorPositionALocal, AnchorPositionBLocal,  RigidBodyA, RigidBodyB, UserData); }
            set
            {
                UserData = value.UserData;
            }
        }

        public abstract IRigidBody RigidBodyA { get;  }
        public abstract IRigidBody RigidBodyB { get;  }
        public abstract Vector3 AnchorPositionALocal { get;}
        public abstract Vector3 AnchorPositionBLocal { get;}
    }
}