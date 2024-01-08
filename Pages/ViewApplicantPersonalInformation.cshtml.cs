using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json;

using System.Net.Http;
using System.Text;

using VisaApplicationUI.Model;

namespace VisaApplicationUI.Pages
{
	public class ViewApplicantPersonalInformationModel : PageModel
	{
		private readonly HttpClient _httpClient;
		[BindProperty]
		public ApplicantInformationViewModel applicantInformationViewModel { get; set; } = default!;
		public ViewApplicantPersonalInformationModel(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("Visa.api");
		}
		public async Task OnGet()
		{
			try
			{
				string applicantId = JsonConvert.DeserializeObject<ApplicantInformationViewModel>(HttpContext.Session.GetString("AppSes")).PkApplicantId.ToString();
				var request = new HttpRequestMessage(HttpMethod.Get, _httpClient.BaseAddress + "GetApplicantInformation?ApplicantId=" + applicantId);

				applicantInformationViewModel = new ApplicantInformationViewModel();
				var response = await _httpClient.GetAsync(request.RequestUri).ConfigureAwait(false);
				string rsp = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
				applicantInformationViewModel = JsonConvert.DeserializeObject<ApplicantInformationViewModel>(rsp);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<IActionResult> OnPostAsync()
		{

			try
			{
				string applicantId = JsonConvert.DeserializeObject<ApplicantInformationViewModel>(HttpContext.Session.GetString("AppSes")).PkApplicantId.ToString();
				var addOrUpdateApplicantModel = new AddOrUpdateApplicantModel()
				{
					Name = applicantInformationViewModel.Name,
					ContactNo = applicantInformationViewModel.ContactNo,
					CreationDateTime = DateTime.Now,
					Email = applicantInformationViewModel.Email,
					Username = applicantInformationViewModel.Username,
					Password = ""
				};

				var request = new HttpRequestMessage(HttpMethod.Post, _httpClient.BaseAddress + "UpdateApplicant?applicantId=" + applicantId);
				StringContent content = new StringContent(JsonConvert.SerializeObject(addOrUpdateApplicantModel), Encoding.UTF8, "application/json");

				var response = await _httpClient.PostAsync(request.RequestUri, content).ConfigureAwait(false);
				string rsp = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

				if (response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					TempData["Success"] = "Record Updated Successfuly!";
					return Page();
				}
				else
				{
					ViewData["Error"] = "Unable To Update Record!";
					return Page();
				}

			}
			catch (Exception ex)
			{
				return RedirectToPage("Error");
			}
		}
	}
}
