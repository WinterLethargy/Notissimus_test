using AutoMapper;
using Notissimus_test.BLL.Models;
using Notissimus_test.DAL.Entities;

namespace Notissimus_test.Options
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<OfferEntity, Offer>();
			CreateMap<Offer, OfferEntity>();

			CreateMap<TitleOffer, TitleOfferEntity>();
			CreateMap<TitleOfferEntity, TitleOffer>();

			CreateMap<CDTitleOffer, CDTitleOfferEntity>();
			CreateMap<CDTitleOfferEntity, CDTitleOffer>();
		}
	}
}
