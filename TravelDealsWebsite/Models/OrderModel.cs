using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelDealsWebsite.Models
{
    public class OrderModel
    {
		public int Id { get; set; }
		public string CustomerName { get; set; }
		public string Phone { get; set; }
		public string Provice { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string Note { get; set; }
		public string PaymentType { get; set; }
		public DateTime BookingDate { get; set; }
		public string ShippingType { get; set; }
		public DateTime ReceivedDate { get; set; }
        public OrderModel()
        {

        }
		public OrderModel(int Id_, string CustomerName_, string Phone_, string Provice_, string Address_, string Email_, string Note_, string PaymentType_, DateTime BookingDate_, string ShippingType_, DateTime ReceivedDate_)
		{
			this.Id = Id_;
			this.CustomerName = CustomerName_;
			this.Phone = Phone_;
			this.Provice = Provice_;
			this.Address = Address_;
			this.Email = Email_;
			this.Note = Note_;
			this.PaymentType = PaymentType_;
			this.BookingDate = BookingDate_;
			this.ShippingType = ShippingType_;
			this.ReceivedDate = ReceivedDate_;
		}
	}
}
