using AutoMapper;
using DGI.Application.Features.TaxReceipt.Requests;
using DGI.Application.Features.TaxReceipt.Responses;

namespace DGI.Application.Features.TaxReceipt.Mappings
{
    public class TaxReceiptMappingProfile : Profile
    {
        public TaxReceiptMappingProfile()
        {
            CreateMap<Domain.Entities.Vouchers.TaxReceipt, CreateTaxReceiptRequest>().ReverseMap();
            CreateMap<Domain.Entities.Vouchers.TaxReceipt, TaxReceiptResponseDto>().ReverseMap();

        }
    }
}
