// http://answers.unity3d.com/questions/1085032/

namespace Answers.mcjodef.AsciiTiles
{
    using System;

    public struct AsciiTile
    {
        public char Character;
        public ConsoleColor Color;

        public AsciiTile(char character, ConsoleColor color)
        {
            Character = character;
            Color = color;
        }

        #region Preset examples
        public static readonly AsciiTile Grass = new AsciiTile('#', ConsoleColor.DarkGreen);
        public static readonly AsciiTile Stone = new AsciiTile('+', ConsoleColor.Gray);
        public static readonly AsciiTile Wall = new AsciiTile('$', ConsoleColor.Cyan);
        public static readonly AsciiTile Y = new AsciiTile('Y', ConsoleColor.Cyan);
        #endregion
    }
}

