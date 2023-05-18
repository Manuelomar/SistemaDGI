using AutoMapper;
using DGI.Application.Common.Exceptions;
using DGI.Application.Features.Taxpayers.Responses;
using DGI.Application.Features.TaxReceipt.Requests;
using DGI.Application.Features.TaxReceipt.Responses;
using DGI.Application.Interfaces;
using DGI.Application.Interfaces.Services;

namespace DGI.Application.Features.TaxReceipt.Services
{
    public class TaxReceiptService : ITaxReceiptService
    {
        private readonly IBaseRepository<Domain.Entities.Vouchers.TaxReceipt> _taxReceiptRepository;
        private readonly IMapper _mapper;

        public TaxReceiptService(IBaseRepository<Domain.Entities.Vouchers.TaxReceipt> taxReceiptRepository, IMapper mapper)
        {
            _taxReceiptRepository = taxReceiptRepository;
            _mapper = mapper;
        }

        public async Task<TaxReceiptResponseDto> CreateTaxReceipt(CreateTaxReceiptRequest request, CancellationToken cancellationToken = default)
        {
            request.Id= Guid.NewGuid().ToString();
            bool taxReceiptExists = _taxReceiptRepository.Query().Any(x => x.IdentificationNumber == request.IdentificationNumber);
            if (taxReceiptExists) throw new BadRequestException($"Taxpayer: {request.IdentificationNumber} exists");

            decimal Itbis = request.Amount * 0.18M;

            var TaxReceiptEntity = _mapper.Map<Domain.Entities.Vouchers.TaxReceipt>(request);

            TaxReceiptEntity.Itbis18 = Itbis;

            var taxpayer = await _taxReceiptRepository.AddAsync(TaxReceiptEntity, cancellationToken);

            var dto = _mapper.Map<TaxReceiptResponseDto>(taxpayer);

            dto.Itbis18 = Itbis;

            return dto;
        }

        public async Task<List<TaxReceiptResponseDto>> GetTaxReceipt()
        {

            var taxReceipts = await _taxReceiptRepository.GetAllAsync();
            var dtos = _mapper.Map<List<TaxReceiptResponseDto>>(taxReceipts);
            return dtos;

        }

        
    }
}
