using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelDealsWebsite.Models
{
    public class AdminModel
    {
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Phone1 { get; set; }
		public string Phone2 { get; set; }
		public string Phone3 { get; set; }
		public string Email1 { get; set; }
		public string Email2 { get; set; }
		public string Email3 { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string Address3 { get; set; }
		public string Facebook { get; set; }
		public string Twitter { get; set; }
		public string LinkedIn { get; set; }

        public AdminModel()
        {

        }
		public AdminModel(string UserName_, string Password_, string Phone1_, string Phone2_, string Phone3_, string Email1_, string Email2_, string Email3_, string Address1_, string Address2_, string Address3_, string Facebook_, string Twitter_, string LinkedIn_)
		{
			this.UserName = UserName_;
			this.Password = Password_;
			this.Phone1 = Phone1_;
			this.Phone2 = Phone2_;
			this.Phone3 = Phone3_;
			this.Email1 = Email1_;
			this.Email2 = Email2_;
			this.Email3 = Email3_;
			this.Address1 = Address1_;
			this.Address2 = Address2_;
			this.Address3 = Address3_;
			this.Facebook = Facebook_;
			this.Twitter = Twitter_;
			this.LinkedIn = LinkedIn_;
		}
	}
}
