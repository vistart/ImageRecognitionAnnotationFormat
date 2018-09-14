using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Vistart.ImageRecognitionAnnotationFormat.Format
{
    [JsonObject(MemberSerialization.OptIn)]
    [XmlRoot("Point")]
    public class Point
    {
        [JsonProperty("X")]
        [XmlAttribute("X")]
        public int X { get; set; } = 0;

        [JsonProperty("Y")]
        [XmlAttribute("Y")]
        public int Y { get; set; } = 0;

        public static bool operator ==(Point left, Point right)
        {
            return left != null && right != null && left.X == right.X && left.Y == right.Y;
        }

        public static bool operator !=(Point left, Point right)
        {
            return left == null || right == null || left.X != right.X || left.Y != right.Y;
        }

        public override bool Equals(object other)
        {
            if (!(other is Point)) return false;
            return this == (Point)other;
        }

        public override int GetHashCode()
        {
            return ShiftAndWrap(X.GetHashCode(), 2) ^ Y.GetHashCode();
        }

        private int ShiftAndWrap(int value, int positions)
        {
            positions = positions & 0x1F;
            uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
            uint wrapped = number >> (32 - positions);
            return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
        }

        public Point()
        {
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
