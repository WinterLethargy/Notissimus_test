using Notissimus_test.DAL.Entities;

namespace Notissimus_test.DAL.Interfaces
{
    public interface IOfferRepository
    {
        void Create(OfferEntity entity);
        OfferEntity Get(long id);
        void Save();
    }
}