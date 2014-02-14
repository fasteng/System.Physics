using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes.BaseImplementations
{
    public abstract class BaseRectangleShape : BaseUserDataStorer, IRectangleShape
    {
        public RectangleShapeDescriptor Descriptor
        {
            get
            {
                return new RectangleShapeDescriptor(WidthX,
                                                    WidthY,
                                                    UserData);
            }
            set
            {
                UserData = value.UserData;
                WidthX = value.WidthX;
                WidthY = value.WidthY;
            }
        }
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<IRectangleShape>(this);
        }
        public void CopyStateTo(IRectangleShape element)
        {
            element.Descriptor = Descriptor;
        }

        public abstract float WidthY { get; set; }
        public abstract float WidthX { get; set; }
    }
}