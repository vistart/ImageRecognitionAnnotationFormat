using System;
using Newtonsoft.Json;

namespace Vistart.ImageRecognitionAnnotationFormat.ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Format.Format format = new Format.Format();
            format.Filename = "image.jpg";
            format.Base64ImgDate = "1";
            Console.WriteLine(JsonConvert.SerializeObject(format));
        }
    }
}
