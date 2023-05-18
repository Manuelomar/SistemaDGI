using DGI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DGI.Application.Features.Taxpayers.Requests
{
    public class UpdateTaxpayerRequest
    {
        [JsonIgnore]
        public string Id { get; set; }

        [JsonPropertyName("RncCedula")]
        public string RncCedula { get; set; }
        [JsonPropertyName("Nombre")]
        public string Name { get; set; }
        [JsonPropertyName("Tipo")]
        public string Type { get; set; }
        [JsonPropertyName("Estatus")]
        public StatusType Status { get; set; }
    }
}
