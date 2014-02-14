using System.Maths;
using System.Physics.RigidBodies;

namespace System.Physics.PhysX.RigidBodies
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
                if (space == CoordinateSpace.Local)
                    _rigidBody.WrappedActor.SetCenterOfMassOffsetLocalPose(pose.ToPhysX()); 
                else
                    _rigidBody.WrappedActor.SetCenterOfMassOffsetGlobalPose(pose.ToPhysX()); 

            }

            public Matrix4x4 GetPose(CoordinateSpace space = CoordinateSpace.Local)
            {
                if (space == CoordinateSpace.Local)
                    return _rigidBody.WrappedActor.CenterOfMassLocalPose.ToStandard();
                else
                    return _rigidBody.WrappedActor.CenterOfMassGlobalPose.ToStandard(); 
            }

            public float Mass
            {
                get { return _rigidBody.WrappedActor.Mass; }
                set { _rigidBody.WrappedActor.Mass = value; }
            }

            public Vector3 Inertia
            {
                get { return _rigidBody.WrappedActor.MassSpaceInertiaTensor.ToStandard(); }
                set { _rigidBody.WrappedActor.MassSpaceInertiaTensor = value.ToPhysX(); }
            }


            public void UpdateFromShape()
            {
                _rigidBody.WrappedActor.UpdateMassFromShapes(1000,0);
            }

            public MassFrameDescriptor Descriptor 
            { 
                get{return new MassFrameDescriptor(Mass,Inertia,GetPose());}
                set
                {
                    Mass = value.Mass;
                    Inertia = value.Inertia;
                    SetPose(value.LocalPose);
                }
            }
        }
    }
}
