using AutoMapper;
using DGI.Application.Features.Taxpayers.Requests;
using DGI.Application.Features.Taxpayers.Responses;
using DGI.Application.Features.TaxReceipt.Responses;
using DGI.Domain.Entities.Taxpayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGI.Application.Features.Taxpayers.Mappings
{
    public class TaxpayerMappingProfile : Profile
    {
        public TaxpayerMappingProfile()
        {
            CreateMap<Taxpayer, CreateTaxpayerRequest>().ReverseMap();
            CreateMap<Taxpayer, TaxpayerResponseDto>().ReverseMap();
            CreateMap<Taxpayer, TaxpayerTotalItbisResponseDto>().ReverseMap();


        }
    }
}
