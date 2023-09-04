using System.ComponentModel.DataAnnotations;

namespace EducationPortalUI.Areas.Manager.Models
{
	public class LoginViewModel
	{
		[Required]
		public string UserNameOrEmail { get; set; }
		[Required]
		public string Password { get; set; }
	}
}
