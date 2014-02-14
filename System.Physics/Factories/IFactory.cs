using System.Physics.Shapes;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Factories
{
    public interface IFactory<TBase> : IVisitableTree
    {
        TElement Create<TElement>()
            where TElement : TBase;

        TElement Create<TElement, TDescriptor>(TDescriptor descriptor)
            where TDescriptor : struct, IDescriptor
            where TElement : TBase, IDescriptible<TDescriptor>;

        TElement Replicate<TElement>(TElement element) where TElement : TBase, IStateCopier<TElement>;

        void Clear();

        event UnsupportedOperationEventHandler UnsupportedOperation;
    }
}
