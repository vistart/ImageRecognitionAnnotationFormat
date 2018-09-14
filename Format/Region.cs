using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Vistart.ImageRecognitionAnnotationFormat.Format
{
    [JsonObject(MemberSerialization.OptIn)]
    [XmlRoot("Region")]
    public class Region
    {
        [JsonProperty("name")]
        [XmlAttribute("name")]
        public string Name { get; set; }

        [JsonProperty("objects")]
        [XmlArray("objects")]
        [XmlArrayItem("Object")]
        public List<Object> Objects { get; set; } = new List<Object>();
    }
}
