using DGI.Domain.Entities.Vouchers;
using DGI.Domain.Enums;
using System.Text.Json.Serialization;

namespace DGI.Domain.Entities.Taxpayers
{
    public class Taxpayer : BaseEntity
    {
        [JsonPropertyName("RncCedula")]
        public string RncCedula { get; set; }
        [JsonPropertyName("Nombre")]
        public string Name { get; set; }
        [JsonPropertyName("Tipo")]
        public string Type { get; set; }
        [JsonPropertyName("Estatus")]
        public StatusType Status { get; set; }
        public ICollection<TaxReceipt> TaxReceipt { get; set; }
    }
}
