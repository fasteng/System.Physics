using System;
using System.Collections.Generic;
using System.Linq;
using System.Maths;
using System.Physics.RigidBodies;
using System.Physics.DigitalRune;
using System.Physics.Shapes;
using System.Text;
using System.Threading.Tasks;
using DR = DigitalRune.Physics;

namespace System.Physics.DigitalRune.RigidBodies
{
    public partial class RigidBody
    {
        private class RigidBodyMassFrame : IMassFrame
        {
            private readonly RigidBody _rigidBody;

            public RigidBodyMassFrame(RigidBody rigidBody)
            {
                _rigidBody = rigidBody;
                var defaultMassFrameDescriptor = new MassFrameDescriptor();
                defaultMassFrameDescriptor.ToDefault();
                Descriptor = defaultMassFrameDescriptor;
            }

            public void SetPose(Matrix4x4 pose, CoordinateSpace space = CoordinateSpace.Local)
            {
                if (space == CoordinateSpace.Global)
                    _rigidBody.WrappedRigidBody.PoseCenterOfMass = pose.ToDigitalRune();
                else
                    _rigidBody.WrappedRigidBody.MassFrame.Pose = pose.ToDigitalRune();
            }

            public Matrix4x4 GetPose(CoordinateSpace space = CoordinateSpace.Local)
            {
                if (space == CoordinateSpace.Global)
                    return _rigidBody.WrappedRigidBody.PoseCenterOfMass.ToStandard();
                else
                    return _rigidBody.WrappedRigidBody.MassFrame.Pose.ToStandard();
            }

            public float Mass
            {
                get { return _rigidBody.WrappedRigidBody.MassFrame.Mass; }
                set { _rigidBody.WrappedRigidBody.MassFrame.Mass = value; }
            }

            public Vector3 Inertia
            {
                get { return _rigidBody.WrappedRigidBody.MassFrame.Inertia.ToStandard(); }
                set { _rigidBody.WrappedRigidBody.MassFrame.Inertia = value.ToDigitalRune(); }
            }

            public void UpdateFromShape()
            {
                var rigidBody = _rigidBody.WrappedRigidBody;
               rigidBody.MassFrame = DR.MassFrame.FromShapeAndDensity(rigidBody.Shape, new Vector3(1).ToDigitalRune(), rigidBody.MassFrame.Density, 0.005f, 30);
            }

            public MassFrameDescriptor Descriptor 
            { 
                get{return new MassFrameDescriptor(Mass,Inertia,_rigidBody.WrappedRigidBody.MassFrame.Pose.ToStandard());}
                set
                {
                    Mass = value.Mass;
                    Inertia = value.Inertia;
                    _rigidBody.WrappedRigidBody.MassFrame.Pose = value.LocalPose.ToDigitalRune();
                }
            }
        }
    }
}
