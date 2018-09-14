using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Vistart.ImageRecognitionAnnotationFormat.Format
{
    [JsonObject(MemberSerialization.OptIn)]
    [XmlRoot("Object")]
    public class Object
    {
        [JsonProperty("name")]
        [XmlAttribute("name")]
        public string Name { get; set; } = "";

        /// <summary>
        /// The category to which this object belongs.
        /// </summary>
        [JsonProperty("category")]
        [XmlAttribute("category")]
        public int Category { get; set; } = 0;

        public enum Shapes {Point, LineSegment, Path, Polygon};

        [JsonProperty("shape")]
        [XmlAttribute("shape")]
        public Shapes Shape { get; set; } = Shapes.Point;

        private readonly List<Point> _points = new List<Point>();

        /// <summary>
        /// Points.
        /// </summary>
        [JsonProperty("points")]
        [XmlArray("points")]
        [XmlArrayItem("Point")]
        public List<Point> Points
        {
            get => _points;
            protected set
            {
                if (Shape == Shapes.Point)
                {
                    if (value.Count != 1)
                        throw new ArgumentException(string.Format("When the shape is a point, the number of points should be 1. The current number is {0}.", value.Count()));
                    Points.AddRange(value);
                }

                if (Shape == Shapes.LineSegment)
                {
                    if (value.Count != 2)
                        throw new ArgumentException(string.Format("When the shape is a line segment, the number of points should be 2. The current number is {0}.", value.Count()));
                    Points.AddRange(value);
                }

                if (Shape == Shapes.Path || Shape == Shapes.Polygon)
                {
                    if (value.Count <= 2)
                        throw new ArgumentException(string.Format("When the shape is a path or polygon, the number of points should be more than 2. The current number is {0}.", value.Count()));
                    Points.AddRange(value);
                }
            }
        }

        public Object()
        {
        }

        /// <summary>
        /// Initialize the object.
        /// </summary>
        /// <param name="name">Object name.</param>
        /// <param name="category">The category to which this object belongs.</param>
        /// <param name="shape">Shape.</param>
        /// <param name="points">Points.</param>
        public Object(string name, int category, Shapes shape, List<Point> points)
        {
            Name = name;
            Category = category;
            Shape = shape;
            Points = points;
        }
    }
}
