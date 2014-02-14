using System.Maths;
using System.Physics.Constraints;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes.BaseImplementations
{
    public abstract class BasePlaneShape : BaseUserDataStorer, IPlaneShape
    {
        public PlaneShapeDescriptor Descriptor
        {
            get
            {
                return new PlaneShapeDescriptor(Normal,
                                                DistanceFromOrigin,
                                                UserData);
            }
            set
            {
                Normal = value.Normal;
                DistanceFromOrigin = value.DistanceFromOrigin;
                UserData = value.UserData;
            }
        }
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<IPlaneShape>(this);
        }
        public void CopyStateTo(IPlaneShape element)
        {
            element.Descriptor = Descriptor;
        }

        public abstract Vector3 Normal { get; set; }
        public abstract float DistanceFromOrigin { get; set; }
    }
}