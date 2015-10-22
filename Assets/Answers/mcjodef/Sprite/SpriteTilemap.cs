// http://answers.unity3d.com/questions/1085032/

namespace Answers.mcjodef.SpriteTiles
{
    public interface SpriteTilemap
    {
        int Width { get; }
        int Height { get; }
        SpriteTile GetTile(int x, int y);
    }
}