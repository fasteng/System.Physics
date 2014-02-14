using System;
using System.Physics;
using System.Physics.RigidBodies;
using System.Physics.DigitalRune;
using System.Physics.DigitalRune.Simulators;
using System.Physics.Fixtures;
using System.Physics.Materials;
using System.Physics.Shapes;
using System.Physics.Shapes.Descriptors;
using System.Physics.Simulators;
using System.Rendering.Effects;
using System.Rendering.Forms;
using System.Windows.Forms;
using System.Rendering;
using System.Maths;
using DigitalRune.Geometry;
using DigitalRune.Geometry.Shapes;
using DigitalRune.Mathematics.Algebra;
using DigitalRune.Physics;
using DigitalRune.Physics.ForceEffects;
using DigitalRune.Physics.Materials;
using IMaterial = System.Physics.Materials.IMaterial;
using MotionType = System.Physics.RigidBodies.MotionType;
using Vector3 = System.Maths.Vector3;

namespace Tutorials.MyFirstScene
{
    public partial class Form1 : Form
    {
        private Simulation _simulation;
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
            _planeModel = Models.PlaneXZ.Scaled(1, 1, 1);

            DigitalRuneAdaptorScene();

            //initializing the timer
            _previousTickCount = Environment.TickCount;
            _startTickCount = _previousTickCount;
        }

        private void DigitalRuneAdaptorScene()
        {
            //creating the simulation
            _simulation = new Simulation();
            _simulation.ForceEffects.Add(new Gravity());
            _simulation.ForceEffects.Add(new Damping());

            //definig a material
            var material = new UniformMaterial { StaticFriction = 0.5f, DynamicFriction = 0.5f, Restitution = 0.7f };

            //creating the ground
            CreateGround(material);

            ////creating a Tower

            CreateTower(material, new BoxShapeDescriptor(1, 1, 1),
                        xCount: 3, yCount: 3, zCount: 3,
                        xSpace: 2, ySpace: 2, zSpace: 2,
                        xOffset: 0, yOffset: 2 + 10 / 2, zOffset: 0);
        }

        private void CreateTower(UniformMaterial material, BoxShapeDescriptor descriptor, int xCount, int yCount, int zCount, float xSpace, float ySpace, float zSpace, float xOffset, float yOffset, float zOffset)
        {
            for (int x = 0; x < xCount; x++)
                for (int y = 0; y < yCount; y++)
                    for (int z = 0; z < zCount; z++)
                    {
                        var box = new RigidBody
                                      {
                                          MotionType = DigitalRune.Physics.MotionType.Dynamic,
                                          Pose = new Pose(new Vector3F(xOffset + x * xSpace - ((xCount - 1) * xSpace / 2),
                                                                       yOffset + y * ySpace - ((yCount - 1) * ySpace / 2),
                                                                       zOffset + z * zSpace - ((zCount - 1) * zSpace / 2))),
                                          Shape = new BoxShape(descriptor.WidthX, descriptor.WidthY, descriptor.WidthZ),
                                          Material = material,
                                          UserData = _boxModel
                                      };
                        _simulation.RigidBodies.Add(box);
                    }
        }

        private void CreateGround(UniformMaterial material)
        {
            var ground = new RigidBody
                             {
                                 MotionType = DigitalRune.Physics.MotionType.Static,
                                 Shape = new PlaneShape(new Vector3F(0, 1, 0), 0),
                                 Material = material,
                                 UserData = _planeModel
                             };
            _simulation.RigidBodies.Add(ground);
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

        private float delta = 1f / 60f;
        private int UpdateSimulation()
        {
            int tickCount = Environment.TickCount;
            //float deltaTime = (tickCount - _previousTickCount) / 1000f;
            _previousTickCount = tickCount;
            _simulation.Update(delta);
            return tickCount;
        }

        private void DrawScene(RenderEventArgs e)
        {
            var render = e.Render;
            render.Draw(() =>
                            {
                                foreach (RigidBody rigidBody in _simulation.RigidBodies)
                                {
                                    render.Draw((IModel)rigidBody.UserData,
                                                new Transforming(rigidBody.Pose.ToStandard()),
                                                Materials.DeepPink.Glossy.Shinness.Glossy.Shinness);
                                }
                            },
                        Lights.Point(new Vector3(0, 5, -6), new Vector3(1, 1, 1)),
                        Cameras.LookAt(new Vector3(0, 15, -30), new Vector3(0, 0, 0), new Vector3(0, 1, 0)),
                        Cameras.Perspective(render.GetAspectRatio()),
                        Buffers.Clear(0.2f, 0.2f, 0.4f, 1),
                        Buffers.ClearDepth(), Shaders.Phong
                );
        }
    }
}
