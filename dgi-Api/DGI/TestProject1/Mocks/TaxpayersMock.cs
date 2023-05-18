using AutoFixture;
using DGI.Application.Interfaces;
using DGI.Domain.Entities.Taxpayers;
using DGI.Infrastructure.Persistence.Context;
using DGI.Infrastructure.Persistence.Repositories;

namespace TestProject1.Mocks;

public class TaxpayersMock
{
    public static BaseRepository<Taxpayer> GetTaxpayersRepository(ApplicationDbContext contextFake)
    {
        var fixture = new Fixture();
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        var knowledges = fixture.CreateMany<Taxpayer>().ToList();

        knowledges.Add(fixture.Build<Taxpayer>()
            .With(ur => ur.Id, "791a82cd-7d73-4ec1-bbeb-42fb9b62f4c4").Create());

        contextFake.Taxpayers.AddRange(knowledges);
        contextFake.SaveChanges();

        return new BaseRepository<Taxpayer>(contextFake);
    }


}
