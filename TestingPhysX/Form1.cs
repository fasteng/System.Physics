using System;
using System.Maths;
using System.Rendering.Effects;
using System.Rendering.Forms;
using System.Windows.Forms;
using System.Rendering;
using StillDesign.PhysX;
using Nx = StillDesign.PhysX;
using NxVector3 = StillDesign.PhysX.MathPrimitives.Vector3;
using NxMath = StillDesign.PhysX.MathPrimitives;
using Vector3 = System.Maths.Vector3;


namespace Tutorials.MyFirstScene
{
    public partial class Form1 : Form
    {
        private Scene _scene;
        private int _startTickCount;
        private int _totalFramesCount;
        private int _framesCount;
        private int _previousTickCount;
        private IModel _boxModel;
        private IModel _planeModel;
        private int _prevSecondsCount = -1;
        private object _prevFramesCount;

        public Form1()
        {
            InitializeComponent();
            renderedControl1.Render = new System.Rendering.Direct3D9.Direct3DRender();
        }

        private void renderedControl1_InitializeRender(object sender, RenderEventArgs e)
        {
            _boxModel = Models.Cube.Translated(-0.5f, -0.5f, -0.5f).Scaled(1, 1, 1).Allocate(e.Render);
            _planeModel = Models.PlaneXZ.Scaled(1, 1, 1).Allocate (e.Render);

            DigitalRuneAdaptorScene();

            //initializing the timer
            _previousTickCount = Environment.TickCount;
            _startTickCount = _previousTickCount;
        }

        private void DigitalRuneAdaptorScene()
        {
            //creating the simulation
            CreateScene();

            //definig a material
            var materialDesc = new MaterialDescription
                                   {
                                       DynamicFriction = 0.5f,
                                       StaticFriction = 0.5f,
                                       Restitution = 0.7f,
                                       FrictionCombineMode = CombineMode.Average,
                                       RestitutionCombineMode = CombineMode.Average
                                   };
            Nx.Material material = _scene.CreateMaterial(materialDesc);

            //creating the ground
            CreateGround(material);

            ////creating a Tower

            CreateTower(material, new NxVector3(1, 1, 1),
                        xCount: 5, yCount: 5, zCount: 5,
                        xSpace: 2, ySpace: 2, zSpace: 2,
                        xOffset: 0, yOffset: 2 + 10 / 2, zOffset: 0);
        }

        private void CreateScene()
        {
            var coreDesc = new CoreDescription();
            var core = new Core(coreDesc, null);
            var sceneDesc = new SceneDescription
                                {
                                    Gravity = new NxVector3(0, -9.81f, 0),
                                    SimulationType = SimulationType.Software
                                };
            _scene = core.CreateScene(sceneDesc);
        }

        private void CreateTower(Nx.Material material, NxVector3 descriptor, int xCount, int yCount, int zCount, float xSpace, float ySpace, float zSpace, float xOffset, float yOffset, float zOffset)
        {
            for (int x = 0; x < xCount; x++)
                for (int y = 0; y < yCount; y++)
                    for (int z = 0; z < zCount; z++)
                    {
                        var rigidBodyDesc = new BodyDescription();

                        var boxDesc = new BoxShapeDescription
                                          {
                                              Material = material,
                                              Dimensions = new NxVector3(descriptor.X / 2, descriptor.Y / 2, descriptor.Z / 2)
                                          };

                        var actorDesc = new ActorDescription(boxDesc)
                                            {
                                                BodyDescription = rigidBodyDesc,
                                                Density = 10.0f,
                                                GlobalPose = NxMath.Matrix.Translation(
                                                                       xOffset + x * xSpace - ((xCount - 1) * xSpace / 2),
                                                                       yOffset + y * ySpace - ((yCount - 1) * ySpace / 2),
                                                                       zOffset + z * zSpace - ((zCount - 1) * zSpace / 2)),
                                                UserData = _boxModel
                                            };

                        if (!actorDesc.IsValid())
                            throw new Exception("ActorDesc invalid!");

                        var actor = _scene.CreateActor(actorDesc);
                        if (actor == null)
                            throw new Exception("Actor invalid!");
                    }
        }

        private void CreateGround(Nx.Material material)
        {
            var planeShapeDesc = new PlaneShapeDescription(0, 1, 0, 0)
                                     {

                                         Material = material,
                                         UserData = _planeModel
                                     };
            var actorDesc = new ActorDescription(planeShapeDesc) { BodyDescription = null };
            _scene.CreateActor(actorDesc);
        }

        private void renderedControl1_Rendered(object sender, RenderEventArgs e)
        {
            var render = e.Render;
            render.BeginScene();
            //---------------------------------------------------

            int tickCount = UpdateSimulation();
            UpdateFps(tickCount, e);
            DrawScene(e);

            //---------------------------------------------------
            render.EndScene();
            renderedControl1.Invalidate();
        }

        private void UpdateFps(int tickCount, RenderEventArgs e)
        {
            _totalFramesCount++;
            _framesCount++;
            int secondsCount = (tickCount - _startTickCount) / 1000;
            if (secondsCount != 0)
                label.Text = String.Format("FPS avg: {0}, FPS: {1}", _totalFramesCount / secondsCount, _prevFramesCount);
            if (secondsCount > _prevSecondsCount)
            {
                _prevSecondsCount = secondsCount;
                _prevFramesCount = _framesCount;
                _framesCount = 0;

                //DrawScene(e);
            }
        }

        private float delta = 1f / 3;
        private int UpdateSimulation()
        {
            int tickCount = Environment.TickCount;
            float deltaTime = (tickCount - _previousTickCount) / 1000f;
            _previousTickCount = tickCount;
            _scene.Simulate(delta);
            _scene.FlushStream();
            _scene.FetchResults(SimulationStatus.RigidBodyFinished, true);
            return tickCount;
        }

        private void DrawScene(RenderEventArgs e)
        {
            var render = e.Render;
            render.Draw(() =>
                            {
                                DrawPhysX(render);
                            },
                        
                        Lights.Point(new Vector3(0, 5, -6), new Vector3(1, 1, 1)),
                        Cameras.LookAt(new Vector3(0, 15, -30), new Vector3(0, 0, 0), new Vector3(0, 1, 0)),
                        Cameras.Perspective(render.GetAspectRatio()),
                        Buffers.Clear(0.2f, 0.2f, 0.4f, 1),
                        Buffers.ClearDepth(),
                        Shaders.Gouraud
                        
                );
        }

        private void DrawPhysX(IControlRenderDevice render)
        {
            foreach (Actor rigidBody in _scene.Actors)
            {
                render.Draw((IModel)rigidBody.UserData,
                            new Transforming(rigidBody.GlobalPose.ToStandard()),
                            Materials.DeepPink);
            }
        }
    }

    public static class Conversions
    {
        public static Matrix4x4 ToStandard(this NxMath.Matrix matrix)
        {
            return new Matrix4x4(matrix.M11, matrix.M12, matrix.M13, matrix.M14,
                                 matrix.M21, matrix.M22, matrix.M23, matrix.M24,
                                 matrix.M31, matrix.M32, matrix.M33, matrix.M34,
                                 matrix.M41, matrix.M42, matrix.M43, matrix.M44);
        }
    }
}
