using System;
using System.Collections.Generic;
using System.Linq;
using System.Maths;
using System.Physics.PhysX;
using System.Rendering;
using System.Rendering.Effects;
using System.Rendering.Forms;
using System.Text;
using StillDesign.PhysX;
using Nx = StillDesign.PhysX;
using NxVector3 = StillDesign.PhysX.MathPrimitives.Vector3;
using NxMath = StillDesign.PhysX.MathPrimitives;


namespace Tutorials.MyFirstScene
{

    public partial class Form1
    {
        private Scene _scene;

        private void SetupSimulation()
        {
            //creating the simulation
            CreateScene();

            //definig a material
            var materialDesc = new MaterialDescription
                                   {
                                       DynamicFriction = Friction,
                                       StaticFriction = Friction,
                                       Restitution = Restitution,
                                       FrictionCombineMode = CombineMode.Average,
                                       RestitutionCombineMode = CombineMode.Average
                                   };
            Nx.Material material = _scene.CreateMaterial(materialDesc);

            CreateGround(material);

            CreateBoxes(material);
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

        private void CreateBoxes(Nx.Material material)
        {
            for (int x = 0; x < XCount; x++)
                for (int y = 0; y < YCount; y++)
                    for (int z = 0; z < ZCount; z++)
                    {
                        var rigidBodyDesc = new BodyDescription();

                        var boxDesc = new BoxShapeDescription
                        {
                            Material = material,
                            Dimensions = new NxVector3(WidthX / 2, WidthY / 2, WidthZ / 2)
                        };

                        var actorDesc = new ActorDescription(boxDesc)
                        {
                            BodyDescription = rigidBodyDesc,
                            Density = 10.0f,
                            GlobalPose = NxMath.Matrix.Translation(
                                                   XOffset + x * XSpace - ((XCount - 1) * XSpace / 2),
                                                   YOffset + y * YSpace - ((YCount - 1) * YSpace / 2),
                                                   ZOffset + z * ZSpace - ((ZCount - 1) * ZSpace / 2)),
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
                                    };
            var actorDesc = new ActorDescription(planeShapeDesc)
                                {
                                    BodyDescription = null,
                                    UserData = _planeModel
                                };
            _scene.CreateActor(actorDesc);
        }

        private void UpdateScene()
        {
            _scene.Simulate(Delta);
            _scene.FlushStream();
            _scene.FetchResults(SimulationStatus.AllFinished, true);
        }

        private void DrawScene(IControlRenderDevice render)
        {
            foreach (Actor rigidBody in _scene.Actors)
            {
                render.Draw((IModel)rigidBody.UserData,
                            new Transforming(rigidBody.GlobalPose.ToStandard()),
                            rigidBody.UserData == _planeModel ?
                                Materials.Blue :
                                Materials.Green.Glossy.Shinness.Glossy.Shinness);
            }
        }
    }
}
