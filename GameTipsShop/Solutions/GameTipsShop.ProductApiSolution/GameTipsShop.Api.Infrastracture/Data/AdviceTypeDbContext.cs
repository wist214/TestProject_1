using GameTipsShop.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameTipsShop.Api.Infrastructure.Data
{
    public class AdviceTypeDbContext(DbContextOptions<AdviceTypeDbContext> options) : DbContext(options)
    {
        public DbSet<AdviceType> AdviceTypes { get; set; }
    }
}
