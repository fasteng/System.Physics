namespace System.Physics.Factories
{
    public interface IFactoryOf<TElement>
    {
        TElement Create();
        bool Deallocate(TElement element);
    }

    public interface IFactoryOf<TElement, TDescriptor>// : IFactoryOf<TElement>
        where TDescriptor : struct , IDescriptor
        where TElement : IDescriptible<TDescriptor>
    {
        TElement Create(TDescriptor descriptor);
    }
}