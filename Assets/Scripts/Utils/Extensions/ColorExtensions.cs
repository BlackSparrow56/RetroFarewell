using UnityEngine;

namespace Utils.Extensions
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Представляет цвет в виде шестнадцатиричного кода (например, #FFFFFFFF)
        /// </summary>
        public static string ToHexadecimal(this Color color)
        {
            string code = "#";
            code += ToInt(color.r).ToString("X2");
            code += ToInt(color.g).ToString("X2");
            code += ToInt(color.b).ToString("X2");
            code += ToInt(color.a).ToString("X2");

            return code;

            int ToInt(float from)
            {
                return (int) (from * 255);
            }
        }
    }
}
