using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace University.App.DTOs
{
    public class VehiculoDTO
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("vh_placa")]
        public string VhPlaca { get; set; }

        [JsonProperty("vh_modelo")]
        public string VhModelo { get; set; }

        [JsonProperty("vh_color")]
        public string VhColor { get; set; }

        [JsonProperty("vh_marca")]
        public string VhMarca { get; set; }

        [JsonProperty("id_cliente")]
        public int IdCliente { get; set; }

        [JsonProperty("id_empleado")]
        public int IdEmpleado { get; set; }
    }
}
