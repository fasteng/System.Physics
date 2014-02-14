using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes.BaseImplementations
{
    public abstract class BaseCylinderShape : BaseUserDataStorer, ICylinderShape
    {
        public CylinderShapeDescriptor Descriptor
        {
            get
            {
                return new CylinderShapeDescriptor(Radius,
                                                   Height,
                                                   UserData);
            }
            set
            {
                Radius = value.Radius;
                Height = value.Height;
                UserData = value.UserData;
            }
        }
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<ICylinderShape>(this);
        }
        public void CopyStateTo(ICylinderShape element)
        {
            element.Descriptor = Descriptor;
        }

        public abstract float Height { get; set; }
        public abstract float Radius { get; set; }
    }
}