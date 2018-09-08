using System;
using Newtonsoft.Json;

namespace Vistart.ImageRecognitionAnnotationFormat.ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Format.Image format = new Format.Image();
            format.Filename = "image.jpg";
            format.Base64ImgData = "1";
            Console.WriteLine(JsonConvert.SerializeObject(format));
        }
    }
}
