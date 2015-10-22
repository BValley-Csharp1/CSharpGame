// http://answers.unity3d.com/questions/1085032/

namespace Answers.mcjodef.BridgeTiles
{
    using AsciiTiles;
    using SpriteTiles;
     
    public class BridgeTilemap : SpriteTilemap
    {
        private AsciiTilemap tilemap;
        private BridgeTileConverter converter;

        public int Width { get { return tilemap.Width; } }
        public int Height { get { return tilemap.Height; } }

        public BridgeTilemap(AsciiTilemap tilemap, BridgeTileConverter converter)
        {
            this.tilemap = tilemap;
            this.converter = converter;
        }

        public SpriteTile GetTile(int x, int y)
        {
            return converter.ToSpriteTile(tilemap.GetTile(x, y));
        }
    }
}