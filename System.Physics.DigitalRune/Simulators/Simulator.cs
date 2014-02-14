using System.Collections.Generic;
using System.Physics.RigidBodies;
using System.Physics.Configurations;
using System.Physics.Constraints;
using System.Physics.Factories;
using System.Physics.Simulators;
using DigitalRune.Physics;
using DigitalRune.Physics.ForceEffects;
using DigitalRune.Physics.Materials;

namespace System.Physics.DigitalRune.Simulators
{
    public partial class DigitalRuneSimulator : BaseSimulator
    {
        private readonly Simulation _wrappedSimulation;

        public DigitalRuneSimulator()
        {
            _wrappedSimulation = new Simulation();
            ((MaterialPropertyCombiner)_wrappedSimulation.Settings.MaterialPropertyCombiner).RestitutionMode = MaterialPropertyCombiner.Mode.ArithmeticMean;
            ((MaterialPropertyCombiner)_wrappedSimulation.Settings.MaterialPropertyCombiner).FrictionMode = MaterialPropertyCombiner.Mode.ArithmeticMean;            
            _wrappedSimulation.ForceEffects.Add(new Damping());

            Configurator = new SimulatorConfigurator(this);
            Queries = new SimulatorQueries(this);
            ActorsFactory = new SimulatorRigidBodyFactory(this);
            ConstraintsFactory = new SimulatorConstraintsFactory(this);
        }

        public override IMultipleFactory<IActor> ActorsFactory { get; protected set; }
        public override IMultipleFactory<IConstraint> ConstraintsFactory { get; protected set; }
        public override IConfigurator<ISimulator> Configurator { get; protected set; }
        public override IQueries Queries { get; protected set; }
        public override void Update(float seconds)
        {
            ApplyForceEffects();
            _wrappedSimulation.Update(seconds);
        }
    }
}
