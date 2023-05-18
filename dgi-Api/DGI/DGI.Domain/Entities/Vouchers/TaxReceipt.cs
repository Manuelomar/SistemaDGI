using DGI.Domain.Entities.Taxpayers;
using System.Text.Json.Serialization;

namespace DGI.Domain.Entities.Vouchers
{
    public class TaxReceipt : BaseEntity
    {
        [JsonPropertyName("RncCedula")]
        public string IdentificationNumber { get; set; }
        public string NCF { get; set; } = string.Empty;
        [JsonPropertyName("Monto")]
        public decimal Amount { get; set; }
        public decimal Itbis18 { get; set; }
        public string TaxpayerId { get; set; }
        public Taxpayer Taxpayer { get; set; }
    }
}
