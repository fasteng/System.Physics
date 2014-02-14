namespace System.Physics.Shapes.Descriptors
{
    public struct CapsuleShapeDescriptor : System.Physics.IDescriptor
    {
        public CapsuleShapeDescriptor(float radius, float height, object userData = null) : this()
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
           Radius = 1;
           UserData = null;
       }

        public object UserData { get; set; }
    }
}