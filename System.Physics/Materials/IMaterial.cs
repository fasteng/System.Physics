using System.Physics.Configurations;
using System.Physics.Visitor;

namespace System.Physics.Materials
{
    public interface IMaterial : IDescriptible<MaterialDescriptor>, IVisitableLeaf
    {
        IConfigurator<IMaterial> Configurator
        {
            get;
        }
    }

    public abstract class BaseMaterial : IMaterial
    {
        public MaterialDescriptor Descriptor
        {
            get
            {
                return new MaterialDescriptor(Configurator.Get<FrictionConfiguration>().Friction, 
                                              Configurator.Get<RestitutionConfiguration>().Restitution);
            }
            set
            {
                Configurator.Set(new FrictionConfiguration(value.Friction));
                Configurator.Set(new RestitutionConfiguration(value.Restitution));
            }
        }
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<IMaterial>(this);
        }

        public abstract IConfigurator<IMaterial> Configurator { get; protected set; }
    }
}
