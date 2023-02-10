using Notissimus_test.DAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Notissimus_test.BLL.Models
{
    public class Offer
	{
		public long Id { get; set; }
		public string Type { get; set; }
		public long BId { get; set; }
		public bool Available { get; set; }

		[Url]
		public string Url { get; set; }
		public decimal Price { get; set; }
		public string CurrencyId { get; set; }
		public long CategoryId { get; set; }

		[Url]
		public string Picture { get; set; }
		public string Description { get; set; }
	}
}
