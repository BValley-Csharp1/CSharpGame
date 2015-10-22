// http://answers.unity3d.com/questions/1085032/

namespace Answers.mcjodef.BridgeTiles
{
    using UnityEngine;
    using System;
    using System.Collections.Generic;

    using AsciiTiles;
    using SpriteTiles;

    public class BridgeTileConverter
    {
        Dictionary<char, Sprite> sprites = new Dictionary<char, Sprite>();
        Dictionary<ConsoleColor, Color> colors = new Dictionary<ConsoleColor, Color>();

        public Sprite FallbackSprite;
        public Color FallbackColor = Color.white;

        public void BindCharacter(char character, Sprite sprite)
        {
            sprites[character] = sprite;
        }

        public void BindConsoleColor(ConsoleColor consoleColor, Color color)
        {
            colors[consoleColor] = color;
        }

        public SpriteTile ToSpriteTile(AsciiTile asciiTile)
        {
            Sprite sprite = ToSprite(asciiTile.Character);
            Color color = ToColor(asciiTile.Color);
            return new SpriteTile(sprite, color);
        }

        private Sprite ToSprite(char character)
        {
            Sprite sprite;
            if (!sprites.TryGetValue(character, out sprite))
                return FallbackSprite;
            else
                return sprite;
        }

        private Color ToColor(ConsoleColor consoleColor)
        {
            Color color;
            if (!colors.TryGetValue(consoleColor, out color))
                return FallbackColor;
            else
                return color;
        }
    }
}