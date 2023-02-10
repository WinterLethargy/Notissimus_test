using System.Xml.Serialization;

namespace Notissimus_test.DAL.Entities
{
	[XmlRoot("offer")]
	public class CDTitleOfferEntity : TitleOfferEntity
	{
		[XmlElement("artist")]
		public string Artist { get; set; }
	}
}
