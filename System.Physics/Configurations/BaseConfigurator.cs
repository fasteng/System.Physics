using System.Collections.Generic;
using System.Physics.Factories;
using System.Reflection;

namespace System.Physics.Configurations
{
    public class BaseConfigurator<T> : IConfigurator<T>
    {
        private Dictionary<Type, IConfiguration<T>> _configurations = new Dictionary<Type, IConfiguration<T>>();

        public TConfiguration Get<TConfiguration>() where TConfiguration : struct, IConfiguration<T>
        {
            IConfiguration<T> configuration;
            if (_configurations.TryGetValue(typeof(TConfiguration), out configuration))
                return (TConfiguration)configuration;

            var defaultConf = new TConfiguration();
            defaultConf.ToDefault();
            return defaultConf;
        }

        public void Set<TConfiguration>(TConfiguration configuration)
            where TConfiguration : struct, IConfiguration<T>
        {
            if (this is IConfiguratorOf<T, TConfiguration>)
                ((IConfiguratorOf<T, TConfiguration>)this).Set(configuration);
            else
                UnsupportedOperation(this, new UnsupportedOperationEventArgs("Usupported configuration of type " + typeof(TConfiguration)));

            _configurations[configuration.GetType()] = configuration;
        }

        public void CopyStateTo(IConfigurator<T> otherConfigurator)
        {
            otherConfigurator.Clear();

            //get the type
            Type otherConfiguratorType = otherConfigurator.GetType();
            //get the set method
            MethodInfo setMethodInfo = otherConfiguratorType.GetMethod("Set");
            foreach (KeyValuePair<Type, IConfiguration<T>> pair in _configurations)
            {
                Type configurationType = pair.Key;
                IConfiguration<T> configuration = pair.Value;
                //assigning the generic parameters of the set method with configurationType
                MethodInfo setGenericMethod = setMethodInfo.MakeGenericMethod(configurationType);
                //invoking the set method with the configuration
                setGenericMethod.Invoke(otherConfigurator, new object[] { configuration });
            }
        }

        public void Clear()
        {
            //get the factory type
            Type factoryType = this.GetType();
            //get the set method
            MethodInfo setMethodInfo = factoryType.GetMethod("Set");
            foreach (KeyValuePair<Type, IConfiguration<T>> pair in _configurations)
            {
                Type configurationType = pair.Key;
                IConfiguration<T> configuration = pair.Value;
                //setting every configuration to the default value
                configuration.ToDefault();
                //assigning the generic parameters of the set method with configurationType
                MethodInfo setGenericMethod = setMethodInfo.MakeGenericMethod(configurationType);
                //invoking the set method with the default configuration
                setGenericMethod.Invoke(this, new object[] { configuration });
            }
            _configurations.Clear();
        }

        public event UnsupportedOperationEventHandler UnsupportedOperation;
    }
}