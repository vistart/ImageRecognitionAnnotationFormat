using System;
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
                                    new Format.Object()
                                    {
                                        Name = "Object1",
                                        Points =
                                        {
                                            new Point()
                                            {
                                                X = 1,
                                                Y = 1,
                                            }
                                        },
                                        Shape = Object.Shapes.Point,
                                    }
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
