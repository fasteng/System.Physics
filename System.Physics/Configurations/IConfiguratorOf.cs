namespace System.Physics.Configurations
{
    public interface IConfiguratorOf<T, TConfiguration> : IConfigurator<T> where TConfiguration : IConfiguration<T>
    {
        void Set(TConfiguration configuration);
    }
}