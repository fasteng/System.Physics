using System.Collections.Generic;

namespace System.Physics.Factories
{
    public interface IMultipleFactory<TBase> : IFactory<TBase>
    {
        bool Deallocate<TElement>(TElement element) where TElement : TBase;

        IEnumerable<TElement> GetElements<TElement>() where TElement : TBase;

        IEnumerable<TBase> Elements { get; }
    }
}