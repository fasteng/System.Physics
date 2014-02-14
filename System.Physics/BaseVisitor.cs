using System.Physics.Visitor;

namespace System.Physics
{
    public class BaseVisitor : IVisitor
    {
        public void StartVisit<TVisitableTree>(TVisitableTree visitableTree) where TVisitableTree : IVisitableTree
        {
            if(this is ITreeStartVisitorOf<TVisitableTree>)
                ((ITreeStartVisitorOf<TVisitableTree>)this).StartVisit(visitableTree);
        }

        public void EndVisit<TVisitableTree>(TVisitableTree visitableTree) where TVisitableTree : IVisitableTree
        {
            if (this is ITreeEndVisitorOf<TVisitableTree>)
                ((ITreeEndVisitorOf<TVisitableTree>)this).EndVisit(visitableTree);
        }

        public void Visit<TVisitableLeaf>(TVisitableLeaf visitableLeaf) where TVisitableLeaf : IVisitableLeaf
        {
            if (this is ILeafVisitorOf<TVisitableLeaf>)
                ((ILeafVisitorOf<TVisitableLeaf>)this).Visit(visitableLeaf);
        }
    }
}