using System.Physics.Configurations;
using System.Physics.Materials;
using System.Physics.PhysX.RigidBodies;
using StillDesign.PhysX;
using PX = StillDesign.PhysX;

namespace System.Physics.PhysX.Materials
{
    internal class Material : BaseMaterial
    {
        internal PX.Material _wrappedMaterial;

        public Material(RigidBody rigidBody, PX.Material wrappedMaterial, MaterialDescriptor descriptor)
        {
            wrappedMaterial.DynamicFriction = descriptor.Friction;
            wrappedMaterial.StaticFriction = descriptor.Friction;
            wrappedMaterial.Restitution = descriptor.Restitution;
            _wrappedMaterial = wrappedMaterial;
            Configurator = new BaseConfigurator<IMaterial>();
        }

        public override IConfigurator<IMaterial> Configurator { get; protected set; }
    }
}