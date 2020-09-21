using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GhostPublishCLI
{
    public partial class GhostData
    {
        [JsonProperty("posts")]
        public Post[] Posts { get; set; }
    }
}
