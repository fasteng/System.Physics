using System.Maths;
using System.Physics.Factories;

using System.Physics.Shapes;
using System.Physics.Visitor;

namespace System.Physics.Shapes
{
    public abstract class BaseShapePositioner : IShapePositioner
    {
        public ShapePositionerDescriptor Descriptor
        {
            get { return new ShapePositionerDescriptor(Pose); }
            set
            {
                Pose = value.Pose;
                UserData = UserData;
            }
        }

        public object UserData { get; set; }

        public abstract Matrix4x4 Pose { get; set; }
        public abstract ISingleFactory<IShape> ShapeFactory { get; protected set; }
        
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.StartVisit<IShapePositioner>(this);
            ShapeFactory.AcceptVisit(visitor);
            visitor.EndVisit<IShapePositioner>(this);
        }
    }
}