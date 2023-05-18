using DGI.Domain.Entities.Taxpayers;
using DGI.Domain.Entities.Vouchers;
using Microsoft.EntityFrameworkCore;

namespace DGI.Infrastructure.Persistence.Context
{
    public interface IApplicationDbContext : IDbContext { }
    public class ApplicationDbContext : BaseDbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Taxpayer> Taxpayers { get; set; }
        public DbSet<TaxReceipt> TaxReceipts { get; set; }


    }
}
