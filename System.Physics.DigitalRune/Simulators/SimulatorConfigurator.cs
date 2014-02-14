using System;
using System.Collections.Generic;
using System.Linq;
using System.Physics.Configurations;
using System.Physics.Simulators;
using System.Physics.Simulators.Configurations;
using System.Text;
using System.Threading.Tasks;
using DigitalRune.Geometry.Shapes;
using DigitalRune.Physics;

namespace System.Physics.DigitalRune.Simulators
{
    public partial class DigitalRuneSimulator
    {
        private class SimulatorConfigurator :
            BaseConfigurator<ISimulator>,
            IConfiguratorOf<ISimulator, CcdConfiguration>,
            IConfiguratorOf<ISimulator, AllowedConstrainErrorsConfiguration>,
            IConfiguratorOf<ISimulator, MultithreadingConfiguration>,
            IConfiguratorOf<ISimulator, TimeStepingConfiguration>,
            IConfiguratorOf<ISimulator, SceneDelimitationConfiguration>,
            IConfiguratorOf<ISimulator, SleepingConfiguration>, IConfiguratorOf<ISimulator, MaximumVelocitiesConfiguration>
        {
            private readonly DigitalRuneSimulator _simulator;

            public SimulatorConfigurator(DigitalRuneSimulator simulator)
            {
                _simulator = simulator;
            }

            void IConfiguratorOf<ISimulator, CcdConfiguration>.Set(CcdConfiguration configuration)
            {
                _simulator._wrappedSimulation.Settings.Motion.CcdEnabled = configuration.CcdEnabled;
            }

            void IConfiguratorOf<ISimulator, AllowedConstrainErrorsConfiguration>.Set(AllowedConstrainErrorsConfiguration configuration)
            {
                _simulator._wrappedSimulation.Settings.Constraints.AllowedAngularDeviation = configuration.AllowedAngularDeviation;
                _simulator._wrappedSimulation.Settings.Constraints.AllowedLinearDeviation = configuration.AllowedLinearDeviation;
                _simulator._wrappedSimulation.Settings.Constraints.AllowedPenetration = configuration.AllowedPenetration;
            }

            void IConfiguratorOf<ISimulator, MultithreadingConfiguration>.Set(MultithreadingConfiguration configuration)
            {
                _simulator._wrappedSimulation.Settings.EnableMultithreading = configuration.MultithreadingEnabled;
            }

            void IConfiguratorOf<ISimulator, TimeStepingConfiguration>.Set(TimeStepingConfiguration configuration)
            {
                _simulator._wrappedSimulation.Settings.Timing.MaxNumberOfSteps = configuration.MaxNumberOfTimeSteps;
                _simulator._wrappedSimulation.Settings.Timing.FixedTimeStep = configuration.TimeStepSize;
                //todo wrappear el evento, _simulator._wrappedSimulator.SubTimeStepFinished = configuration.TimeStepFinishedHandler;

            }

            void IConfiguratorOf<ISimulator, SceneDelimitationConfiguration>.Set(SceneDelimitationConfiguration configuration)
            {
                var boxShape = (BoxShape) _simulator._wrappedSimulation.World.Shape;
                boxShape.WidthX = configuration.SceneWidthX;
                boxShape.WidthY = configuration.SceneWidthY;
                boxShape.WidthZ = configuration.SceneWidthZ;
                _simulator._wrappedSimulation.Settings.Motion.RemoveBodiesOutsideWorld = configuration.RemoveBodiesOutsideScene;
            }

            void IConfiguratorOf<ISimulator, SleepingConfiguration>.Set(SleepingConfiguration configuration)
            {
                _simulator._wrappedSimulation.Settings.Sleeping.AngularVelocityThreshold = configuration.AngularVelocityThreshold;
                _simulator._wrappedSimulation.Settings.Sleeping.LinearVelocityThreshold = configuration.LinearVelocityThreshold;
                _simulator._wrappedSimulation.Settings.Sleeping.TimeThreshold = configuration.TimeThreshold;
            }

            void IConfiguratorOf<ISimulator, MaximumVelocitiesConfiguration>.Set(MaximumVelocitiesConfiguration configuration)
            {
                _simulator._wrappedSimulation.Settings.Motion.MaxAngularVelocity = configuration.MaximumAngularVelocity;
                _simulator._wrappedSimulation.Settings.Motion.MaxLinearVelocity = configuration.MaximumLinearVelocity;
            }
        }
    }
}
