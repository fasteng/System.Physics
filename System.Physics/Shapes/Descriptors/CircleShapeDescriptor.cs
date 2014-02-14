namespace System.Physics.Shapes.Descriptors
{
    public struct CircleShapeDescriptor : System.Physics.IDescriptor
    {
        public CircleShapeDescriptor(float radius, object userData = null) : this()
        {
            Radius = radius;
            UserData = userData;
        }

        public float Radius
        {
            get;
            set;
        }

       public void ToDefault()
       {
           Radius = 0.5f;
           UserData = null;
        }

        public object UserData { get; set; }
    }
}