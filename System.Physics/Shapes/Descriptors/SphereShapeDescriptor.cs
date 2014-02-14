namespace System.Physics.Shapes.Descriptors
{
    public struct SphereShapeDescriptor : System.Physics.IDescriptor
    {
        public SphereShapeDescriptor(float radius, object userData = null) : this()
        {
            Radius = radius;
            UserData = userData;
        }

        public float Radius { get; set; }

        public void ToDefault()
        {
            Radius = 0.5f;
            UserData = null;
        }

        public object UserData { get; set; }
    }
}