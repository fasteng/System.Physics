namespace System.Physics.Shapes.Descriptors
{
    public struct RectangleShapeDescriptor : System.Physics.IDescriptor
    {
        public RectangleShapeDescriptor(float widthY, float widthX, object userData = null) : this()
        {
            WidthY = widthY;
            WidthX = widthX;
            UserData = userData;
        }

        public float WidthY
        {
            get;
            set;
        }

        public float WidthX
        {
            get;
            set;
        }

        public void ToDefault()
        {
            WidthY = 1;
            WidthX = 1;
            UserData = null;
        }

        public object UserData { get; set; }
    }
}