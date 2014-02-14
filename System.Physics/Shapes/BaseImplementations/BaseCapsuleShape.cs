using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes.BaseImplementations
{
    public abstract class BaseCapsuleShape : BaseUserDataStorer, ICapsuleShape
    {
        public CapsuleShapeDescriptor Descriptor
        {
            get
            {
                return new CapsuleShapeDescriptor(Radius,
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
            visitor.Visit<ICapsuleShape>(this);
        }
        public void CopyStateTo(ICapsuleShape element)
        {
            element.Descriptor = Descriptor;
        }

        public abstract float Height { get; set; }
        public abstract float Radius { get; set; }
    }
}