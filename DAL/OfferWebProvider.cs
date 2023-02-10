using Microsoft.EntityFrameworkCore;
using Notissimus_test.DAL.Entities;
using Notissimus_test.DAL.Interfaces;
using System.Net;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Notissimus_test.DAL
{
    public class OfferWebProvider : IOfferWebProvider
	{
		private Uri _url;
		private Encoding _encoding;
		public OfferWebProvider(Uri url, Encoding encoding) => (_url, _encoding) = (url, encoding);
		public OfferWebProvider(Uri url) : this(url, Encoding.UTF8) { }

		public OfferEntity Get(long id)
		{
			var client = new WebClient() { Encoding = _encoding };
			var xmlStr = client.DownloadString(_url);

			var xdoc = XDocument.Parse(xmlStr);
			var stringId = id.ToString();

			var result = xdoc.Descendants("offers")
				.Elements()
				.Single(offer => offer.Attribute("id").Value == stringId);

			var type = GetOfferType(result);
			var xs = new XmlSerializer(type);

			var offer = (OfferEntity)xs.Deserialize(new StringReader(result.ToString()));
			return offer;
		}
		private Type GetOfferType(XElement element)
		{
			switch (element.Attribute("type").Value)
			{
				case "artist.title":
					return GetTitleOfferType(element);
				default:
					throw new ArgumentException("Такой тип оффера не предусмотрен");
			}
		}
		private Type GetTitleOfferType(XElement element)
		{
			switch (element.Element("media").Value)
			{
				case "CD":
					return typeof(CDTitleOfferEntity);
				default:
					throw new ArgumentException("Такой тип оффера не предусмотрен");
			}
		}
	}
}
