using Microsoft.AspNetCore.Mvc;
using Notissimus_test.BLL.Interfaces;
using Notissimus_test.DAL;
using Notissimus_test.DAL.Entities;

namespace Notissimus_test.Controllers
{
    public class HomeController : Controller
	{
		private readonly IOfferService _offerService;

		public HomeController(IOfferService offerService) => _offerService = offerService;

		public IActionResult Index([FromRoute] long id = 12344)
		{
			var offer = _offerService.Get(id);

			if (offer == null)
			{
				return NotFound();
			}

			return View(offer);
		}
	}
}