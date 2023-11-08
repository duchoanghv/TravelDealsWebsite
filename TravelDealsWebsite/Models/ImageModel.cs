using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelDealsWebsite.Models
{
    public class ImageModel
    {
		public int Id { get; set; }
		public string FileContent { get; set; }
		public string FileName { get; set; }
		public int SizeW { get; set; }
		public int SizeD { get; set; }
		public string Description { get; set; }
		public string Title { get; set; }
		public int ProductId { get; set; }

        public ImageModel()
        {

        }
		public ImageModel(int Id_, string FileContent_, string FileName_, int SizeW_, int SizeD_, string Description_, string Title_, int ProductId_)
		{
			this.Id = Id_;
			this.FileContent = FileContent_;
			this.FileName = FileName_;
			this.SizeW = SizeW_;
			this.SizeD = SizeD_;
			this.Description = Description_;
			this.Title = Title_;
			this.ProductId = ProductId_;
		}
	}
}
