namespace Answers.mcjodef.SpriteTiles
{
    using UnityEngine;

    public struct SpriteTile
    {
        public Sprite Sprite;
        public Color Color;

        public SpriteTile(Sprite sprite, Color color)
        {
            Sprite = sprite;
            Color = color;
        }
    }
}