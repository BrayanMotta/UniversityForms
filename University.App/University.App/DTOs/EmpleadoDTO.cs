using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace University.App.DTOs
{
    public class EmpleadoDTO
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("telephone")]
        public string Telephone { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
