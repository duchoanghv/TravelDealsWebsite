using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelDealsWebsite.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int QualityRate { get; set; }
        public int PriceRate { get; set; }
        public int ServiceRate { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public ReviewModel()
        {

        }
        public ReviewModel(int Id_, int ProductId_, int QualityRate_, int PriceRate_, int ServiceRate_, string Name_, string Address_, string Comment_, DateTime Date_)
        {
            this.Id = Id_;
            this.ProductId = ProductId_;
            this.QualityRate = QualityRate_;
            this.PriceRate = PriceRate_;
            this.ServiceRate = ServiceRate_;
            this.Name = Name_;
            this.Address = Address_;
            this.Comment = Comment_;
            this.Date = Date_;
        }
    }
}
