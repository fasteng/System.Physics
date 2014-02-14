using System.Maths;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.Shapes.DefaultImplementations
{
    public class DefaultLineSegmentShape : BaseLineSegmentShape
    {
        public DefaultLineSegmentShape(LineSegmentShapeDescriptor descriptor)
        {
            Descriptor = descriptor;
        }

        public override Vector3 StartPoint { get; set; }

        public override Vector3 EndPoint { get; set; }

        //todo calcular la longitud y su cuadrado dados el start y el end
        public override float Length
        {
            get { throw new NotImplementedException(); }
        }

        public override float LengthSquared
        {
            get { throw new NotImplementedException(); }
        }
    }
}