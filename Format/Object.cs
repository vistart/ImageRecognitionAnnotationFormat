using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Newtonsoft.Json;

namespace Vistart.ImageRecognitionAnnotationFormat.Format
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Object
    {
        [JsonProperty]
        public string Name;

        public enum Shapes {Point, LineSegment, Path, Polygon, Ellipse};

        [JsonProperty]
        public Shapes Shape;

        [JsonProperty]
        public List<Point> Points { get; set; } = new List<Point>();
    }
}
