using LibNoise;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.IO;

namespace NoiseGraph
{
    [CreateNodeMenu("NoiseGraph/Debug/Render")]
    [NodeTint(Graph.ColorProfile.Debug)]
    public class Renderer : Node
    {
        string DataPath = "/Textures/TestMaps/";
        [SerializeField] public string PictureName = "Test";
        [SerializeField] public float south = 90.0f;
        [SerializeField] public float north = -90.0f;
        [SerializeField] public float west = -180.0f;
        [SerializeField] public float east = 180.0f;
        [SerializeField] public int size = 512;
        [SerializeField] public Texture2D tex = null;
        [SerializeField] public Gradient grad = new Gradient();

        public float Space = 110;

        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase Input;

        public Rect TexturePosition = new Rect(14, 225, 180, 90);

        public long RenderTime;

        public void Render()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();

            Noise2D map = new Noise2D(
                size,
                size / 2, 
                GetInputValue<SerializableModuleBase>("Input", Input));

            map.GeneratePlanar(
                west,
                east,
                north,
                south);

            tex = map.GetTexture(grad);
            tex.Apply();

            watch.Stop();
            RenderTime = watch.ElapsedMilliseconds;
        }

        public void Save()
        {
            if (tex == null) return;

            UnityEngine.Debug.Log(Application.dataPath + DataPath + PictureName + ".png");

            File.WriteAllBytes(Application.dataPath + DataPath + PictureName + ".png", tex.EncodeToPNG());
        }
    }
}    