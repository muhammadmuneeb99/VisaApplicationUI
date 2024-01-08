using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisaApplicationUI.Model
{
	public class ApplicantInformationViewModel
	{
		public int PkApplicantId { get; set; }

		public string Name { get; set; }

		public string Username { get; set; }

		public string ContactNo { get; set; }

		public string Email { get; set; }
	}
}
