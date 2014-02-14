using System.Physics.Configurations;

namespace System.Physics.Simulators.Configurations
{
    public struct SceneDelimitationConfiguration : IConfiguration<ISimulator>
    {
        public float SceneWidthX { get; set; }
        public float SceneWidthY { get; set; }
        public float SceneWidthZ { get; set; }
        public bool RemoveBodiesOutsideScene { get; set; }
        public void ToDefault()
        {
            throw new NotImplementedException();
        }
    }
}
