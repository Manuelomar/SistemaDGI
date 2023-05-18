using DGI.Application.Features.Taxpayers.Requests;
using DGI.Application.Features.Taxpayers.Responses;
using DGI.Application.Features.TaxReceipt.Responses;

namespace DGI.Application.Interfaces.Services
{
    public interface ITaxpayerService
    {
        Task<TaxpayerTotalItbisResponseDto> GetTaxPayerById(string Id);
        Task<List<TaxpayerResponseDto>> GetTaxPayer();
        Task<TaxpayerResponseDto> CreateTaxPayer(CreateTaxpayerRequest request, CancellationToken cancellationToken = default);
    }
}
