using System.Physics.Constraints;
using System.Physics.Constraints.Descriptors;
using System.Physics.DigitalRune.Constraints;
using System.Physics.Factories;

namespace System.Physics.DigitalRune.Simulators
{

    public partial class DigitalRuneSimulator
    {
        private class SimulatorConstraintsFactory : 
            BaseMultipleFactory<IConstraint>,
            IFactoryOf<IDistanceRangeJoint, DistanceRangeJointDescriptor>,
            IFactoryOf<IFixedJoint, FixedJointDescriptor>,
            IFactoryOf<IHingeJoint, HingeJointDescriptor>,
            IFactoryOf<INoRotationJoint, NoRotationJointDescriptor>,
            IFactoryOf<IPointOnLineJoint, PointOnLineJointDescriptor>,
            IFactoryOf<IPrismaticJoint, PrismaticJointDescriptor>,
            IFactoryOf<ISphericalJoint, SphericalJointDescriptor>
        {
            private readonly DigitalRuneSimulator _simulator;
            public SimulatorConstraintsFactory(DigitalRuneSimulator simulator)
            {
                _simulator = simulator;
            }

            public IDistanceRangeJoint Create(DistanceRangeJointDescriptor descriptor)
            {
                var constraint = new DigitalRuneDistanceRangeJoint(descriptor);
                _simulator._wrappedSimulation.Constraints.Add(constraint.WrappedDistanceRangeJoint);
                return constraint;
            }

            public IFixedJoint Create(FixedJointDescriptor descriptor)
            {
                var constraint = new DigitalRuneFixedJoint(descriptor);
                _simulator._wrappedSimulation.Constraints.Add(constraint.WrappedFixedJoint);
                return constraint;
            }

            public IHingeJoint Create(HingeJointDescriptor descriptor)
            {
                var constraint = new DigitalRuneHingeJoint(descriptor);
                _simulator._wrappedSimulation.Constraints.Add(constraint.WrappedHingeJoint);
                return constraint;
            }

            public INoRotationJoint Create(NoRotationJointDescriptor descriptor)
            {
                var constraint = new DigitalRuneNoRotationJoint(descriptor);
                _simulator._wrappedSimulation.Constraints.Add(constraint.WrappedNoRotationJoint);
                return constraint;
            }

            public IPointOnLineJoint Create(PointOnLineJointDescriptor descriptor)
            {
                var constraint = new DigitalRunePointOnLineJoint(descriptor);
                _simulator._wrappedSimulation.Constraints.Add(constraint.WrappedPointOnLineJoint);
                return constraint;
            }

            public IPrismaticJoint Create(PrismaticJointDescriptor descriptor)
            {
                var constraint = new DigitalRunePrismaticJoint(descriptor);
                _simulator._wrappedSimulation.Constraints.Add(constraint.WrappedPrismaticJoint);
                return constraint;
            }

            public ISphericalJoint Create(SphericalJointDescriptor descriptor)
            {
                var constraint = new DigitalRuneSphericalJoint(descriptor);
                _simulator._wrappedSimulation.Constraints.Add(constraint.WrappedSphericalJoint);
                return constraint;
            }
        }
    }
}
