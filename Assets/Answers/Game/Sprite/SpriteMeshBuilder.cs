namespace Answers.mcjodef.SpriteTiles
{
    using System.Collections.Generic;
    using UnityEngine;

    public class SpriteMeshBuilder
    {
        const int IndicesPerTile = 6;
        const int VerticesPerTile = 4;

        private SpriteTilemap tilemap;
        private List<int> triangles;
        private List<Vector3> vertices;
        private List<Vector2> uvs;
        private List<Color> colors;

        public SpriteMeshBuilder(SpriteTilemap tilemap)
        {
            this.tilemap = tilemap;
            CreateBuffers();
            AddTriangles();
        }

        public Mesh BuildMesh()
        {
            Mesh mesh = new Mesh();
            UpdateMesh(mesh);
            return mesh;
        }

        public void UpdateMesh(Mesh mesh)
        {
            ClearVertices();
            AddVertices();

            mesh.MarkDynamic();
            mesh.SetVertices(vertices);
            mesh.SetUVs(0, uvs);
            mesh.SetColors(colors);
            mesh.SetTriangles(triangles, 0);
        }

        private void CreateBuffers()
        {
            int numberOfTiles = tilemap.Width * tilemap.Height;
            int indexCount = numberOfTiles * IndicesPerTile;
            int vertexCount = numberOfTiles * VerticesPerTile;

            triangles = new List<int>(indexCount);
            vertices = new List<Vector3>(vertexCount);
            uvs = new List<Vector2>(vertexCount);
            colors = new List<Color>(vertexCount);
        }

        private void AddTriangles()
        {
            for (int y = 0; y < tilemap.Height; ++y)
            {
                for (int x = 0; x < tilemap.Width; ++x)
                {
                    AddTileTriangles(x, y);
                }
            }
        }

        private void AddTileTriangles(int x, int y)
        {
            int baseVertex = (x + y * tilemap.Width) * VerticesPerTile;

            // First triangle
            triangles.Add(baseVertex + 0);
            triangles.Add(baseVertex + 2);
            triangles.Add(baseVertex + 1);

            // Second triangle
            triangles.Add(baseVertex + 2);
            triangles.Add(baseVertex + 3);
            triangles.Add(baseVertex + 1);
        }

        private void ClearVertices()
        {
            vertices.Clear();
            uvs.Clear();
            colors.Clear();
        }

        private void AddVertices()
        {
            for (int y = 0; y < tilemap.Height; ++y)
            {
                for (int x = 0; x < tilemap.Width; ++x)
                {
                    AddTileVertices(x, y, tilemap.GetTile(x, y));
                }
            }
        }

        private void AddTileVertices(int x, int y, SpriteTile tile)
        {
            int x0 = x;
            int x1 = x + 1;
            int y0 = y;
            int y1 = y + 1;

            vertices.Add(new Vector3(x0, y0));
            vertices.Add(new Vector3(x1, y0));
            vertices.Add(new Vector3(x0, y1));
            vertices.Add(new Vector3(x1, y1));

            // This is slightly funny.
            // Could probably rewrite my code and use
            // uvs.AddRange(tile.Sprite.uv) instead.
            // Oh well...
            Vector2[] spriteUV = tile.Sprite.uv;
            uvs.Add(spriteUV[3]);
            uvs.Add(spriteUV[1]);
            uvs.Add(spriteUV[0]);
            uvs.Add(spriteUV[2]);

            
            colors.Add(tile.Color);
            colors.Add(tile.Color);
            colors.Add(tile.Color);
            colors.Add(tile.Color);
        }
    }
}

