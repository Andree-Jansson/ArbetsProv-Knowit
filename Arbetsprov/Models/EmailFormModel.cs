using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Arbetsprov.Models
{
	public class EmailFormModel	
	{        

		//**Model for everything required when you want to send an email via the contact us page**//

		[Required, Display(Name = "Your name")]
		public string FromName { get; set; }
		[Required, Display(Name = "Your email"), EmailAddress]
		public string FromEmail { get; set; }
		[Required]
		public string Subject { get; set; }
		[Required]
		public string Message { get; set; }
	}
}