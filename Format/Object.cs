using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace Vistart.ImageRecognitionAnnotationFormat.Format
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Object
    {
        [JsonProperty]
        public string Name { get; set; }

        /// <summary>
        /// The category to which this object belongs.
        /// </summary>
        [JsonProperty]
        public int Category { get; set; }

        public enum Shapes {Point, LineSegment, Path, Polygon, Ellipse};

        [JsonProperty]
        public Shapes Shape { get; private set; }

        private readonly List<Point> _points = new List<Point>();

        /// <summary>
        /// Points.
        /// </summary>
        [JsonProperty]
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

                if (Shape == Shapes.Ellipse)
                {
                    if (value.Count != 2)
                        throw new ArgumentException(string.Format("When the shape is a ellipse, the number of points should be 2. the current number is {0}.", value.Count()));
                    Points.AddRange(value);
                }
            }
        }

        [JsonProperty]
        public float? EllipticalSemiMajorAxis { get; set; }= null;

        /// <summary>
        /// Determine if the current shape is a circle.
        /// </summary>
        /// <returns></returns>
        public bool IsCircle()
        {
            if (Shape != Shapes.Ellipse)
                return false;
            return IsCoincide(Points[0], Points[1]);
        }

        public const double Epsilon = 1e-6;

        /// <summary>
        /// Determine if the two points coincide.
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <returns></returns>
        public bool IsCoincide(Point one, Point two)
        {
            return (Math.Abs(one.X - two.X) < Epsilon && Math.Abs(one.Y - two.Y) < Epsilon);
        }

        /// <summary>
        /// Initialize the object.
        /// </summary>
        /// <param name="name">Object name.</param>
        /// <param name="category">The category to which this object belongs.</param>
        /// <param name="shape">Shape.</param>
        /// <param name="points">Points.</param>
        /// <param name="ellipticalSemiMajorAxis"></param>
        public Object(string name, int category, Shapes shape, List<Point> points, float? ellipticalSemiMajorAxis = null)
        {
            Name = name;
            Category = category;
            Shape = shape;
            Points = points;
            EllipticalSemiMajorAxis = ellipticalSemiMajorAxis;
        }
    }
}
