using Newtonsoft.Json;

namespace UnityReplacement
{
    public class Color
    {
        public float r, g, b, a;

        [JsonConstructor]
        public Color(float r, float g, float b, float a = 1f)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public Color(UnityEngine.Color color)
        {
            r = color.r;
            g = color.g;
            b = color.b;
            a = color.a;
        }

        public UnityEngine.Color ToUnityColor()
        {
            return new UnityEngine.Color(r, g, b, a);
        }
    }
}
