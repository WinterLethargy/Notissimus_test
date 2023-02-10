using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Notissimus_test.DAL.Entities
{
	[XmlRoot("offer")]
	public class OfferEntity
	{
		[XmlAttribute("id")]
		public long Id { get; set; }

		[XmlAttribute("type")]
		public string Type { get; set; }

		[XmlAttribute("bid")]
		public long BId { get; set; }

		[XmlAttribute("available")]
		public bool Available { get; set; }
		[Url]
		[XmlElement("url")]
		public string Url { get; set; }

		[XmlElement("price")]
		public decimal Price { get; set; }

		[XmlElement("currencyId")]
		public string CurrencyId { get; set; }

		[XmlElement("categoryId")]
		public long CategoryId { get; set; }

		[Url]
		[XmlElement("picture")]
		public string Picture { get; set; }

		[XmlElement("description")]
		public string Description { get; set; }
	}
}
