namespace System.Physics.Factories
{
    public interface ISingleFactory<TBase> : IFactory<TBase>
    {

        TBase Element { get; }
    }
}