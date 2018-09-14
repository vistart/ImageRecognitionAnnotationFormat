using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;

namespace Vistart.ImageRecognitionAnnotationFormat.Format
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Image
    {
        [JsonProperty]
        public string Filename { get; set; }

        /// <summary>
        /// Image data encoded in Base64.
        /// It is not recommended to manipulate this property directly, please access `ImgData` instead.
        /// </summary>
        [JsonProperty]
        public string Base64ImgData { get; set; }

        public byte[] ImgData
        {
            get => Convert.FromBase64String(Base64ImgData);
            set => Base64ImgData = Convert.ToBase64String(value);
        }

        [JsonProperty]
        public List<Layer> Layers { get; set; } = new List<Layer>();
    }
}
