namespace System.Physics.Shapes.Descriptors
{
    public struct CylinderShapeDescriptor : System.Physics.IDescriptor
    {
        public CylinderShapeDescriptor(float radius, float height, object userData = null) : this()
        {
            Height = height;
            UserData = userData;
            Radius = radius;
        }

        public float Height
        {
            get;
            set;
        }

        public float Radius
        {
            get;
            set;
        }

        public void ToDefault()
        {
            Height = 1;
            Radius = 0.5f;
            UserData = null;
        }

        public object UserData { get; set; }
    }
}