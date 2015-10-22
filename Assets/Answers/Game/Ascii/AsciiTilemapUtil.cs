namespace Answers.mcjodef.AsciiTiles
{
    using UnityEngine;

    public static class AsciiTilemapUtil
    {
        // Utility just to give the tilemap some interesting content...
        // Randomly distribute Stone and Grass tiles based on Perlin Noise.
        public static AsciiTilemap Procedural(int width, int height)
        {
            AsciiTilemap asciiTilemap = new AsciiTilemap(width, height);
            for (int y = 0; y < asciiTilemap.Height; ++y)
            {
                for (int x = 0; x < asciiTilemap.Width; ++x)
                {                    
                    asciiTilemap.SetTile(x, y, AsciiTile.Wall);
                    if (y > 0 & y < asciiTilemap.Height - 1)
                    {
                        if (x > 0 & x < asciiTilemap.Width - 1)
                        asciiTilemap.SetTile(x, y, AsciiTile.Stone);
                    }
                }
            }
            return asciiTilemap;
        }        
    }
}