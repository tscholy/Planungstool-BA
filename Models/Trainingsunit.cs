using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Trainingsunit
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string Description { get; set; }
        [JsonProperty]
        public  int Owner { get; set; }
        [JsonProperty]
        public string Accessibility { get; set; }

        public List<Trainingsexercise> Exercises { get; set; }


    }
}
