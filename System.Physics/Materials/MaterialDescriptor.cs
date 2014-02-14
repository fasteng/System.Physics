namespace System.Physics.Materials
{
    public struct MaterialDescriptor : IDescriptor
    {
        public float Friction {get;set;}
        public float Restitution { get; set; }

        public MaterialDescriptor(float friction, float restitution, object userData = null) : this()
        {
            Friction = friction;
            Restitution = restitution;
            UserData = userData;
        }

        public void ToDefault()
        {
            Friction = 0.5f; 
            Restitution = 0.5f; 
            UserData = null;
        }

        public object UserData {get; set; }
    }
}