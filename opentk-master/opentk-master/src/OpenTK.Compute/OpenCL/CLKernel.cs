using System;

namespace OpenTK.Compute.OpenCL
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public readonly struct CLKernel : IEquatable<CLKernel>
    {
        public readonly IntPtr Handle;

        public CLKernel(IntPtr handle)
        {
            Handle = handle;
        }

        public bool Equals(CLKernel other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is CLKernel other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Handle);
        }

        public static bool operator ==(CLKernel left, CLKernel right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CLKernel left, CLKernel right)
        {
            return !(left == right);
        }

        public static implicit operator IntPtr(CLKernel kernel) => kernel.Handle;
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
