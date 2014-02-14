using System;
using System.Collections.Generic;
using System.Linq;
using System.Maths;
using System.Text;

namespace System.Physics
{
    public static class MatricesExtensors
    {
        public static Matrix4x4 ToGlobalPose(this Matrix4x4 pose, Matrix4x4 localPose)
        {
            return GMath.mul(localPose, pose);
        }

        public static Matrix4x4 ToLocalPose(this Matrix4x4 pose, Matrix4x4 globalPose)
        {
            return GMath.mul(globalPose, pose.Inverse);
        }

        //private Vector3 ToLocalPosition(Vector3 vector)
        //{
        //    return _digitalRuneRigidBody.WrappedRigidBody.LocalPose.ToLocalPosition(vector.ToDigitalRune()).ToStandard();
        //}

        //private Vector3 ToLocalDirection(Vector3 vector)
        //{
        //    return _digitalRuneRigidBody.WrappedRigidBody.LocalPose.ToLocalDirection(vector.ToDigitalRune()).ToStandard();
        //}

        public static Matrix3x3 ExtractOrientation(this Matrix4x4 pose)
        {
            return new Matrix3x3(pose.M00, pose.M01, pose.M02,
                                 pose.M10, pose.M11, pose.M12,
                                 pose.M20, pose.M21, pose.M22);
        }

        public static Vector3 ExtractPosition(this Matrix4x4 pose)
        {
            return new Vector3(pose.M30, pose.M31, pose.M32);
        }

        public static Vector3 ToLocalDirection(this Matrix4x4 pose, Vector3 globalDirection)
        {
            Vector3 result;
            result.X = pose.M00 * globalDirection.X + pose.M10 * globalDirection.Y + pose.M20 * globalDirection.Z + pose.M30;
            result.Y = pose.M01 * globalDirection.X + pose.M11 * globalDirection.Y + pose.M21 * globalDirection.Z + pose.M31;
            result.Z = pose.M02 * globalDirection.X + pose.M12 * globalDirection.Y + pose.M22 * globalDirection.Z + pose.M32;
            return result;
        }

        public static Vector3 ToLocalPosition(this Matrix4x4 pose, Vector3 globalPosition)
        {
            Vector3 difference = globalPosition - pose.ExtractPosition(); 
            Vector3 result;
            result.X = pose.M00 * difference.X + pose.M01 * difference.Y + pose.M02 * difference.Z + difference.X;
            result.Y = pose.M10 * difference.X + pose.M11 * difference.Y + pose.M12 * difference.Z + difference.Y;
            result.Z = pose.M20 * difference.X + pose.M21 * difference.Y + pose.M22 * difference.Z + difference.Z;
            return result;
        }

        public static Vector3 ToGlobalDirection(this Matrix4x4 pose, Vector3 localDirection)
        {
            Vector3 result;
            result.X = pose.M00 * localDirection.X + pose.M10 * localDirection.Y + pose.M20 * localDirection.Z;
            result.Y = pose.M01 * localDirection.X + pose.M11 * localDirection.Y + pose.M21 * localDirection.Z;
            result.Z = pose.M02 * localDirection.X + pose.M12 * localDirection.Y + pose.M22 * localDirection.Z;
            return result;
        }

        public static Vector3 ToGlobalPosition(this Matrix4x4 pose, Vector3 localDirection)
        {
            //Vector3 result;
            //result.X = pose.M00 * globalDirection.X + pose.M01 * globalDirection.Y + pose.M02 * globalDirection.Z;
            //result.Y = pose.M10 * globalDirection.X + pose.M11 * globalDirection.Y + pose.M12 * globalDirection.Z;
            //result.Z = pose.M20 * globalDirection.X + pose.M21 * globalDirection.Y + pose.M22 * globalDirection.Z;
            //return result;
            throw new NotImplementedException();
        }
    }
}
