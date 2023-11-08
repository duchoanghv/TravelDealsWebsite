using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelDealsWebsite.Models
{
    public class ProductModel
    {
		public int Id { get; set; }
		public int Popular { get; set; }
		public string Type { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Quantity { get; set; }
		public int RAM { get; set; }
		public int SSD { get; set; }
		public int HDD { get; set; }
		public string Screen { get; set; }
		public string CPU { get; set; }
		public string PIN { get; set; }
		public string Color { get; set; }
		public double? Weight { get; set; }
		public double? SizeW { get; set; }
		public double? SizeD { get; set; }
		public double? SizeH { get; set; }
		public string Model { get; set; }
		public string Branch { get; set; }
		public string Card { get; set; }

        public ProductModel()
        {

        }
		public ProductModel(int Id_, int Popular_, string Type_, string Name_, string Description_, int Quantity_, int RAM_, int SSD_, int HDD_, string Screen_, string CPU_, string PIN_, string Color_, double? Weight_, double? SizeW_, double? SizeD_, double? SizeH_, string Model_, string Branch_, string Card_)
		{
			this.Id = Id_;
			this.Popular = Popular_;
			this.Type = Type_;
			this.Name = Name_;
			this.Description = Description_;
			this.Quantity = Quantity_;
			this.RAM = RAM_;
			this.SSD = SSD_;
			this.HDD = HDD_;
			this.Screen = Screen_;
			this.CPU = CPU_;
			this.PIN = PIN_;
			this.Color = Color_;
			this.Weight = Weight_;
			this.SizeW = SizeW_;
			this.SizeD = SizeD_;
			this.SizeH = SizeH_;
			this.Model = Model_;
			this.Branch = Branch_;
			this.Card = Card_;
		}
	}
}
