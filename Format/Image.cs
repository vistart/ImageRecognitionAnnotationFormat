using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Vistart.ImageRecognitionAnnotationFormat.Format
{
    [JsonObject(MemberSerialization.OptIn)]
    [XmlRoot("Image")]
    public class Image
    {
        [JsonProperty("filename")]
        [XmlAttribute("filename")]
        public string Filename { get; set; } = "";

        /// <summary>
        /// Image data encoded in Base64.
        /// It is not recommended to manipulate this property directly, please access `ImgData` instead.
        /// </summary>
        [JsonProperty("base64_img_data")]
        [XmlAttribute("base64_img_data")]
        public string Base64ImgData { get; set; }

        public byte[] ImgData
        {
            get
            {
                try
                {
                    return Convert.FromBase64String(Base64ImgData);
                } catch (Exception)
                {
                    return System.Text.Encoding.Default.GetBytes(Base64ImgData = "");
                }
            }
            set => Base64ImgData = Convert.ToBase64String(value);
        }

        [JsonProperty("layers")]
        [XmlArray("layers")]
        [XmlArrayItem("Layer")]
        public List<Layer> Layers { get; set; } = new List<Layer>();
    }
}
