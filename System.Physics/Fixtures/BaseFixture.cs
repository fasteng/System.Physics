using System;
using System.Collections.Generic;
using System.Linq;
using System.Maths;
using System.Physics.Factories;
using System.Physics.Fixtures;
using System.Physics.Materials;
using System.Physics.Shapes;
using System.Physics.Visitor;
using System.Text;

namespace System.Physics.Fixtures
{
    public abstract class BaseFixture : IFixture
    {
        public FixtureDescriptor Descriptor
        {
            get { return new FixtureDescriptor(Pose, UserData); } 
            set 
            { 
                Pose = value.Pose;
                UserData = value.UserData;
            }
        }
        public abstract Matrix4x4 Pose { get; set; }
        public object UserData { get; set; }
        public abstract void AcceptVisit(IVisitor visitor);
    }
}
