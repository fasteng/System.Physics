using System;
using System.Collections.Generic;
using System.Linq;
using System.Maths;
using System.Text;

namespace System.Physics
{
    public struct ShapePositionerDescriptor : IDescriptor
    {
        public ShapePositionerDescriptor(Matrix4x4 pose, object userData = null) : this()
        {
            Pose = pose;
            UserData = userData;
        }

        public void ToDefault()
        { 
            Pose = Matrices.I;
            UserData = null;
        }

        public Matrix4x4 Pose { get; set; }

        public object UserData { get; set; }
    }
}
