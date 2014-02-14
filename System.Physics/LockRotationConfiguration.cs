using System;
using System.Collections.Generic;
using System.Linq;
using System.Physics.RigidBodies;
using System.Physics.Configurations;
using System.Text;

namespace System.Physics
{
    public struct LockRotationConfiguration : IConfiguration<IRigidBody>
    {
        public LockRotationConfiguration(bool lockRotationX, bool lockRotationY, bool lockRotationZ) : this()
        {
            LockRotationX = lockRotationX;
            LockRotationY = lockRotationY;
            LockRotationZ = lockRotationZ;
        }

        public bool LockRotationX { get; set; }
        public bool LockRotationY { get; set; }
        public bool LockRotationZ { get; set; }

        public void ToDefault()
        {
            LockRotationX = false;
            LockRotationY = false;
            LockRotationZ = false;
        }
    }
}
