using System.Xml.Serialization;

namespace Notissimus_test.BLL.Models
{
	public class TitleOffer : Offer
	{
		public int Year { get; set; }
		public bool Delivery { get; set; }
		public string Title { get; set; }
		public string Media { get; set; }
	}
}
