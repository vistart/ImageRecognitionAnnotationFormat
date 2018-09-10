﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Vistart.ImageRecognitionAnnotationFormat.Format;
using Object = Vistart.ImageRecognitionAnnotationFormat.Format.Object;

namespace Vistart.ImageRecognitionAnnotationFormat.ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> points = new List<Point>()
            {
                new Point() {X = 1, Y = 1}
            };
            Format.Image image = new Format.Image
            {
                Filename = "image.jpg",
                Base64ImgData = "1",
                Layers =
                {
                    new Layer
                    {
                        Name = "Layer1",
                        Regions =
                        {
                            new Region()
                            {
                                Name = "Region1",
                                Objects =
                                {
                                    new Object("Object1", 1, Object.Shapes.Point, points)
                                }
                            }
                        }
                    }
                }
            };
            Console.WriteLine(JsonConvert.SerializeObject(image));
        }
    }
}
