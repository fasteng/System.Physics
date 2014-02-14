using System;
using System.Maths;
using System.Physics;
using System.Physics.Constraints;
using System.Physics.Constraints.Descriptors;
using System.Physics.Factories;
using System.Physics.Fixtures;
using System.Physics.Materials;
using System.Physics.RigidBodies;
using System.Physics.Shapes;
using System.Physics.Shapes.Descriptors;
using System.Physics.Simulators;
using System.Physics.Simulators.Configurations;
using System.Physics.RigidBodies.Configurations;

using System.Rendering;
using System.Rendering.Effects;
using SimulatorCcdConfiguration = System.Physics.Simulators.Configurations.CcdConfiguration;
using RigidBodyCcdConfiguration = System.Physics.RigidBodies.Configurations.CcdConfiguration;


namespace Tutorials.MyFirstScene
{
    public static class Samples
    {
        #region Private

        private static readonly Random _random = new Random();
        private static Material _motionColor = Materials.MediumVioletRed.Shinness.Shinness.Glossy.Glossy;
        private static Material _groundColor = Materials.CadetBlue.Shinness.Shinness.Glossy.Glossy;

        private static Random Random
        {
            get { return _random; }
        }

        private static IRigidBody SetSnowman(ISimulator simulator, Matrix4x4 pose)
        {
            var rigidBody = simulator.ActorsFactory.CreateRigidBody(new RigidBodyDescriptor(MotionType.Dynamic, pose));

            var fixtureDescriptor = new FixtureDescriptor(Matrices.I);
            var compositeFixture = rigidBody.FixtureFactory.CreateCompositeFixture(fixtureDescriptor);

            //head
            var simpleFixture = compositeFixture.FixtureFactory.CreateSimpleFixture(
                new FixtureDescriptor(Matrices.Translate(0, 4f, 0)));
            simpleFixture.ShapeFactory.CreateSphere(new SphereShapeDescriptor(0.7f));

            //body
            simpleFixture = compositeFixture.FixtureFactory.CreateSimpleFixture(
                new FixtureDescriptor(Matrices.Translate(0, 3, 0)));
            simpleFixture.ShapeFactory.CreateSphere(new SphereShapeDescriptor(1));

            //legs?
            simpleFixture = compositeFixture.FixtureFactory.CreateSimpleFixture(
                new FixtureDescriptor(Matrices.Translate(0, 1.5f, 0)));
            simpleFixture.ShapeFactory.CreateSphere(new SphereShapeDescriptor(1.5f));
            rigidBody.MassFrame.UpdateFromShape();
            return rigidBody;
        }

        private static IRigidBody SetSimpleRigidBody<TShape, TShapeDescriptor>(ISimulator simulator,
                                                                               RigidBodyDescriptor rigidBodyDescriptor,
                                                                               TShapeDescriptor descriptor,
                                                                               MaterialDescriptor materialDescriptor)
            where TShape : IShape, IDescriptible<TShapeDescriptor>
            where TShapeDescriptor : struct, IDescriptor
        {
            var rigidBody = simulator.ActorsFactory.CreateRigidBody(rigidBodyDescriptor);

            var fixtureDescriptor = new FixtureDescriptor(Matrices.I);
            var simpleFixture = rigidBody.FixtureFactory.CreateSimpleFixture(fixtureDescriptor);

            simpleFixture.ShapeFactory.Create<TShape, TShapeDescriptor>(descriptor);
            simpleFixture.MaterialFactory.CreateMaterial(materialDescriptor);

            rigidBody.MassFrame.UpdateFromShape();
            return rigidBody;
        }

        private static void SetGround(ISimulator simulator, MaterialDescriptor materialDescriptor)
        {
            var groundRigidBody =
                simulator.ActorsFactory.CreateRigidBody(new RigidBodyDescriptor(MotionType.Static, Matrices.I));
            var groundSimpleFixture =
                groundRigidBody.FixtureFactory.CreateSimpleFixture(new FixtureDescriptor(Matrices.I));
            groundSimpleFixture.ShapeFactory.CreatePlane(new PlaneShapeDescriptor(new Vector3(0, 1, 0), 0));
            groundSimpleFixture.MaterialFactory.CreateMaterial(materialDescriptor);

            if (groundRigidBody.UserData == null)
                groundRigidBody.UserData = _groundColor;
        }

        #endregion

        public static void SetSimpleScene(ISimulator simulator)
        {
            #region Create a box

            //create a rigidBody
            var boxRigidBodyDescriptor = new RigidBodyDescriptor(MotionType.Dynamic, Matrices.Translate(0, 10, 0));
            var boxRigidBody = simulator.ActorsFactory.CreateRigidBody(boxRigidBodyDescriptor);

            //create a simple fixture for the rigidBody
            var fixtureDescriptor = new FixtureDescriptor(Matrices.I);
            var simpleFixture = boxRigidBody.FixtureFactory.CreateSimpleFixture(fixtureDescriptor);

            //define the shape for the simple fixture
            var boxShapeDescriptor = new BoxShapeDescriptor(3, 3, 3, _motionColor);
            simpleFixture.ShapeFactory.CreateBox(boxShapeDescriptor);

            //define the material for the simple fixture  
            var materialDescriptor = new MaterialDescriptor(friction: 0.5f, restitution: 0.6f);
            simpleFixture.MaterialFactory.CreateMaterial(materialDescriptor);
            boxRigidBody.MassFrame.UpdateFromShape();

            #endregion

            #region Create a plane for the ground

            var groundRigidBody =
                simulator.ActorsFactory.CreateRigidBody(new RigidBodyDescriptor(MotionType.Static, Matrices.I));
            var groundSimpleFixture =
                groundRigidBody.FixtureFactory.CreateSimpleFixture(new FixtureDescriptor(Matrices.I));
            groundSimpleFixture.ShapeFactory.CreatePlane(new PlaneShapeDescriptor(Vectors.YAxis, 0, _groundColor));
            groundSimpleFixture.MaterialFactory.CreateMaterial(materialDescriptor);

            #endregion
        }

        public static void SetDominoScene(ISimulator simulator)
        {
            const int levelsCount = 5;
            const int dominoesCount = 10;
            const float alphaGrad = 30;

            //ball
            SetSimpleRigidBody<ISphereShape, SphereShapeDescriptor>(simulator,
                                                                    new RigidBodyDescriptor(MotionType.Dynamic,
                                                                                            GMath.mul(
                                                                                                Matrices.Translate(-20,
                                                                                                                   1f, 0),
                                                                                                Matrices.RotateZGrad(
                                                                                                    alphaGrad))),
                                                                    new SphereShapeDescriptor(1f, _motionColor),
                                                                    new MaterialDescriptor(friction: 0.9f,
                                                                                           restitution: 0.1f));

            //dominoes
            for (int i = 0; i < dominoesCount; i++)
                SetSimpleRigidBody<IBoxShape, BoxShapeDescriptor>(simulator,
                                                                  new RigidBodyDescriptor(MotionType.Dynamic,
                                                                                          Matrices.Translate(
                                                                                              1.7f * i + 3.6f, 1f, 0)),
                                                                  new BoxShapeDescriptor(0.2f, 2, 1),
                                                                  new MaterialDescriptor(friction: 0.9f,
                                                                                         restitution: 0.7f));


            //castle
            for (int i = 0; i < levelsCount; i++)
            {
                //wall left
                SetSimpleRigidBody<IBoxShape, BoxShapeDescriptor>(simulator,
                                                                  new RigidBodyDescriptor(MotionType.Dynamic,
                                                                                          Matrices.Translate(1,
                                                                                                             i * 2.2f + 1f,
                                                                                                             0)),
                                                                  new BoxShapeDescriptor(0.2f, 2, 1),
                                                                  new MaterialDescriptor(friction: 0.9f,
                                                                                         restitution: 0.7f));

                //wall right
                SetSimpleRigidBody<IBoxShape, BoxShapeDescriptor>(simulator,
                                                                  new RigidBodyDescriptor(MotionType.Dynamic,
                                                                                          Matrices.Translate(2.3f,
                                                                                                             i * 2.2f + 1f,
                                                                                                             0)),
                                                                  new BoxShapeDescriptor(0.2f, 2, 1),
                                                                  new MaterialDescriptor(friction: 0.9f,
                                                                                         restitution: 0.7f));

                //floor
                SetSimpleRigidBody<IBoxShape, BoxShapeDescriptor>(simulator,
                                                                  new RigidBodyDescriptor(MotionType.Dynamic,
                                                                                          Matrices.Translate(
                                                                                              2.3f / 2 + 0.5f,
                                                                                              i * 2.2f + 2.1f, 0)),
                                                                  new BoxShapeDescriptor(2, 0.2f, 1),
                                                                  new MaterialDescriptor(friction: 0.9f,
                                                                                         restitution: 0.7f));
            }

            //inclined ground
            var groundRigidBody =
                simulator.ActorsFactory.CreateRigidBody(new RigidBodyDescriptor(MotionType.Static, Matrices.I));
            var fixtureDescriptor = new FixtureDescriptor(Matrices.RotateZGrad(alphaGrad));
            var simpleFixture = groundRigidBody.FixtureFactory.CreateSimpleFixture(fixtureDescriptor);
            simpleFixture.ShapeFactory.Create<IPlaneShape, PlaneShapeDescriptor>(new PlaneShapeDescriptor(
                                                                                     Vectors.YAxis, 0, _groundColor));
            simpleFixture.MaterialFactory.CreateMaterial(new MaterialDescriptor(friction: 0.05f, restitution: 0.5f));
            groundRigidBody.MassFrame.UpdateFromShape();

            //straight plane
            SetSimpleRigidBody<IPlaneShape, PlaneShapeDescriptor>(simulator,
                                                                  new RigidBodyDescriptor(MotionType.Static, Matrices.I),
                                                                  new PlaneShapeDescriptor(Vectors.YAxis, 0,
                                                                                           _groundColor),
                                                                  new MaterialDescriptor(friction: 0.9f,
                                                                                         restitution: 0.7f));
        }

        public static void SetRestitutionScene(ISimulator simulator)
        {
            const int maxI = 10;
            const float yOffset = 10;

            for (int i = 0; i <= maxI; i++)
                SetSimpleRigidBody<ISphereShape, SphereShapeDescriptor>(simulator,
                                                                        new RigidBodyDescriptor(MotionType.Dynamic,
                                                                                                Matrices.Translate(
                                                                                                    2 * i - maxI, yOffset,
                                                                                                    0), _motionColor),
                                                                        new SphereShapeDescriptor(0.5f),
                                                                        new MaterialDescriptor(friction: 0.5f,
                                                                                               restitution: i * 1f / maxI));
            SetGround(simulator, new MaterialDescriptor(friction: 0.5f, restitution: 1f));
        }

        public static void SetFrictionScene(ISimulator simulator)
        {
            const int maxI = 8;
            const float alphaGrad = 33;

            for (int i = 0; i <= maxI; i++)
                SetSimpleRigidBody<IBoxShape, BoxShapeDescriptor>(simulator,
                                                                  new RigidBodyDescriptor(MotionType.Dynamic,
                                                                                          GMath.mul(
                                                                                              Matrices.Translate(
                                                                                                  2 * i - maxI, 0.5f, 0),
                                                                                              Matrices.RotateZGrad(
                                                                                                  alphaGrad))),
                                                                  new BoxShapeDescriptor(1, 1, 1, _motionColor),
                                                                  new MaterialDescriptor(friction: (maxI - i) * 1f / maxI,
                                                                                         restitution: 0.5f));

            //create inclined ground
            var groundRigidBody =
                simulator.ActorsFactory.CreateRigidBody(new RigidBodyDescriptor(MotionType.Static, Matrices.I));
            var fixtureDescriptor = new FixtureDescriptor(Matrices.RotateZGrad(alphaGrad));
            var simpleFixture = groundRigidBody.FixtureFactory.CreateSimpleFixture(fixtureDescriptor);
            simpleFixture.ShapeFactory.Create<IPlaneShape, PlaneShapeDescriptor>(new PlaneShapeDescriptor(
                                                                                     Vectors.YAxis, 0, _groundColor));
            simpleFixture.MaterialFactory.CreateMaterial(new MaterialDescriptor(friction: 0.0f, restitution: 0.5f));
            groundRigidBody.MassFrame.UpdateFromShape();
        }

        public static void SetCompositeScene(ISimulator simulator)
        {
            for (int i = 0; i < 1; i++)
            {
                var rigidBodyDescriptor = new RigidBodyDescriptor(MotionType.Dynamic,
                                                                  GMath.mul(Matrices.RotateZGrad(-20),
                                                                            Matrices.Translate(0, 20 * i + 7, 0)),
                                                                  _motionColor);
                var rigidBody = simulator.ActorsFactory.CreateRigidBody(rigidBodyDescriptor);

                var fixtureDescriptor = new FixtureDescriptor(Matrices.I);
                var compositeFixture = rigidBody.FixtureFactory.CreateCompositeFixture(fixtureDescriptor);

                var simpleFixture =
                    compositeFixture.FixtureFactory.CreateSimpleFixture(
                        new FixtureDescriptor(Matrices.Translate(0, 2.5f, 0)));
                simpleFixture.ShapeFactory.CreateBox(new BoxShapeDescriptor(1, 5, 1));
                simpleFixture.MaterialFactory.CreateMaterial(new MaterialDescriptor(friction: 0.5f, restitution: 0f));


                simpleFixture =
                    compositeFixture.FixtureFactory.CreateSimpleFixture(
                        new FixtureDescriptor(Matrices.Translate(0, 2.5f, 5)));
                simpleFixture.ShapeFactory.CreateBox(new BoxShapeDescriptor(1, 5, 1));
                simpleFixture.MaterialFactory.CreateMaterial(new MaterialDescriptor(friction: 0.5f, restitution: 0f));

                simpleFixture =
                    compositeFixture.FixtureFactory.CreateSimpleFixture(
                        new FixtureDescriptor(Matrices.Translate(5, 2.5f, 0)));
                simpleFixture.ShapeFactory.CreateBox(new BoxShapeDescriptor(1, 5, 1));
                simpleFixture.MaterialFactory.CreateMaterial(new MaterialDescriptor(friction: 0.5f, restitution: 1f));

                simpleFixture =
                    compositeFixture.FixtureFactory.CreateSimpleFixture(
                        new FixtureDescriptor(Matrices.Translate(5, 2.5f, 5)));
                simpleFixture.ShapeFactory.CreateBox(new BoxShapeDescriptor(1, 5, 1));
                simpleFixture.MaterialFactory.CreateMaterial(new MaterialDescriptor(friction: 0.5f, restitution: 1f));

                simpleFixture =
                    compositeFixture.FixtureFactory.CreateSimpleFixture(
                        new FixtureDescriptor(Matrices.Translate(2.5f, 5.1f, 2.5f)));
                simpleFixture.ShapeFactory.CreateBox(new BoxShapeDescriptor(6, 0.2f, 6));

                simpleFixture =
                    compositeFixture.FixtureFactory.CreateSimpleFixture(
                        new FixtureDescriptor(Matrices.Translate(5.5f, 8f, 2.5f)));
                simpleFixture.ShapeFactory.CreateBox(new BoxShapeDescriptor(0.2f, 6, 6));
                simpleFixture.MaterialFactory.CreateMaterial(new MaterialDescriptor(friction: 0.5f, restitution: 1f));

                rigidBody.MassFrame.UpdateFromShape();
            }
            SetGround(simulator, new MaterialDescriptor(friction: 0.5f, restitution: 1f));
        }

        public static void SetMassFrameScene(ISimulator simulator)
        {
            SetSimpleRigidBody<IBoxShape, BoxShapeDescriptor>(simulator,
                                                              new RigidBodyDescriptor(MotionType.Dynamic,
                                                                                      Matrices.Translate(0, 20, -1),
                                                                                      _motionColor),
                                                              new BoxShapeDescriptor(2f, 2f, 2f),
                                                              new MaterialDescriptor(1, 0.5f));

            var snowman = SetSnowman(simulator, GMath.mul(Matrices.RotateZGrad(35), Matrices.Translate(0, 0.5f, 0)));
            snowman.MassFrame.SetPose(Matrices.Translate(0, -0.05f, 0));

            SetGround(simulator, new MaterialDescriptor(1, 0.5f));
        }

        public static void SetConstraintsScene(ISimulator simulator)
        {
            float heigth = 5;
            for (int i = 0; i < 2; i++)
            {
                #region body parts

                //head
                IRigidBody head =
                    SetSimpleRigidBody<ISphereShape, SphereShapeDescriptor>(simulator,
                                                                            new RigidBodyDescriptor(MotionType.Dynamic,
                                                                                                    Matrices.Translate(
                                                                                                        0,
                                                                                                        heigth * i + 4.5f,
                                                                                                        0)),
                                                                            new SphereShapeDescriptor(0.5f),
                                                                            new MaterialDescriptor(friction: 1f,
                                                                                                   restitution: 0.1f));

                //torso
                IRigidBody torso =
                    SetSimpleRigidBody<IBoxShape, BoxShapeDescriptor>(simulator,
                                                                      new RigidBodyDescriptor(MotionType.Dynamic,
                                                                                              Matrices.Translate(0,
                                                                                                                 heigth *
                                                                                                                 i + 3,
                                                                                                                 0)),
                                                                      new BoxShapeDescriptor(1.4f, 1.9f, 0.5f),
                                                                      new MaterialDescriptor(friction: 1f,
                                                                                             restitution: 0.7f));

                //left arm
                IRigidBody leftArm =
                    SetSimpleRigidBody<IBoxShape, BoxShapeDescriptor>(simulator,
                                                                      new RigidBodyDescriptor(MotionType.Dynamic,
                                                                                              Matrices.Translate(-1,
                                                                                                                 heigth *
                                                                                                                 i + 3f,
                                                                                                                 0)),
                                                                      new BoxShapeDescriptor(0.5f, 2f, 0.5f),
                                                                      new MaterialDescriptor(friction: 1f,
                                                                                             restitution: 0.7f));
                //righ arm
                IRigidBody rightArm =
                    SetSimpleRigidBody<IBoxShape, BoxShapeDescriptor>(simulator,
                                                                      new RigidBodyDescriptor(MotionType.Dynamic,
                                                                                              Matrices.Translate(1,
                                                                                                                 heigth *
                                                                                                                 i + 3f,
                                                                                                                 0)),
                                                                      new BoxShapeDescriptor(0.5f, 2f, 0.5f),
                                                                      new MaterialDescriptor(friction: 1f,
                                                                                             restitution: 0.7f));

                //left leg
                IRigidBody leftLeg =
                    SetSimpleRigidBody<IBoxShape, BoxShapeDescriptor>(simulator,
                                                                      new RigidBodyDescriptor(MotionType.Dynamic,
                                                                                              Matrices.Translate(-0.5f,
                                                                                                                 heigth *
                                                                                                                 i + 1,
                                                                                                                 0)),
                                                                      new BoxShapeDescriptor(0.5f, 2f, 0.5f),
                                                                      new MaterialDescriptor(friction: 1f,
                                                                                             restitution: 0.7f));

                //right leg
                IRigidBody rightLeg =
                    SetSimpleRigidBody<IBoxShape, BoxShapeDescriptor>(simulator,
                                                                      new RigidBodyDescriptor(MotionType.Dynamic,
                                                                                              Matrices.Translate(0.5f,
                                                                                                                 heigth *
                                                                                                                 i + 1,
                                                                                                                 0)),
                                                                      new BoxShapeDescriptor(0.5f, 2f, 0.5f),
                                                                      new MaterialDescriptor(friction: 1f,
                                                                                             restitution: 0.7f));

                #endregion

                #region constraints

                //neck
                simulator.ConstraintsFactory.CreateSphericalJoint(
                    new SphericalJointDescriptor(
                        new Vector3(0, -0.5f, 0),
                        new Vector3(0, 1f, 0),
                        head, torso));

                //left shoulder
                simulator.ConstraintsFactory.CreateSphericalJoint(
                    new SphericalJointDescriptor(
                        new Vector3(0, 0.75f, 0),
                        new Vector3(-1, 0.75f, 0),
                        leftArm, torso));

                //right shoulder
                simulator.ConstraintsFactory.CreateSphericalJoint(
                    new SphericalJointDescriptor(
                        new Vector3(0, 0.75f, 0),
                        new Vector3(1, 0.75f, 0),
                        rightArm, torso));

                //left hip
                simulator.ConstraintsFactory.CreateSphericalJoint(
                    new SphericalJointDescriptor(
                        new Vector3(0, 1f, 0),
                        new Vector3(-0.5f, -1, 0),
                        leftLeg, torso));

                //right hip
                simulator.ConstraintsFactory.CreateSphericalJoint(
                    new SphericalJointDescriptor(
                        new Vector3(0, 1f, 0),
                        new Vector3(0.5f, -1, 0),
                        rightLeg, torso));

                #endregion
            }

            //plane
            SetGround(simulator, new MaterialDescriptor(friction: 1f, restitution: 0.7f));
        }

        public static void SetForceEffectScene(ISimulator simulator)
        {
            int echelonCount = 7;
            var chain = new IRigidBody[echelonCount];
            for (int i = 0; i < echelonCount; i++)
            {
                chain[i] = SetSimpleRigidBody<ISphereShape, SphereShapeDescriptor>(simulator, new RigidBodyDescriptor(i == 0 ? MotionType.Static : MotionType.Dynamic, Matrices.Translate(-i, 10, 0), _motionColor), new SphereShapeDescriptor(0.4f), new MaterialDescriptor(0.5f, 0.5f));
                if (i > 0)
                {
                    simulator.ConstraintsFactory.CreateSphericalJoint(
                        new SphericalJointDescriptor(
                            new Vector3(1f, 0, 0), new Vector3(), chain[i], chain[i - 1]));
                }
            }

            for (int i = 0; i < 2 * echelonCount; i++)
            {
                SetSimpleRigidBody<IBoxShape, BoxShapeDescriptor>(simulator, new RigidBodyDescriptor(MotionType.Dynamic, Matrices.Translate(-i, (i + 1) * 0.1f / 2, 10), _motionColor), new BoxShapeDescriptor((i + 1) * 0.1f, (i + 1) * 0.1f, (i + 1) * 0.1f), new MaterialDescriptor(0.5f, 0.5f));
            }

            simulator.AddForceEffect(new AttractionForceEffect(chain[echelonCount - 1]));

            SetGround(simulator, new MaterialDescriptor(0.5f, 0.5f));


        }

        public static void SetBulletScene(ISimulator simulator)
        {
            //base
            SetSimpleRigidBody<IBoxShape, BoxShapeDescriptor>(
                simulator, 
                new RigidBodyDescriptor(MotionType.Dynamic, Matrices.Translate(0,0.5f,0), _motionColor), 
                new BoxShapeDescriptor(1,1,1), 
                new MaterialDescriptor(0.5f, 0.5f));

            //board
            SetSimpleRigidBody<IBoxShape, BoxShapeDescriptor>(
                simulator,
                new RigidBodyDescriptor(MotionType.Dynamic, Matrices.Translate(3, 0.5f + 0.0001f/2, 0), _motionColor),
                new BoxShapeDescriptor(10, 0.00005f, 1),
                new MaterialDescriptor(0.5f, 0.5f));

            //bullet
            var bullet = SetSimpleRigidBody<ISphereShape, SphereShapeDescriptor>(simulator, 
                new RigidBodyDescriptor(MotionType.Dynamic, Matrices.Translate(-1, 200f, 0), _motionColor),
                new SphereShapeDescriptor(0.1f), new MaterialDescriptor(0.5f, 0.5f));

            //simulator.Configurator.Set(new SimulatorCcdConfiguration(true));
            //bullet.Configurator.Set(new RigidBodyCcdConfiguration(true));

            SetGround(simulator, new MaterialDescriptor(0.5f, 0.5f));
        }
    }
}