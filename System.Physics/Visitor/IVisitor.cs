namespace System.Physics.Visitor
{
    public interface IVisitor
    {
        void StartVisit<TVisitableTree>(TVisitableTree visitableTree) where TVisitableTree : IVisitableTree;
        void EndVisit<TVisitableTree>(TVisitableTree visitableTree) where TVisitableTree : IVisitableTree;
        void Visit<TVisitableLeaf>(TVisitableLeaf visitableLeaf) where TVisitableLeaf : IVisitableLeaf;
    }
}
