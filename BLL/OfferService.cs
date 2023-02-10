using AutoMapper;
using Notissimus_test.BLL.Interfaces;
using Notissimus_test.BLL.Models;
using Notissimus_test.DAL.Entities;
using Notissimus_test.DAL.Interfaces;

namespace Notissimus_test.BLL
{
    public class OfferService : IOfferService
	{
		private IOfferRepository _repository;
		private IMapper _mapper;
		private IOfferWebProvider _webProvider;
		private ILogger<OfferService> _logger;
		public OfferService(IOfferRepository repository, IMapper mapper, IOfferWebProvider webProvider, ILogger<OfferService> logger) =>
			(_repository, _mapper, _webProvider, _logger) = (repository, mapper, webProvider, logger);
		public Offer Get(long id)
		{
			try
			{
				Offer offer = new();

				var offerEntity = _repository.Get(id);
				if (offerEntity == null)
				{
					offerEntity = _webProvider.Get(id);
					if (offerEntity != null)
					{
						_repository.Create(offerEntity);
						_repository.Save();
					}
				}

				switch (offerEntity)
				{
					case CDTitleOfferEntity:
						offer = _mapper.Map<CDTitleOffer>(offerEntity);
						break;
					case TitleOfferEntity:
						offer = _mapper.Map<TitleOffer>(offerEntity);
						break;
					case OfferEntity:
						offer = _mapper.Map<Offer>(offerEntity);
						break;
				}

				return offer;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка при получении оффера");
				return null;
			}
		}
	}
}
