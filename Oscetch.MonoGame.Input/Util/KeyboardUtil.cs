using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Oscetch.MonoGame.Input.Util
{
    public static class KeyboardUtil
    {
        public static string GetKeyString(Keys key)
        {
            return StringKeys.TryGetValue(key, out var keyString)
                ? keyString
                : string.Empty;
        }

        public static bool TryGetNumericKeyValue(Keys key, out int keyValue)
        {
            return NumberKeys.TryGetValue(key, out keyValue);
        }

        public static IDictionary<Keys, int> NumberKeys { get; } = new Dictionary<Keys, int>
            {
                { Keys.D0, 0 },
                { Keys.D1, 1 },
                { Keys.D2, 2 },
                { Keys.D3, 3 },
                { Keys.D4, 4 },
                { Keys.D5, 5 },
                { Keys.D6, 6 },
                { Keys.D7, 7 },
                { Keys.D8, 8 },
                { Keys.D9, 9 }
            };

        public static IDictionary<Keys, string> StringKeys { get; } = new Dictionary<Keys, string>
        {
            { Keys.D0, "0" },
            { Keys.D1, "1" },
            { Keys.D2, "2" },
            { Keys.D3, "3" },
            { Keys.D4, "4" },
            { Keys.D5, "5" },
            { Keys.D6, "6" },
            { Keys.D7, "7" },
            { Keys.D8, "8" },
            { Keys.D9, "9" },
            { Keys.Q, "Q" },
            { Keys.W, "W" },
            { Keys.E, "E" },
            { Keys.R, "R" },
            { Keys.T, "T" },
            { Keys.Y, "Y" },
            { Keys.U, "U" },
            { Keys.I, "I" },
            { Keys.O, "O" },
            { Keys.P, "P" },
            { Keys.A, "A" },
            { Keys.S, "S" },
            { Keys.D, "D" },
            { Keys.F, "F" },
            { Keys.G, "G" },
            { Keys.H, "H" },
            { Keys.J, "J" },
            { Keys.K, "K" },
            { Keys.L, "L" },
            { Keys.Z, "Z" },
            { Keys.X, "X" },
            { Keys.C, "C" },
            { Keys.V, "V" },
            { Keys.B, "B" },
            { Keys.N, "N" },
            { Keys.M, "M" },
            { Keys.OemComma, "," },
            { Keys.OemPeriod, "." },
            { Keys.OemMinus, "-" },
            { Keys.Space, " " },
            { Keys.Divide, "/" }
        };
    }
}
