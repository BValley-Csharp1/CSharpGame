// http://answers.unity3d.com/questions/1085032/

namespace Answers.mcjodef.AsciiTiles
{
    public class AsciiTilemap
    {
        private AsciiTile[,] tiles;

        public int Width { get { return tiles.GetLength(0); } }
        public int Height { get { return tiles.GetLength(1); } }

        public AsciiTilemap(int width, int height)
        {
            tiles = new AsciiTile[width, height];
        }

        public void Fill(AsciiTile tile)
        {
            for (int x = 0; x < Width; ++x)
            {
                for (int y = 0; y < Height; ++y)
                {
                    tiles[x, y] = tile;
                }
            }
        }

        public void SetTile(int x, int y, AsciiTile tile)
        {
            tiles[x, y] = tile;
        }

        public AsciiTile GetTile(int x, int y)
        {
            return tiles[x, y];
        }
    }
}