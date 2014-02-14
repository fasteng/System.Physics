using System.Maths;
using System.Physics.RigidBodies;
using System.Physics.RigidBodies;
using StillDesign.PhysX;
using Vector3 = StillDesign.PhysX.MathPrimitives.Vector3;

namespace System.Physics.PhysX.RigidBodies
{
    public partial class RigidBody : BaseRigidBody
    {
        internal readonly Actor WrappedActor;
        internal Material DefaultMaterial;
        internal bool HasDefaultShape;
        internal RigidBody(RigidBodyDescriptor descriptor, Scene scene)
        {
            WrappedActor = CreateActor(descriptor, scene);
            Configurator = new RigidBodyConfigurator(this);
            FixtureFactory = new RigidBodyFixtureFactory(this);
            Forces = new RigidBodyForces(this);
            Velocity = new RigidBodyVelocity(this);
            MassFrame = new RigidBodyMassFrame(this);
            UserData = descriptor.UserData;
        }

        private Actor CreateActor(RigidBodyDescriptor descriptor, Scene scene)
        {
         
            var materialDesc = new MaterialDescription
            {
                DynamicFriction = 0.5f,
                StaticFriction = 0.5f,
                Restitution = 0.7f,
                FrictionCombineMode = CombineMode.Average,
                RestitutionCombineMode = CombineMode.Average
            };
            DefaultMaterial = scene.CreateMaterial(materialDesc);
            var boxDesc = new BoxShapeDescription
            {
                Material = DefaultMaterial,
                Dimensions = new Vector3(1, 1, 1)
            };
            ///////////////////////////////////////////////



            //resolve the motion type
            var rigidBodyDesc = descriptor.MotionType == MotionType.Static
                                    ? null
                                    : new BodyDescription();
            if (descriptor.MotionType == MotionType.Kinematic)
                rigidBodyDesc.BodyFlags = BodyFlag.Kinematic;

            HasDefaultShape = true;
            var actorDesc = new ActorDescription(boxDesc)
                                {
                                    BodyDescription = rigidBodyDesc,
                                    Density = 10.0f,
                                    GlobalPose = descriptor.Pose.ToPhysX(),
                                    UserData = descriptor.UserData
                                };
            return scene.CreateActor(actorDesc);
        }

        public override MotionType MotionType
        {
            get
            {
                return WrappedActor.IsDynamic
                           ? (WrappedActor.BodyFlags.Kinematic
                                  ? MotionType.Kinematic
                                  : MotionType.Dynamic)
                           : MotionType.Static;
            }
        }
         
        public override Matrix4x4 Pose
        {
            get { return WrappedActor.GlobalPose.ToStandard(); }
            set { WrappedActor.GlobalPose = value.ToPhysX(); }
        }

        public override float KineticEnergy { get { return WrappedActor.ComputeKineticEnergy(); } }
    }
}
