using System.Physics.Factories;

namespace System.Physics.Shapes.Descriptors
{
    public struct BoxShapeDescriptor : System.Physics.IDescriptor
    {
        public BoxShapeDescriptor(float widthX, float widthY, float widthZ, object userData = null) : this()
        {
            WidthX = widthX;
            WidthY = widthY;
            WidthZ = widthZ;
            UserData = userData;
        }

        public float WidthX
        {
            get;
            set;
        }

        public float WidthY
        {
            get;
            set;
        }

        public float WidthZ
        {
            get; set;
        }

        public void ToDefault()
        {
            WidthX = 1;
            WidthY = 1;
            WidthZ = 1;
            UserData = null;
        }

        public object UserData { get; set; }
    }
}
