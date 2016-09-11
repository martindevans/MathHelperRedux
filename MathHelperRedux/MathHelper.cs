using System;
using System.Diagnostics.Contracts;

namespace MathHelperRedux
{
    public static class MathHelper
    {
        //MIT licensed implementation of the same thing:
        //  https://github.com/mono/MonoGame/blob/6619f1ab42c427dd43a9ecb74cea01f8c83ecfbe/MonoGame.Framework/MathHelper.cs
        //This can be a handy reference

        /// <summary>
        /// Represents the mathematical constant e(2.71828175).
        /// </summary>
        public const float E = (float)Math.E;

        /// <summary>
        /// Represents the log base ten of e(0.4342945).
        /// </summary>
        public const float Log10E = 0.4342945f;

        /// <summary>
        /// Represents the log base two of e(1.442695).
        /// </summary>
        public const float Log2E = 1.442695f;

        /// <summary>
        /// Represents the value of pi(3.14159274).
        /// </summary>
        public const float Pi = (float)Math.PI;

        /// <summary>
        /// Represents the value of pi divided by two(1.57079637).
        /// </summary>
        public const float PiOver2 = (float)(Math.PI / 2.0);

        /// <summary>
        /// Represents the value of pi divided by four(0.7853982).
        /// </summary>
        public const float PiOver4 = (float)(Math.PI / 4.0);

        /// <summary>
        /// Represents the value of pi times two(6.28318548).
        /// </summary>
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
            //Yeah... No clever extensions on floats!
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

        /// <summary>
        /// Calculates the 't' value which produces the target value = lerp(a, b, t)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float InverseLerp(float a, float b, float value)
        {
            return (value - a) / (b - a);
        }

        /// <summary>
        /// Given an interpolation factor, bilinearly interpolate 4 values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lerp">A lerp function</param>
        /// <param name="yt">interpolation along y axis</param>
        /// <param name="tl">value at top left</param>
        /// <param name="tr">value at top right</param>
        /// <param name="br">value at bot right</param>
        /// <param name="bl">value at bot left</param>
        /// <param name="xt">Interpolation along x axis</param>
        /// <returns></returns>
        public static T BilinearLerp<T>(Func<T, T, float, T> lerp, float xt, float yt, T tl, T tr, T br, T bl)
        {
            Contract.Requires(lerp != null);

            //lerp horizontal
            var top = lerp(tl, tr, xt);
            var bot = lerp(bl, br, xt);

            //lerp vertical
            return lerp(bot, top, yt);
        }

        /// <summary>
        /// Given an interpolation factor, bilinearly interpolate 4 values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lerp">A lerp function</param>
        /// <param name="yt">interpolation along y axis</param>
        /// <param name="xt">Interpolation along x axis</param>
        /// <param name="zt">Interpolation along Z axis</param>
        /// <param name="brb">Value at bot right back</param>
        /// <param name="brf">Value at bot right front</param>
        /// <param name="blb">Value at bot left back</param>
        /// <param name="blf">Value at bot left front</param>
        /// <param name="trb">Value at top right back</param>
        /// <param name="trf">Value at top right front</param>
        /// <param name="tlb">Value top left back</param>
        /// <param name="tlf">Value at top left front</param>
        /// <returns></returns>
        public static T TrilinearLerp<T>(Func<T, T, float, T> lerp, float xt, float yt, float zt, T brb, T brf, T blb, T blf, T trb, T trf, T tlb, T tlf)
        {
            Contract.Requires(lerp != null);

            //bilerp top
            var top = BilinearLerp(lerp, xt, zt, tlb, trb, trf, tlf);
            var bot = BilinearLerp(lerp, xt, zt, blb, brb, brf, blf);

            //lerp vertical
            return lerp(bot, top, yt);
        }
    }
}
