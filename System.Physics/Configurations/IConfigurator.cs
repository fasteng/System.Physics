namespace System.Physics.Configurations
{
    public interface IConfigurator<T>
    {
        TConfiguration Get<TConfiguration>() where TConfiguration : struct, IConfiguration<T>;

        void Set<TConfiguration>(TConfiguration configuration)
            where TConfiguration : struct, IConfiguration<T>;

        void Clear();

        event UnsupportedOperationEventHandler UnsupportedOperation;
    }
}