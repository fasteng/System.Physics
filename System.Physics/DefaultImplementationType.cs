namespace System.Physics
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class DefaultImplementationType : Attribute
    {
        public DefaultImplementationType(Type defaultImplementation)
        {
            Type = defaultImplementation;
        }

        public Type Type { get; set; }
    }

}
