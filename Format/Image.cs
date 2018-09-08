using System;
using Newtonsoft.Json;

namespace Vistart.ImageRecognitionAnnotationFormat.Format
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Image
    {
        [JsonProperty]
        public string Filename { get; set; }

        [JsonProperty]
        public string Base64ImgData { get; set; }

        [JsonProperty]
        public Layer[] Layers { get; set; }
    }
}
