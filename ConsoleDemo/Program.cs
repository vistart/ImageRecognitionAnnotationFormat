using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
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
                new Point(1, 1)
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
                            new Region
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
            string json_serialized = JsonConvert.SerializeObject(image);
            Console.WriteLine(json_serialized);

            string xml_serialized = XmlSerialize(typeof(Image), image);
            Console.WriteLine(xml_serialized);

            Image json_deserialized = JsonConvert.DeserializeObject<Image>(json_serialized);
        }

        public static string XmlSerialize(Type type, object obj)
        {
            MemoryStream stream = new MemoryStream();
            XmlSerializer serializer = new XmlSerializer(type);
            serializer.Serialize(stream, obj);
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            string result = reader.ReadToEnd();
            reader.Dispose();
            stream.Dispose();
            return result;
        }
    }
}
