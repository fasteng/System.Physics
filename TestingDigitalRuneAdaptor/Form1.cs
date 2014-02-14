using System;
using System.Physics.RigidBodies;
using System.Rendering.Effects;
using System.Rendering.Forms;
using System.Windows.Forms;
using System.Rendering;
using StillDesign.PhysX;
using Vector3 = System.Maths.Vector3;
using System.IO;

namespace Tutorials.MyFirstScene
{
    public partial class Form1 : Form
    { 
        private IModel _boxModel;
        private IModel _planeModel;  
        private StreamWriter _output;

        private int _startTickCount;
        private int _prevFrameCount;
        private int _actualFramesCount; //frames count in the actual second
        private int _totalFramesCount;
        private int _secondsCount;

        private const float Friction = 0.5f, Restitution = 0.7f;
        private const int XCount = 8, YCount = 3, ZCount = 3;
        private const float XOffset = 0, YOffset = YCount * YSpace/2 + 6, ZOffset = 0;
        private const float XSpace = 1.5f, YSpace = 1.5f, ZSpace = 1.5f;
        private const float WidthZ = 1, WidthX = 1, WidthY = 1;
        private const float Delta = 1f;

        public Form1()
        {
            InitializeComponent();
            renderedControl1.Render = new System.Rendering.Direct3D9.Direct3DRender();
            _output = new StreamWriter("output.txt");
        }

        private void RenderedControl1InitializeRender(object sender, RenderEventArgs e)
        {
            _boxModel = Models.Cube.Translated(-0.5f, -0.5f, -0.5f).Scaled(1, 1, 1).Allocate(e.Render);
            _planeModel = Models.PlaneXZ.Scaled(10, 5, 5).Allocate(e.Render);

            SetupSimulation();

            //initializing the timer
            _startTickCount = Environment.TickCount;
        }

        private void RenderedControl1Rendered(object sender, RenderEventArgs e)
        {
            var render = e.Render;
            render.BeginScene();
            //---------------------------------------------------

            //
            UpdateScene();

            bool changeSecond = UpdateFps();
            if(changeSecond)
            {
                _output.WriteLine("{0}) FPS: {1}, avg FPS: {2}", _secondsCount-1,_prevFrameCount,_totalFramesCount/_secondsCount);
                _output.Flush();
            }
            DrawScene(e);
            //---------------------------------------------------
            render.EndScene();
            renderedControl1.Invalidate();
        }

        private bool UpdateFps()
        {
            bool changeSecond = false;
            int secondsCount = (Environment.TickCount - _startTickCount) / 1000;

            if(secondsCount > _secondsCount) 
            {
                changeSecond = true;
                _secondsCount = secondsCount;
                _prevFrameCount = _actualFramesCount;
                _actualFramesCount = 0;
            }

            _totalFramesCount++;
            _actualFramesCount++;
            if (secondsCount != 0)
                label.Text = String.Format("FPS avg: {0}, FPS: {1}", _totalFramesCount / secondsCount, _prevFrameCount);

            return changeSecond;
        }

        private void DrawScene(RenderEventArgs e)
        {
            var render = e.Render;
            render.Draw(() =>
                            {
                                DrawScene(render);
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
