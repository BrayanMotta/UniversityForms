using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace University.App.DTOs
{
    public class CourseDTO
    {
        [JsonProperty("CourseID")]
        public int CourseID { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Credits")]
        public int Credits { get; set; }
    }
}
