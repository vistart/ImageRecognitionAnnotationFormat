using System;
using Newtonsoft.Json;

namespace Vistart.ImageRecognitionAnnotationFormat.Format
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Format
    {
        [JsonProperty]
        public string Filename { get; set; }

        [JsonProperty]
        public string Base64ImgDate { get; set; }
    }
}
