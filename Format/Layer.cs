using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Vistart.ImageRecognitionAnnotationFormat.Format
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Layer
    {
        [JsonProperty]
        public string Name;

        [JsonProperty]
        public Region[] Regions;
    }
}
