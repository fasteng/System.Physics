using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Physics;
using System.Physics.Factories;
using System.Physics.RigidBodies;
using System.Physics.Constraints;
using System.Physics.Constraints.Descriptors;
using System.Physics.DigitalRune.Simulators;
using System.Physics.PhysX.Simulators;
using System.Physics.Fixtures;
using System.Physics.Materials;
using System.Physics.RigidBodies;
using System.Physics.Shapes;
using System.Physics.Shapes.DefaultImplementations;
using System.Physics.Shapes.Descriptors;
using System.Physics.Simulators;
using System.Rendering.Effects;
using System.Rendering.Forms;
using System.Windows.Forms;
using System.Rendering;
using System.Physics.PhysX.Simulators;
using System.Maths;
using Vector3 = System.Maths.Vector3;


namespace Tutorials.MyFirstScene
{
    public partial class Form1 : Form 
    {
        private ISimulator _simulator;
        private int _startTickCount;
        private int _framesCount;
        private int _previousTickCount;
        readonly Dictionary<IShape,IModel> _allocatedModels = new Dictionary<IShape, IModel>();
        private IControlRenderDevice _render;
        private List<IRigidBody> _forceBodies;
        private RenderingVisitor _renderingVisitor;

        public Form1()
        {
            InitializeComponent();
            renderedControl1.Render = new System.Rendering.Direct3D9.Direct3DRender();
        }

        private void renderedControl1_InitializeRender(object sender, RenderEventArgs e)
        {
            _render = e.Render;
            _renderingVisitor = new RenderingVisitor(_render);
            _simulator = new DigitalRuneSimulator();
            _simulator.AddForceEffect(new GravityForceEffect());

            Samples.SetSimpleScene(_simulator);

            _previousTickCount = Environment.TickCount;
            _startTickCount = _previousTickCount;
        }

        private void renderedControl1_Rendered(object sender, RenderEventArgs e)
        {
            int tickCount = Environment.TickCount;
            float deltaTime = (tickCount - _previousTickCount) / 1000f;
            _previousTickCount = tickCount;
            
            _simulator.Update(deltaTime);
            _framesCount++;
            int secondsCount = (tickCount - _startTickCount)/1000;
            if(secondsCount != 0)
                label.Text = String.Format("FPS: {0}", _framesCount / secondsCount);        

            //draw scene 
            var render = e.Render;
            render.BeginScene();

            render.Draw(() =>
                {
                    _simulator.ActorsFactory.AcceptVisit(_renderingVisitor);
                },
                Lights.Point(new Vector3(0, 5, -6), new Vector3(1, 1, 1)),
                Cameras.LookAt(new Vector3(0, 15, -30), new Vector3(0, 0, 0), new Vector3(0, 1, 0)),
                Cameras.Perspective(render.GetAspectRatio()),
                Buffers.Clear(0.2f, 0.2f, 0.4f, 1),
                Buffers.ClearDepth(),
                               Shaders.Phong
                );
            render.EndScene();
            renderedControl1.Invalidate();
        }
    }
}
