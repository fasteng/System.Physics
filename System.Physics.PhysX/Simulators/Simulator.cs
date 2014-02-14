using System.Physics.Configurations;
using System.Physics.Constraints;
using System.Physics.Factories;
using System.Physics.Simulators;
using StillDesign.PhysX;
using StillDesign.PhysX.MathPrimitives;

namespace System.Physics.PhysX.Simulators
{
    public partial class PhysXSimulator : BaseSimulator
    {
        internal readonly Scene _wrappedScene;
        internal readonly Core _wrappedCore;

        public PhysXSimulator()
        {
            CreateCoreAndScene(out _wrappedCore, out _wrappedScene);
            Configurator = new SimulatorConfigurator(this);
            Queries = new SimulatorQueries(this);
            ActorsFactory = new SimulatorRigidBodyFactory(this);
            ConstraintsFactory = new SimulatorConstraintsFactory(this);
        }

        public override void Update(float seconds)
        {
            ApplyForceEffects();
            _wrappedScene.Simulate(seconds);
            _wrappedScene.FlushStream();
            _wrappedScene.FetchResults(SimulationStatus.AllFinished, true);
        }

        private void CreateCoreAndScene(out Core core, out Scene scene)
        {
            var coreDesc = new CoreDescription();
            core = new Core(coreDesc, null);
            var sceneDesc = new SceneDescription
            {
                SimulationType = SimulationType.Software//todo: ver cual es el lio con hardware
            };
            scene = _wrappedCore.CreateScene(sceneDesc);
        }

        public override IMultipleFactory<IActor> ActorsFactory { get; protected set; }
        public override IMultipleFactory<IConstraint> ConstraintsFactory { get; protected set; }
        public override IConfigurator<ISimulator> Configurator { get; protected set; }
        public override IQueries Queries { get; protected set; }
    }
}
