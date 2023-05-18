using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DGI.Application.Features.TaxReceipt.Responses
{
    public class TaxpayerTotalItbisResponseDto
    {
        [JsonPropertyName("RncCedula")]
        public string IdentificationNumber { get; set; }
        public string NCF { get; set; } = string.Empty;
        [JsonPropertyName("Monto")]
        public decimal Amount { get; set; }
        public decimal TotalItbis { get; set; }
        public List<TaxReceiptResponseDto> TaxReceipt { get; set; }
    }
}
