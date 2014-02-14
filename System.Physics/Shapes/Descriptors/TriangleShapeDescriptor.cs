using System.Maths;

namespace System.Physics.Shapes.Descriptors
{
    public struct TriangleShapeDescriptor : System.Physics.IDescriptor
    {
        public TriangleShapeDescriptor(Vector3 vertexA, Vector3 vertexB, Vector3 vertexC, object userData = null) : this()
        {
            VertexA = vertexA;
            VertexB = vertexB;
            VertexC = vertexC;
            UserData = userData;
        }

        public Vector3 VertexA
        {
            get;
            set;
        }

        public Vector3 VertexB
        {
            get;
            set;
        }

        public Vector3 VertexC
        {
            get;
            set;
        }


        public void ToDefault()
        {
            UserData = null;
            VertexA = new Vector3();
            VertexB = Vectors.XAxis;
            VertexC = Vectors.ZAxis;
        }

        public object UserData { get; set; }
    }
}