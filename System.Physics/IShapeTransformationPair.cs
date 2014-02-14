using System;
using System.Collections.Generic;
using System.Linq;
using System.Maths;
using System.Physics.Factories;
using System.Physics.Shapes;
using System.Physics.Visitor;
using System.Text;

namespace System.Physics
{
    public interface IShapePositioner : IDescriptible<ShapePositionerDescriptor>, IUserDataStorer, IVisitableTree
    {
        Matrix4x4 Pose
        {
            get;
            set;
        }

        ISingleFactory<IShape> ShapeFactory { get; }
    }
}
