using System;
using System.Diagnostics.Contracts;

namespace MathHelperRedux
{
    public static class MathHelper
    {
        /// <summary>
        /// Represents the mathematical constant e(2.71828175).
        /// </summary>
        public const float E = (float)Math.E;

        /// <summary>
        /// Represents the log base ten of e(0.4342945).
        /// </summary>
        // ReSharper disable once InconsistentNaming (justification: stay consistent with XNA)
        public const float Log10E = 0.4342945f;

        /// <summary>
        /// Represents the log base two of e(1.442695).
        /// </summary>
        // ReSharper disable once InconsistentNaming (justification: stay consistent with XNA)
        public const float Log2E = 1.442695f;

        /// <summary>
        /// Represents the value of pi(3.14159274).
        /// </summary>
        // ReSharper disable once InconsistentNaming (justification: stay consistent with XNA)
        public const float Pi = (float)Math.PI;

        /// <summary>
        /// Represents the value of pi divided by two(1.57079637).
        /// </summary>
        // ReSharper disable once InconsistentNaming (justification: stay consistent with XNA)
        public const float PiOver2 = (float)(Math.PI / 2.0);

        /// <summary>
        /// Represents the value of pi divided by four(0.7853982).
        /// </summary>
        // ReSharper disable once InconsistentNaming (justification: stay consistent with XNA)
        public const float PiOver4 = (float)(Math.PI / 4.0);

        /// <summary>
        /// Represents the value of pi times two(6.28318548).
        /// </summary>
        // ReSharper disable once InconsistentNaming (justification: stay consistent with XNA)
        public const float TwoPi = (float)(Math.PI * 2.0);

        public static float ToRadians(this float degrees)
        {
            return degrees * TwoPi / 360f;
        }

        public static float ToDegrees(this float radians)
        {
            return radians * 360 / TwoPi;
        }

        public static float Clamp(float value, float min, float max)
        {
            Contract.Requires(max >= min);
            Contract.Ensures(Contract.Result<float>() <= max && Contract.Result<float>() >= min);

            //This is not an extension method deliberately. Here's a simple quiz to show why:
            //
            //    What does -5f.Clamp(0, 10) return?
            //
            //Worked it out? Hmm, well maybe you'll be surprised to discover that the answer is minus 5!
            //Negation has lower precedence than method calls! so this is really:
            //
            //    -(5f.Clamp(0, 10))
            //
            //Yeah... Not clever extensions on floats!
            //Now this is *not* a problem for the ToRadians and ToDegrees methods above, because it turns out that they work exactly the same no matter

            return value < min
                ? min
                : value > max
                    ? max
                    : value;
        }

        public static int Clamp(int value, int min, int max)
        {
            Contract.Requires(max >= min);
            Contract.Ensures(Contract.Result<int>() <= max && Contract.Result<int>() >= min);

            return value < min
                ? min
                : value > max
                    ? max
                    : value;
        }

        public static float Lerp(float min, float max, float t)
        {
            return (max - min) * t + min;
        }
    }
}
