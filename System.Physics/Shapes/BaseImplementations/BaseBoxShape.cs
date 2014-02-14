using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes.BaseImplementations
{
    public abstract class BaseBoxShape : BaseUserDataStorer, IBoxShape
    {
        public BoxShapeDescriptor Descriptor
        {
            get
            {
                return new BoxShapeDescriptor(WidthX,
                                              WidthY,
                                              WidthZ,
                                              UserData);
            }
            set
            {
                WidthX = value.WidthX;
                WidthY = value.WidthY;
                WidthZ = value.WidthZ;
                UserData = value.UserData;
            }
        }
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<IBoxShape>(this);
        }
        public void CopyStateTo(IBoxShape element)
        {
            element.Descriptor = Descriptor;
        }

        public abstract float WidthX { get; set; }
        public abstract float WidthY { get; set; }
        public abstract float WidthZ { get; set; }
    }
}