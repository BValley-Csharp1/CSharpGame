namespace Answers.mcjodef.SpriteTiles
{
    public interface SpriteTilemap
    {
        int Width { get; }
        int Height { get; }
        SpriteTile GetTile(int x, int y);
    }
}