using System.Physics.Fixtures;
using System.Physics.Shapes;

namespace System.Physics.RigidBodies
{
    public static class MassExtensors
    {
        public static void AdjustMassAndInertia(this IMassFrame massFrame, float targetMass)
        {
            float scale = targetMass / massFrame.Mass;
            massFrame.Mass = targetMass;
            massFrame.Inertia = massFrame.Inertia * scale;
        }

        public static MassFrameDescriptor FromFixture(IFixture fixture)
        {
            throw new NotImplementedException();
        }
    }

}