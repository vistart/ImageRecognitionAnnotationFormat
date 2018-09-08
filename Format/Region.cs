using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Vistart.ImageRecognitionAnnotationFormat.Format
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Region
    {
        [JsonProperty]
        public string Name;

        [JsonProperty]
        public Object[] Objects;
    }
}
