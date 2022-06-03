using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace University.App.DTOs
{
    public class RegisterDTO
    {
        public class RegisterReqDTO
        {
            //[JsonProperty("name")]
            //public string Name { get; set; }
            //[JsonProperty("lastName")]
            public string LastName { get; set; }
            [JsonProperty("email")]
            public string Email { get; set; }
            [JsonProperty("password")]
            public string Password { get; set; }
        }

        public class RegisterResDTO
        {
            [JsonProperty("id")]
            public string Id { get; set; }
            [JsonProperty("token")]
            public string Token { get; set; }
        }

        public class RegisterResFailDTO
        {
            [JsonProperty("error")]
            public string Error { get; set; }
        }
    }
}
