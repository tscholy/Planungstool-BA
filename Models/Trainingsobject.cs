using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Trainingsobject
    {
        public Trainingsobject()
        {
        }

        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string Description { get; set; }
        [JsonProperty]
        public string Accessibility { get; set; }
        [JsonProperty]
        public byte[] Image { get; set; }
        [JsonProperty]
        public int Owner { get; set; }

    }
}
