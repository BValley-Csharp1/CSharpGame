// http://answers.unity3d.com/questions/1085032/

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