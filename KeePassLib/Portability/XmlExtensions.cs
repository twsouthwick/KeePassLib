using System;
using System.Xml;

namespace KeePassLib
{
    internal static class XmlExtensions
    {
        static private uint IsTextualNodeBitmap = 0x6018;

        public static string ReadElementString(this XmlReader reader)
        {
            string result = string.Empty;

            if (reader.MoveToContent() != XmlNodeType.Element)
            {
                throw new InvalidOperationException();
            }
            if (!reader.IsEmptyElement)
            {
                reader.Read();
                result = reader.ReadString();
                if (reader.NodeType != XmlNodeType.EndElement)
                {
                    throw new InvalidOperationException();
                }
                reader.Read();
            }
            else
            {
                reader.Read();
            }
            return result;
        }

        private static string ReadString(this XmlReader reader)
        {
            if (reader.ReadState != ReadState.Interactive)
            {
                return string.Empty;
            }
            reader.MoveToElement();
            if (reader.NodeType == XmlNodeType.Element)
            {
                if (reader.IsEmptyElement)
                {
                    return string.Empty;
                }
                else if (!reader.Read())
                {
                    throw new InvalidOperationException();
                }
                if (reader.NodeType == XmlNodeType.EndElement)
                {
                    return string.Empty;
                }
            }
            string result = string.Empty;
            while (IsTextualNode(reader.NodeType))
            {
                result += reader.Value;
                if (!reader.Read())
                {
                    break;
                }
            }
            return result;
        }

        static internal bool IsTextualNode(XmlNodeType nodeType)
        {
            return 0 != (IsTextualNodeBitmap & (1 << (int)nodeType));
        }
    }
}
