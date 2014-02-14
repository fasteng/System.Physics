using System.Physics.Factories;
using System.Physics.Visitor;
using System.Reflection;

namespace System.Physics
{
    public abstract class BaseFactory<TBase> : IFactory<TBase>
    {
        public TElement Create<TElement>()
            where TElement : TBase
        {
            if (this is IFactoryOf<TElement>)
            {
                var element = ((IFactoryOf<TElement>) this).Create();
                Store(element);
                return element;
            }
            UnsupportedOperation(this,new UnsupportedOperationEventArgs("Usupported creation of an instance of the type " + typeof(TElement)));
            try
            {
                //getting the attribute
                var defaultImpAtt = (DefaultImplementationType)Attribute.GetCustomAttribute(typeof(TElement), typeof(DefaultImplementationType));

                //getting the associated default type
                Type defaultImpType = defaultImpAtt.Type;

                //getting the default constructor of the associated default type
                ConstructorInfo defaultImpCtorInfo = defaultImpType.GetConstructor(new Type[] { });

                //invoking the default constructor
                var defaultElement = (TElement)defaultImpCtorInfo.Invoke(new object[] { });

                //retorning the element
                return defaultElement;
            }
            catch (Exception)
            {
                throw new ArgumentException("The type assigned to the parameter TElement do must have an assosiated default implementation.");
            }

        }

        public TElement Create<TElement, TDescriptor>(TDescriptor descriptor)
            where TDescriptor : struct, IDescriptor
            where TElement : TBase, IDescriptible<TDescriptor>
        {
            if (this is IFactoryOf<TElement, TDescriptor>)
            {
                var element = ((IFactoryOf<TElement, TDescriptor>)this).Create(descriptor);
                Store(element);
                return element;
            }
            UnsupportedOperation(this, new UnsupportedOperationEventArgs("Usupported creation of an instance of the type " + typeof(TElement)));
            try
            {
                //getting the attribute
                var defaultImpAtt = (DefaultImplementationType)Attribute.GetCustomAttribute(typeof(TElement), typeof(DefaultImplementationType));

                //getting the associated default type
                Type defaultImpType = defaultImpAtt.Type;

                //getting the constructor of the associated default type
                ConstructorInfo defaultImpCtorInfo = defaultImpType.GetConstructor(new [] { typeof(TDescriptor) });

                //invoking the constructor
                var defaultElement = (TElement)defaultImpCtorInfo.Invoke(new object[] { descriptor });

                //retorning the element
                return defaultElement;
            }
            catch (Exception)
            {
                throw new ArgumentException("The type assigned to the parameter TElement do must have an assosiated default implementation.");
            }
        }

        public TElement Replicate<TElement>(TElement element)
            where TElement : TBase, IStateCopier<TElement>
        {
            var replicate = Create<TElement>();
            element.CopyStateTo(replicate);
            return replicate;
        }

        protected abstract void Store<TElement>(TElement element) where TElement : TBase;
        public abstract void Clear();
        public event UnsupportedOperationEventHandler UnsupportedOperation;
        public abstract void AcceptVisit(IVisitor visitor);
    }
}
