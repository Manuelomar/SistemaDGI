using AutoMapper;
using DGI.Application.Common.Exceptions;
using DGI.Application.Features.Taxpayers.Requests;
using DGI.Application.Features.Taxpayers.Responses;
using DGI.Application.Features.TaxReceipt.Responses;
using DGI.Application.Interfaces;
using DGI.Application.Interfaces.Services;
using DGI.Domain.Entities.Taxpayers;
using Microsoft.EntityFrameworkCore;

namespace DGI.Application.Features.Taxpayers.Services
{
    public class TaxpayerService : ITaxpayerService
    {
        private readonly IBaseRepository<Taxpayer> _taxpayerRepository;
        private readonly IMapper _mapper;

        public TaxpayerService(IBaseRepository<Taxpayer> taxpayerRepository, IMapper mapper)
        {
            _taxpayerRepository = taxpayerRepository;
            _mapper = mapper;
        }

        public async Task<TaxpayerTotalItbisResponseDto> GetTaxPayerById(string Id)
        {
            var taxpayer = await _taxpayerRepository.Query()
                .Where(t => t.Id == Id)
                .Include(a => a.TaxReceipt)
                .FirstOrDefaultAsync();
            var dto = _mapper.Map<TaxpayerTotalItbisResponseDto>(taxpayer);

            dto.TotalItbis = taxpayer.TaxReceipt.Sum(tr => tr.Itbis18);

            return dto;
        }
        public async Task<List<TaxpayerResponseDto>> GetTaxPayer()
        {
            var taxpayers = await _taxpayerRepository.GetAllAsync();
            var dtos = _mapper.Map<List<TaxpayerResponseDto>>(taxpayers);
            return dtos;
        }
        public async Task<TaxpayerResponseDto> CreateTaxPayer(CreateTaxpayerRequest request, CancellationToken cancellationToken = default)
        {
            request.Id = Guid.NewGuid().ToString();
            bool taxpayerExists = _taxpayerRepository.Query().Any(x => x.RncCedula == request.RncCedula);
            if (taxpayerExists) throw new BadRequestException($"Taxpayer: {request.Name} exist");

            var taxpayerEntity = _mapper.Map<Taxpayer>(request);
            var taxpayer = await _taxpayerRepository.AddAsync(taxpayerEntity, cancellationToken);
            var dto = _mapper.Map<TaxpayerResponseDto>(taxpayer);

            return dto;
        }
     
    }
}
