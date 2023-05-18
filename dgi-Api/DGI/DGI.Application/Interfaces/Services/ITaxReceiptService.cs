using DGI.Application.Features.Taxpayers.Responses;
using DGI.Application.Features.TaxReceipt.Requests;
using DGI.Application.Features.TaxReceipt.Responses;

namespace DGI.Application.Interfaces.Services
{
    public interface ITaxReceiptService
    {
        Task<List<TaxReceiptResponseDto>> GetTaxReceipt();
        Task<TaxReceiptResponseDto> CreateTaxReceipt(CreateTaxReceiptRequest request, CancellationToken cancellationToken = default);

    }
}
