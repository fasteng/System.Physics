namespace System.Physics.Shapes.Descriptors
{
    public struct HeightFieldShapeDescriptor : System.Physics.IDescriptor
    {
        public HeightFieldShapeDescriptor(object userData = null)
            : this()
        {
            UserData = userData;
        }

        public void ToDefault()
        {
            UserData = null;
        }

        public object UserData { get; set; }
    }
}