using System.Text.Json.Serialization;

namespace DGI.Application.Features.TaxReceipt.Requests
{
    public class CreateTaxReceiptRequest
    {
        public string Id { get; set; }

        [JsonPropertyName("RncCedula")]
        public string IdentificationNumber { get; set; }
        public string NCF { get; set; } = string.Empty;
        [JsonPropertyName("Monto")]
        public decimal Amount { get; set; }
        public string TaxpayerId { get; set; }

    }
}
