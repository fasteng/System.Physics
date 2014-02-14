//using System.Maths;
//using System.Physics;
//using System.Physics.RigidBodies;
//using System.Physics.DigitalRune.RigidBodies;
//using System.Physics.DigitalRune.Simulators;
//using System.Physics.Factories;
//using System.Physics.Materials;
//using System.Physics.Shapes;
//using System.Physics.Shapes.Descriptors;
//using System.Physics.Simulators;
//using System.Rendering;
//using System.Rendering.Effects;
//using System.Rendering.Forms;
//using DigitalRune.Geometry;
//using DigitalRune.Geometry.Shapes;
//using DigitalRune.Mathematics.Algebra;
//using DigitalRune.Physics.Materials;

//namespace Tutorials.MyFirstScene
//{
//    public partial class Form1
//    {
//        private ISimulator _simulator;

//        private void SetupSimulation()
//        {
//            //creating the simulator
//            _simulator = new Simulator();

//            //definig a material
//            var materialDescriptor = new MaterialDescriptor(Friction, Restitution);

//            //creating the ground
//            CreateGround(materialDescriptor);

//            //creating a boxes
//            CreateBoxes(materialDescriptor);
//        }

//        private void CreateBoxes(MaterialDescriptor materialDescriptor)
//        {
//            var rigidBodyDescriptor = new RigidBodyDescriptor(MotionType.Dynamic, Matrices.I, true);
//            for (int x = 0; x < XCount; x++)
//                for (int y = 0; y < YCount; y++)
//                    for (int z = 0; z < ZCount; z++)
//                    {
//                        rigidBodyDescriptor.LocalPose = Matrices.Translate(XOffset + x * XSpace - ((XCount - 1) * XSpace / 2),
//                                                                      YOffset + y * YSpace - ((YCount - 1) * YSpace / 2),
//                                                                      ZOffset + z * ZSpace - ((ZCount - 1) * ZSpace / 2));

//                        var rigidBody = _simulator.ActorsFactory.CreateRigidBody(rigidBodyDescriptor);

//                        var compositeShape = new CompositeShape(); compositeShape.Children.Add(new GeometricObject(new BoxShape(WidthX, WidthY, WidthZ)));
//                        var transformedShape = new TransformedShape(new GeometricObject(compositeShape));
//                        ((RigidBody)rigidBody).WrappedRigidBody.Shape = transformedShape;//todo borrar
//                        ((RigidBody)rigidBody).WrappedRigidBody.Material = new UniformMaterial { StaticFriction = Friction, DynamicFriction = Friction, Restitution = Restitution }; //todo borrar

//                        //var fixture =
//                        //    rigidBody.FixtureFactory.Create<ISimpleFixture, FixtureDescriptor>(new FixtureDescriptor(Matrices.I));
//                        //fixture.ShapeFactory.Create<TShape, TShapeDescriptor>(descriptor);
//                        //fixture.MaterialFactory.Create<IMaterial, MaterialDescriptor>(materialDescriptor);
//                        rigidBody.UserData = _boxModel;
//                    }
//        }

//        private void CreateGround(MaterialDescriptor materialDescriptor)
//        {
//            var groundRigidBodyDescriptor = new RigidBodyDescriptor(MotionType.Static, Matrices.I, true);
//            var ground = _simulator.ActorsFactory.CreateRigidBody(groundRigidBodyDescriptor);

//            var compositeShape = new CompositeShape(); compositeShape.Children.Add(new GeometricObject(new PlaneShape()));
//            var transformedShape = new TransformedShape(new GeometricObject(compositeShape));
//            ((RigidBody)ground).WrappedRigidBody.Shape = transformedShape;//todo borrar
//            ((RigidBody)ground).WrappedRigidBody.Material = new UniformMaterial { StaticFriction = Friction, DynamicFriction = Friction, Restitution = Restitution }; //todo borrar

//            //var groundFixture = ground.FixtureFactory.Create<ISimpleFixture, FixtureDescriptor>(new FixtureDescriptor(Matrices.I));
//            //groundFixture.ShapeFactory.Create<IPlaneShape, PlaneShapeDescriptor>(new PlaneShapeDescriptor(new Vector3(0, 1, 0), 0));
//            //groundFixture.MaterialFactory.Create<IMaterial, MaterialDescriptor>(materialDescriptor);
//            ground.UserData = _planeModel;
//        }

//        private void UpdateScene()
//        {
//            _simulator.Timing.Update(Delta);
//        }

//        private void DrawScene(IControlRenderDevice render)
//        {

//            foreach (IRigidBody rigidBody in _simulator.ActorsFactory.Elements)
//            {

//                render.Draw((IModel)rigidBody.UserData,
//                            new Transforming(rigidBody.Descriptor.LocalPose),
//                            rigidBody.UserData == _planeModel ?
//                            Materials.Blue :
//                            Materials.Red.Glossy.Shinness.Glossy.Shinness
//                            );

//            }
//        }
//    }
//}