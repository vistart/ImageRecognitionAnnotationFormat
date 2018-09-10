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
        public string Name;

        [JsonProperty]
        public int Category;

        public enum Shapes {Point, LineSegment, Path, Polygon, Ellipse};

        [JsonProperty]
        public Shapes Shape { get; private set; }

        private readonly List<Point> _points = new List<Point>();

        [JsonProperty]
        public List<Point> Points
        {
            get => _points;
            protected set
            {
                if (Shape == Shapes.Point)
                {
                    if (value.Count() == 1)
                    {
                        Points.AddRange(value);
                        return;
                    }
                    throw new ArgumentException(string.Format("When the shape is a point, the number of points should be 1. The current number is {0}.", value.Count()));
                }

                if (Shape == Shapes.LineSegment)
                {
                    if (value.Count() == 2)
                    {
                        Points.AddRange(value);
                        return;
                    }
                    throw new ArgumentException(string.Format("When the shape is a line segment, the number of points should be 2. The current number is {0}.", value.Count()));
                }

                if (Shape == Shapes.Path || Shape == Shapes.Polygon)
                {
                    if (value.Count() > 2)
                    {
                        Points.AddRange(value);
                        return;
                    }
                    throw new ArgumentException(string.Format("When the shape is a path or polygon, the number of points should be more than 2. The current number is {0}.", value.Count()));
                }

                if (Shape == Shapes.Ellipse)
                {
                    if (value.Count() == 3)
                    {
                        Points.AddRange(value);
                        return;
                    }
                    throw new ArgumentException(string.Format("When the shape is a ellipse, the number of points should be 3. the current number is {0}.", value.Count()));
                }
            }
        }

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
        public Object(string name, int category, Shapes shape, List<Point> points)
        {
            Name = name;
            Category = category;
            Shape = shape;
            Points = points;
        }
    }
}
