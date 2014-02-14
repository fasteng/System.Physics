using System.Collections.Generic;
using System.Linq;
using System.Physics.Visitor;
using System.Reflection;

namespace System.Physics.Factories
{
    public abstract class BaseMultipleFactory<TBase> : BaseFactory<TBase>, IMultipleFactory<TBase>
        where TBase :IVisitable
    {
        private Dictionary<Type, HashSet<TBase>> _allocatedElements = new Dictionary<Type, HashSet<TBase>>();

        protected override void Store<TElement>(TElement element)
        {
            Type elementType = typeof(TElement);
            HashSet<TBase> set;
            if (!_allocatedElements.TryGetValue(elementType, out set))
                set = _allocatedElements[elementType] = new HashSet<TBase>();
            set.Add(element);
        }

        protected bool Remove<TElement>(TElement element) where TElement : TBase
        {
            HashSet<TBase> set;
            return _allocatedElements.TryGetValue(typeof(TElement), out set) && set.Remove(element);
        }

        public IEnumerable<TElement> GetElements<TElement>() where TElement : TBase
        {
            Type elementType = typeof(TElement);
            HashSet<TBase> set;
            if (_allocatedElements.TryGetValue(elementType, out set))
            {
                foreach (TBase element in set)
                {
                    yield return (TElement)element;
                }
            }
        }

        public IEnumerable<TBase> Elements 
        { 
            get 
            {
                return _allocatedElements.Values.SelectMany(set => set);
            }
        }

        public override void AcceptVisit(IVisitor visitor)
        {
            visitor.StartVisit<IMultipleFactory<TBase>>(this);
            foreach (var element in Elements)
                element.AcceptVisit(visitor);
            visitor.EndVisit<IMultipleFactory<TBase>>(this);
        }

        public bool Deallocate<TElement>(TElement element) where TElement : TBase
        {
            if (this is IFactoryOf<TElement>)
            {
                return ((IFactoryOf<TElement>)this).Deallocate(element);
            }
            return false;
        }

        public override void Clear()
        {
            foreach (KeyValuePair<Type, HashSet<TBase>> pair in _allocatedElements)
                foreach (TBase element in pair.Value)
                {
                    Type elementType = pair.Key;
                    //~~~~~((IFactoryOf<elementType>)this).Deallocate(element);~~~~~
                    //getting the interface IFactory
                    Type factoryOfType = typeof(IFactoryOf<>);
                    //assigning the generic parameter
                    factoryOfType = factoryOfType.MakeGenericType(elementType);
                    //getting the Deallocate method
                    var deallocateMethodInfo = factoryOfType.GetMethod("Deallocate");
                    //invoking the Deallocate method
                    deallocateMethodInfo.Invoke(this, new object[] { element });
                }
            _allocatedElements.Clear();
        }
    }
}