using DGI.Domain.Enums;
using System.Text.Json.Serialization;

namespace DGI.Application.Features.Taxpayers.Requests
{
    public class CreateTaxpayerRequest
    {
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
