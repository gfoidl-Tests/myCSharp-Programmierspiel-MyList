using System;
using System.Diagnostics;

namespace Inflames2K
{
    internal static class ThrowHelper
    {
        public static void ThrowArgumentOutOfRange(ExceptionArgument argument)
            => throw new ArgumentOutOfRangeException(GetArgumentName(argument));
        //---------------------------------------------------------------------
        private static string GetArgumentName(ExceptionArgument argument)
        {
            Debug.Assert(
                Enum.IsDefined(typeof(ExceptionArgument), argument),
                "The enum value is not defined, check 'ExceptionArgument' enum.");

            return argument.ToString();
        }
        //---------------------------------------------------------------------
        public enum ExceptionArgument
        {
            index
        }
    }
}
