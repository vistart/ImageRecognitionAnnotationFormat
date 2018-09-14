using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Vistart.ImageRecognitionAnnotationFormat.Format
{
    [JsonObject(MemberSerialization.OptIn)]
    [XmlRoot("Layer")]
    public class Layer
    {
        [JsonProperty("name")]
        [XmlAttribute("name")]
        public string Name { get; set; }

        [JsonProperty("regions")]
        [XmlArray("regions")]
        [XmlArrayItem("Region")]
        public List<Region> Regions { get; set; } = new List<Region>();
    }
}
