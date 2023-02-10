using Microsoft.EntityFrameworkCore;
using Notissimus_test.DAL.Entities;
using Notissimus_test.DAL.Interfaces;

namespace Notissimus_test.DAL
{
    public class OfferRepository : IOfferRepository
    {
        private OfferDbContext _dbContext;
        public OfferRepository(OfferDbContext context) => _dbContext = context;

        public OfferEntity Get(long id)
        {
            return _dbContext.Offers.SingleOrDefault(offer => offer.Id == id);
        }
        public void Create(OfferEntity entity)
        {
            _dbContext.Offers.Add(entity);
		}
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
