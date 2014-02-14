namespace System.Physics.Visitor
{
    public interface IVisitable
    {
        void AcceptVisit(IVisitor visitor);
    }
}
