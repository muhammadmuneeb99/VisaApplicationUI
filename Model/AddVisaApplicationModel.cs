using System.ComponentModel.DataAnnotations;

namespace VisaApplicationUI.Model
{
	public class AddVisaApplicationModel
	{
		public string Title { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string FatherName { get; set; }

		public string MotherName { get; set; }

		public string Nationality { get; set; }

		public string PlaceOfBirth { get; set; }

		public DateTime DateOfBirth { get; set; }

		public string Gender { get; set; }

		public string PassportNo { get; set; }

		public string PlaceOfIssue { get; set; }

		public DateTime DateOfIssue { get; set; }

		public DateTime DateOfExpiry { get; set; }

		public string Country { get; set; }

		public string PermanentAddress { get; set; }

		public string Telephone { get; set; }

		public string Email { get; set; }
		public string PurposeOfEntry { get; set; }
		public int VisaType { get; set; }
		public DateTime CreationDateTime { get; set; }
		public int ApplicantId { get; set; }
		public SponsorOrHost SponsorOrHost { get; set; }
		public List<ApplicationDocument> ApplicationDocument { get; set; }
		public List<ApplicationStatus> ApplicationStatus { get; set; }
	}

	public class SponsorOrHost
	{
		public string NameOfSponsorOrHost { get; set; }
		public string Profession { get; set; }
		public string Nationality { get; set; }
		public string Telephone { get; set; }
		public string PassportNo { get; set; }
		public string Address { get; set; }
		public string Country { get; set; }
		public DateTime CreationDateTime { get; set; }
	}

	public class ApplicationDocument
	{
		public string DocumentName { get; set; }
		public string DocumentType { get; set; }
		public string DocumentPath { get; set; }
	}
	public class ApplicationStatus
	{
		public string Status { get; set; }
		public DateTime LastUpdated { get; set; }
	}
}
