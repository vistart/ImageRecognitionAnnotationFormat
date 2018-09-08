using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Vistart.ImageRecognitionAnnotationFormat.Format
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Point
    {
        [JsonProperty]
        public int X;

        [JsonProperty]
        public int Y;
    }
}
