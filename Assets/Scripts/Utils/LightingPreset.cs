using System;
using UnityEngine;

namespace Utils
{
    [Serializable]
    [CreateAssetMenu(fileName = "LightningPreset", menuName = "Scriptable Objects/Lighting Preset", order = 1)]
    public class LightingPreset : ScriptableObject
    {
        public Gradient AmbientColor;
        public Gradient DirectionalColor;
        public Gradient FogColor;
    }
}