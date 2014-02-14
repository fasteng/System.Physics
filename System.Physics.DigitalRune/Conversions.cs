using System.Maths;
using DigitalRune.Geometry;
using DigitalRune.Mathematics.Algebra;
using DigitalRune.Physics;

namespace System.Physics.DigitalRune
{
    public static class Conversions
    {
        internal static Pose ToDigitalRune(this Matrix4x4 matrix)
        {
            var position = new Vector3F(matrix.M30, matrix.M31, matrix.M32);
            var orientation = new Matrix33F(matrix.M00, matrix.M10, matrix.M20,
                                            matrix.M01, matrix.M11, matrix.M21,
                                            matrix.M02, matrix.M12, matrix.M22);
            return new Pose(position, orientation);
        }

        public  static Matrix4x4 ToStandard(this Pose pose)
        {
            Matrix44F matrix44F = pose.ToMatrix44F();
            return new Matrix4x4(matrix44F.M00, matrix44F.M10, matrix44F.M20, matrix44F.M30,
                                 matrix44F.M01, matrix44F.M11, matrix44F.M21, matrix44F.M31,
                                 matrix44F.M02, matrix44F.M12, matrix44F.M22, matrix44F.M31,
                                 matrix44F.M03, matrix44F.M13, matrix44F.M23, matrix44F.M33);
        }

        internal static Matrix33F ToDigitalRune(this Matrix3x3 matrix)
        {
            return new Matrix33F(matrix.M00, matrix.M10, matrix.M20,
                                 matrix.M01, matrix.M11, matrix.M21,
                                 matrix.M02, matrix.M12, matrix.M22);
        }

        public static Matrix3x3 ToStandard(this Matrix33F matrix)
        {
            return new Matrix3x3(matrix.M00, matrix.M10, matrix.M20,
                                 matrix.M01, matrix.M11, matrix.M21,
                                 matrix.M02, matrix.M12, matrix.M22);
        }

        internal static MotionType ToDigitalRune(this Physics.RigidBodies.MotionType motionType)
        {
            switch (motionType)
            {
                case Physics.RigidBodies.MotionType.Static:
                    return MotionType.Static;
                case Physics.RigidBodies.MotionType.Kinematic:
                    return MotionType.Kinematic; ;
                case Physics.RigidBodies.MotionType.Dynamic:
                    return MotionType.Dynamic; ;
                default:
                    throw new Exception("This method is not up to date. There was a change in the enum MotionType and this method should be changed too.");
            }
        }

        internal static Physics.RigidBodies.MotionType ToStandard(this MotionType motionType)
        {
            switch (motionType)
            {
                case MotionType.Static:
                    return Physics.RigidBodies.MotionType.Static;
                case MotionType.Kinematic:
                    return Physics.RigidBodies.MotionType.Kinematic; ;
                default: // DigitalRuneMotionType.Dynamic:
                    return Physics.RigidBodies.MotionType.Dynamic; ;
            }
        }

        internal static Vector3F ToDigitalRune(this Vector3 vector)
        {
            return new Vector3F(vector.X, vector.Y, vector.Z);
        }

        internal static Vector3 ToStandard(this Vector3F vector)
        {
            return new Vector3(vector.X, vector.Y, vector.Z);
        }

        internal static Vector2F ToDigitalRune(this Vector2 vector)
        {
            return new Vector2F(vector.X, vector.Y);
        }

        internal static Vector2 ToStandard(this Vector2F vector)
        {
            return new Vector2(vector.X, vector.Y);
        }
    }
}