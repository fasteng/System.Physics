namespace System.Physics.Visitor
{
    public interface ITreeStartVisitorOf<TVisitableTree> : IVisitor where TVisitableTree : IVisitableTree
    {
        void StartVisit(TVisitableTree visitableTree);
    }
}