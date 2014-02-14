using System.Maths;
using System.Physics.PhysX.Fixtures;
using System.Physics.PhysX.RigidBodies;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;
using StillDesign.PhysX;

namespace System.Physics.PhysX.Shapes
{
    //internal class CapsuleShape : BaseCapsuleShape, ISeteableRealPose
    //{
    //    private PX.CapsuleShape _wrappedCapsuleShape;

    //    public CapsuleShape(RigidBody rigidBody, Matrix4x4 realParentPose, CapsuleShapeDescriptor descriptor)
    //    {
    //        _wrappedCapsuleShape = (PX.CapsuleShape)rigidBody.WrappedActor.CreateShape(new CapsuleShapeDescription(descriptor.Radius, descriptor.Height));
    //        SetRealParentPose(realParentPose);
    //        UserData = descriptor.UserData;
    //        if (rigidBody._hasDefaultShape)
    //        {
    //            rigidBody.WrappedActor.Shapes[0].Dispose();
    //            rigidBody._hasDefaultShape = false;
    //        }
    //    }

    //    public override float Height
    //    {
    //        get { return _wrappedCapsuleShape.Height; }
    //        set { _wrappedCapsuleShape.Height = value; }
    //    }
    //    public override float Radius
    //    {
    //        get { return _wrappedCapsuleShape.Radius; }
    //        set { _wrappedCapsuleShape.Radius = value; }
    //    }
    //    public void SetRealParentPose(Matrix4x4 value)
    //    {
    //        _wrappedCapsuleShape.LocalPose = value.ToPhysX();
    //    }
    //}
}