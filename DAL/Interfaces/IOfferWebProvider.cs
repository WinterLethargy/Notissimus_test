using Notissimus_test.DAL.Entities;

namespace Notissimus_test.DAL.Interfaces
{
    public interface IOfferWebProvider
    {
        OfferEntity Get(long id);
    }
}