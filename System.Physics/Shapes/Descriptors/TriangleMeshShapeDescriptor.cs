namespace System.Physics.Shapes.Descriptors
{
    public struct TriangleMeshShapeDescriptor : IDescriptor
    {
        public TriangleMeshShapeDescriptor(object userData = null) : this()
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