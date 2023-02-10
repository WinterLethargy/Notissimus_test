using Microsoft.EntityFrameworkCore;
using Notissimus_test.DAL.Entities;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Notissimus_test.DAL
{
    public class OfferDbContext : DbContext
    {
        public DbSet<OfferEntity> Offers { get; set; }
        public DbSet<TitleOfferEntity> TitleOffers { get; set; }
        public DbSet<CDTitleOfferEntity> CDTitleOffers { get; set; }

        public OfferDbContext(DbContextOptions<OfferDbContext> opts) : base(opts)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<OfferEntity>().UseTptMappingStrategy();
			modelBuilder.Entity<OfferEntity>().Property(off => off.Id).ValueGeneratedNever();
		}
    }
}
