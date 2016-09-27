#if !FEATURE_WINFORMS

namespace KeePassLib
{
    public struct Color
    {
        public int R;
        public int G;
        public int B;
        public int A;

        public static Color Empty { get; } = new Color();

        public static bool operator ==(Color color1, Color color2)
        {
            return color1.Equals(color2);
        }

        public static bool operator !=(Color color1, Color color2)
        {
            return !color1.Equals(color2);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Color))
            {
                return false;
            }

            var other = (Color)obj;

            return other.A == A
               && other.B == B
               && other.G == G
               && other.R == R;
        }
    }

    internal static class ColorTranslator
    {
        public static Color FromHtml(string html)
        {
            // TODO: Implement if needed
            return Color.Empty;
        }
    }
}
#endif