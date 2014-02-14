namespace System.Physics.Visitor
{
    public interface ITreeEndVisitorOf<TVisitableTree> : IVisitor where TVisitableTree : IVisitableTree
    {
        void EndVisit(TVisitableTree visitableTree);
    }
}