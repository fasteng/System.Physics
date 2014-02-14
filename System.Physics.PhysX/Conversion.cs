using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Maths;
using NXMath = StillDesign.PhysX.MathPrimitives;

namespace System.Physics.PhysX
{

    public static class Conversions
    {
        public static Matrix4x4 ToStandard(this NXMath.Matrix matrix)
        {
            return new Matrix4x4(matrix.M11, matrix.M12, matrix.M13, matrix.M14,
                                 matrix.M21, matrix.M22, matrix.M23, matrix.M24,
                                 matrix.M31, matrix.M32, matrix.M33, matrix.M34,
                                 matrix.M41, matrix.M42, matrix.M43, matrix.M44);
        }

        public static NXMath.Matrix ToPhysX(this Matrix4x4 matrix)
        {
            return new NXMath.Matrix(matrix.M00, matrix.M01, matrix.M02, matrix.M03, 
                                     matrix.M10, matrix.M11, matrix.M12, matrix.M13, 
                                     matrix.M20, matrix.M21, matrix.M22, matrix.M23,
                                     matrix.M30, matrix.M31, matrix.M32, matrix.M33);
        }

        public static Vector3 ToStandard(this NXMath.Vector3 vector3)
        {
            return new Vector3(vector3.X, vector3.Y, vector3.Z);
        }

        public static NXMath.Vector3 ToPhysX(this Vector3 vector3)
        {
            return new NXMath.Vector3(vector3.X, vector3.Y, vector3.Z);
        }
    }
}
