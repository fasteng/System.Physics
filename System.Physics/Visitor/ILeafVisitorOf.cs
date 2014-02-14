namespace System.Physics.Visitor
{
    public interface ILeafVisitorOf<TVisitable> : IVisitor where TVisitable : IVisitable
    {
        void Visit(TVisitable visitable);
    }
}