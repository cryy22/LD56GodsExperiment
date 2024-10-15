using UnityEngine;

namespace GodsExperiment
{
    public static class Constants
    {
        public const int MaxWorkerSlotsPerTask = 8;
        public const float PlaySpeed = 0.75f;
        public const float FastForwardSpeed = 2 * PlaySpeed;
        public const float VeryFastForwardSpeed = 2 * FastForwardSpeed;

        public static readonly Color Black = Color.HSVToRGB(H: 120f / 360f, S: 0.38f, V: 0.05f);
        public static readonly Color Red = Color.HSVToRGB(H: 20f / 360f, S: 1f, V: 0.9f);
        public static readonly Color Green = Color.HSVToRGB(H: 120f / 360f, S: 1f, V: 0.8f);
        public static readonly Color LightGray = Color.HSVToRGB(H: 120f / 360f, S: 0.05f, V: 0.75f);
        public static readonly Color Yellow = Color.HSVToRGB(H: 48f / 360f, S: 1f, V: 1f);
    }
}
