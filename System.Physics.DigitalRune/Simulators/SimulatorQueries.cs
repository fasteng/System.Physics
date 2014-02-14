using System;
using System.Collections.Generic;
using System.Linq;
using System.Physics.Simulators;
using System.Text;
using System.Threading.Tasks;

namespace System.Physics.DigitalRune.Simulators
{
    public partial class DigitalRuneSimulator
    {
        private class SimulatorQueries : IQueries
        {
            private readonly DigitalRuneSimulator _simulator;

            public SimulatorQueries(DigitalRuneSimulator simulator)
            {
                _simulator = simulator;
            }
        }
    }
}
