// http://answers.unity3d.com/questions/1085032/

namespace Answers.mcjodef
{
    using UnityEngine;
    using System;

    using SpriteTiles;  // Containing logic regarding Sprite and Mesh management
    using AsciiTiles;   // Containing logic regarding Ascii stuff
    using BridgeTiles;  // Containing logic regarding joining Sprite and Ascii together

    public class Answer : MonoBehaviour
    {
        // Use sensible values please.
        public int width = 16;
        public int height = 16;

        // The material need to have the same texture as the sprites below.
        public Material spriteMaterial;

        // Both sprites need to be in the same atlas for this to work!
        public Sprite grassSprite;
        public Sprite stoneSprite;
        public Sprite wallSprite;
        public Sprite ySprite;

        // Just holding on to reference so we can destroy it.
        private Mesh spriteMesh;

        private void Start()
        {
            // Let's keep the size between 8x8 and 96x96.
            // If the mesh get too large, Unity will complain.
            // And I dont feel like committing time to make
            // submeshes out of this.
            width = Mathf.Clamp(width, 8, 96);
            height = Mathf.Clamp(height, 8, 96);

            AsciiTilemap characters = AsciiTilemapUtil.Procedural(width, height);
            BridgeTileConverter converter = BuildTileConverter();
            SpriteTilemap sprites = new BridgeTilemap(characters, converter);
            SpriteMeshBuilder builder = new SpriteMeshBuilder(sprites);
            spriteMesh = builder.BuildMesh();

            AddMeshRenderer(spriteMesh, spriteMaterial);
        }

        private BridgeTileConverter BuildTileConverter()
        {
            BridgeTileConverter converter = new BridgeTileConverter();

            // Which characters in the ascii tilemap should map to which sprites?
            converter.BindCharacter('#', grassSprite);
            converter.BindCharacter('+', stoneSprite);
            converter.BindCharacter('$', wallSprite);
            converter.BindCharacter('Y', ySprite);
            converter.FallbackSprite = stoneSprite;

            // Which ConsoleColors in the ascii tilemap should map to which Unity colors?
            const float Dark = 0.7f;
            converter.BindConsoleColor(ConsoleColor.Black, Color.black);
            converter.BindConsoleColor(ConsoleColor.Blue, Color.blue);
            converter.BindConsoleColor(ConsoleColor.Cyan, Color.cyan);
            converter.BindConsoleColor(ConsoleColor.DarkBlue, Color.blue * Dark);
            converter.BindConsoleColor(ConsoleColor.DarkCyan, Color.cyan * Dark);
            converter.BindConsoleColor(ConsoleColor.DarkGray, Color.gray * Dark);
            converter.BindConsoleColor(ConsoleColor.DarkGreen, Color.green * Dark);
            converter.BindConsoleColor(ConsoleColor.DarkMagenta, Color.magenta * Dark);
            converter.BindConsoleColor(ConsoleColor.DarkRed, Color.red * Dark);
            converter.BindConsoleColor(ConsoleColor.DarkYellow, Color.yellow * Dark);
            converter.BindConsoleColor(ConsoleColor.Gray, Color.gray);
            converter.BindConsoleColor(ConsoleColor.Green, Color.green);
            converter.BindConsoleColor(ConsoleColor.Magenta, Color.magenta);
            converter.BindConsoleColor(ConsoleColor.Red, Color.red);
            converter.BindConsoleColor(ConsoleColor.White, Color.white);
            converter.BindConsoleColor(ConsoleColor.Yellow, Color.yellow);
            converter.FallbackColor = Color.white;

            return converter;
        }

        private void AddMeshRenderer(Mesh mesh, Material material)
        {
            MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
            meshFilter.mesh = mesh;

            MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
            meshRenderer.material = material;
        }

        private void OnDestroy()
        {
            Destroy(spriteMesh);
        }
    }
}