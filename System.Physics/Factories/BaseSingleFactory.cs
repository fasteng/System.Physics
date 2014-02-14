using System.Collections.Generic;
using System.Linq;
using System.Physics.Configurations;
using System.Physics.Visitor;
using System.Reflection;

namespace System.Physics.Factories
{
    public abstract class BaseSingleFactory<TBase> : 
        BaseFactory<TBase>, ISingleFactory<TBase>
        where TBase : IVisitable
    {
        private Type _elementType;

        protected override void Store<TElement>(TElement element)
        {
            Element = element;
            _elementType = element.GetType();
        }

        public override void AcceptVisit(IVisitor visitor)
        {
            visitor.StartVisit<ISingleFactory<TBase>>(this);
            Element.AcceptVisit(visitor);
            visitor.EndVisit<ISingleFactory<TBase>>(this);
        }

        public override void Clear()
        {
            if (!Equals(Element, default(TBase)))
            {
                //~~~~~((IFactoryOf<_elementType>)this).Deallocate(Element);~~~~~
                //getting the interface IFactory
                Type factoryOfType = typeof(IFactoryOf<>);
                //assigning the generic parameter
                factoryOfType = factoryOfType.MakeGenericType(_elementType);
                //getting the Deallocate method
                var deallocateMethodInfo = factoryOfType.GetMethod("Deallocate");
                //invoking the Deallocate method
                deallocateMethodInfo.Invoke(this, new object[] { Element });
                
                _elementType = null;
                Element = default(TBase);
            }
        }

        public TBase Element { get; protected set; }
    }
}