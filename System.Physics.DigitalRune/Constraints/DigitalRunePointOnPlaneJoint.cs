
using System.Maths;
using System.Physics.RigidBodies;
using System.Physics.Constraints;
using System.Physics.Constraints.BaseImplementations;
using System.Physics.Constraints.Descriptors;
using System.Physics.DigitalRune.RigidBodies;
using System.Physics.DigitalRune;
using DigitalRune.Physics.Constraints;

namespace System.Physics.DigitalRune.Constraints
{
    public class DigitalRunePointOnPlaneJoint : BasePointOnPlaneJoint, IDigitalRuneTwoRigidBodiesConstraint
    {
        internal PointOnPlaneConstraint WrappedPointOnPlaneJoint { get; private set; }

        internal DigitalRunePointOnPlaneJoint(PointOnPlaneJointDescriptor descriptor)
        {
            WrappedPointOnPlaneJoint = new PointOnPlaneConstraint();

            #region set RigidBodies
            if (!(descriptor.RigidBodyA is RigidBody))
                throw new ArgumentException(String.Format("The type of the property 'RigidBodyA' must be '{0}'.", typeof(RigidBody)));
            WrappedPointOnPlaneJoint.BodyA = ((RigidBody)descriptor.RigidBodyA).WrappedRigidBody;
            _rigidBodyA = descriptor.RigidBodyA;

            if (!(descriptor.RigidBodyB is RigidBody))
                throw new ArgumentException("The type of the property 'RigidBodyB' must be 'System.Physics.DigitalRune.RigidBody'.");
            WrappedPointOnPlaneJoint.BodyB = ((RigidBody)descriptor.RigidBodyB).WrappedRigidBody;
            _rigidBodyB = descriptor.RigidBodyB;
            #endregion
            WrappedPointOnPlaneJoint.AnchorPositionALocal = descriptor.AnchorPositionALocal.ToDigitalRune();
            WrappedPointOnPlaneJoint.XAxisALocal = descriptor.XAxisALocal.ToDigitalRune();
            WrappedPointOnPlaneJoint.YAxisALocal = descriptor.YAxisALocal.ToDigitalRune();
            WrappedPointOnPlaneJoint.AnchorPositionBLocal = descriptor.AnchorPositionBLocal.ToDigitalRune();

            var actualMinimumX = WrappedPointOnPlaneJoint.Minimum;
            actualMinimumX[0] = descriptor.MinimumDistanceX;
            WrappedPointOnPlaneJoint.Minimum = actualMinimumX;

            var actualMaximumX = WrappedPointOnPlaneJoint.Maximum;
            actualMaximumX[0] = descriptor.MaximumDistanceX;
            WrappedPointOnPlaneJoint.Maximum = actualMaximumX;

            var actualMaximumY = WrappedPointOnPlaneJoint.Maximum;
            actualMaximumY[1] = descriptor.MaximumDistanceY;
            WrappedPointOnPlaneJoint.Maximum = actualMaximumY;

            var actualMinimumY = WrappedPointOnPlaneJoint.Minimum;
            actualMinimumY[1] = descriptor.MinimumDistanceY;
            WrappedPointOnPlaneJoint.Minimum = actualMinimumY;


            Descriptor = descriptor;
        }

        public override Vector3 AnchorPositionALocal
        {
            get { return WrappedPointOnPlaneJoint.AnchorPositionALocal.ToStandard(); }

        }
        public override Vector3 XAxisALocal
        {
            get { return WrappedPointOnPlaneJoint.XAxisALocal.ToStandard(); }

        }

        public override Vector3 YAxisALocal
        {
            get { return WrappedPointOnPlaneJoint.YAxisALocal.ToStandard(); }

        }

        public override Vector3 AnchorPositionBLocal
        {
            get { return WrappedPointOnPlaneJoint.AnchorPositionBLocal.ToStandard(); }

        }
        public override float MaximumDistanceX
        {
            get { return WrappedPointOnPlaneJoint.Maximum[0]; }
           
        }
        public override float MinimumDistanceX
        {
            get { return WrappedPointOnPlaneJoint.Minimum[0]; }
            
        }
        public override float MaximumDistanceY
        {
            get { return WrappedPointOnPlaneJoint.Maximum[1]; }
           
        }
        public override float MinimumDistanceY
        {
            get { return WrappedPointOnPlaneJoint.Minimum[1]; }
           
        }

        public override Vector2 RelativePosition
        {
            get { return WrappedPointOnPlaneJoint.RelativePosition.ToStandard(); }
        }    
        
        private IRigidBody _rigidBodyA;
        private IRigidBody _rigidBodyB;
        public override IRigidBody RigidBodyA
        {
            get { return _rigidBodyA; }
           
        }

        public override IRigidBody RigidBodyB
        {
            get { return _rigidBodyB; }
           
        }

        
    }
}