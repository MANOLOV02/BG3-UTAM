using System;

namespace OpenTK.Compute.OpenCL
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public readonly struct CLProgram : IEquatable<CLProgram>
    {
        public readonly IntPtr Handle;

        public CLProgram(IntPtr handle)
        {
            Handle = handle;
        }

        public bool Equals(CLProgram other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is CLProgram other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Handle);
        }

        public static bool operator ==(CLProgram left, CLProgram right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CLProgram left, CLProgram right)
        {
            return !(left == right);
        }

        public static implicit operator IntPtr(CLProgram program) => program.Handle;
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
