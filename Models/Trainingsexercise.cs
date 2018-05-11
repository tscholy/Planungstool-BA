using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Models
{
    public class Trainingsexercise
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string Process { get; set; }
        [JsonProperty]
        public string Accessibility { get; set; }
        [JsonProperty]
        public string Type { get; set; }
        [JsonProperty]
        public byte[] Image { get; set; }
        [JsonProperty]
        public int Owner { get; set; }
        [JsonProperty]
        public string ImagePath { get; set; }
        [JsonProperty]
        public int Parent { get; set; }
    }
}
