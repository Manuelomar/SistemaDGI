using AutoMapper;
using DGI.Application.Features.Taxpayers.Requests;
using DGI.Application.Features.Taxpayers.Responses;
using DGI.Application.Features.Taxpayers.Services;
using DGI.Application.Interfaces;
using DGI.Domain.Entities.Taxpayers;
using TestProject1.Mocks;
using Xunit;

namespace TestProject1.TaxpayersUnitTest
{
    public class TaxpayersUnitTest
    {
        private readonly IBaseRepository<Taxpayer> _mock;

        public TaxpayersUnitTest()
        {
            _mock = TaxpayersMock.GetTaxpayersRepository(MockBaseContext.Get());
        }
        [Fact]
        public async Task TaxpayerService_GetAllAsync()
        {
            // Arrange
            var taxpayerService = new TaxpayerService(_mock, new MapperConfiguration(cfg => cfg.CreateMap<Taxpayer, TaxpayerResponseDto>()).CreateMapper());

            // Act
            var result = await taxpayerService.GetTaxPayer();

            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task TaxpayerService_GetByIdAsync()
        {
            // Arrange
            var taxpayerService = new TaxpayerService(_mock, new MapperConfiguration(cfg => cfg.CreateMap<Taxpayer, TaxpayerResponseDto>()).CreateMapper());
            string testId = "791a82cd-7d73-4ec1-bbeb-42fb9b62f4c4";

            // Act
            var result = await taxpayerService.GetTaxPayerById(testId);

            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task TaxpayerService_AddAsync()
        {
            // Arrange
            var taxpayerService = new TaxpayerService(_mock, new MapperConfiguration(cfg => cfg.CreateMap<CreateTaxpayerRequest, Taxpayer>().ReverseMap()).CreateMapper());
            var create = new CreateTaxpayerRequest();

            // Act
            var result = await taxpayerService.CreateTaxPayer(create, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
        }

    }
}
