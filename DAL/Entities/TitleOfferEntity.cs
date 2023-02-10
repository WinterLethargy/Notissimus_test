using System.Xml.Serialization;

namespace Notissimus_test.DAL.Entities
{
	[XmlRoot("offer")]
	public class TitleOfferEntity : OfferEntity
	{
		[XmlElement("year")]
		public int Year { get; set; }

		[XmlElement("delivery")]
		public bool Delivery { get; set; }

		[XmlElement("title")]
		public string Title { get; set; }

		[XmlElement("media")]
		public string Media { get; set; }
	}
}
