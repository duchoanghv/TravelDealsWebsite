using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelDealsWebsite.Models
{
    public class OrderProductModel
    {
		public int Id { get; set; }
		public int OrderId { get; set; }
		public int ProductId { get; set; }
		public int Price { get; set; }
		public int Discount { get; set; }
		public string ExtService { get; set; }
		public int Number { get; set; }
        public OrderProductModel()
        {

        }
		public OrderProductModel(int Id_, int OrderId_, int ProductId_, int Price_, int Discount_, string ExtService_, int Number_)
		{
			this.Id = Id_;
			this.OrderId = OrderId_;
			this.ProductId = ProductId_;
			this.Price = Price_;
			this.Discount = Discount_;
			this.ExtService = ExtService_;
			this.Number = Number_;
		}
	}
}
