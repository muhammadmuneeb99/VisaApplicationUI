using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json;
using System.Text;

using VisaApplicationUI.Model;

namespace VisaApplicationUI.Pages
{
    public class RegisterModel : PageModel
    {
		private readonly HttpClient _httpClient;
		[BindProperty]
		public AddOrUpdateApplicantModel addApplicantInformationModel { get; set; } = default!;
		public RegisterModel(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("Visa.api");
		}

		public void OnGet()
        {
        }

		public async Task<IActionResult> OnPostAsync()
		{

			try
			{
				var addOrUpdateApplicantModel = new AddOrUpdateApplicantModel()
				{
					Name = addApplicantInformationModel.Name,
					ContactNo = addApplicantInformationModel.ContactNo,
					CreationDateTime = DateTime.Now,
					Email = addApplicantInformationModel.Email,
					Username = addApplicantInformationModel.Username,
					Password = addApplicantInformationModel.Password
				};

				var request = new HttpRequestMessage(HttpMethod.Post, _httpClient.BaseAddress + "RegisterApplicant");
				StringContent content = new StringContent(JsonConvert.SerializeObject(addOrUpdateApplicantModel), Encoding.UTF8, "application/json");

				var response = await _httpClient.PostAsync(request.RequestUri, content).ConfigureAwait(false);
				string rsp = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

				if (response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					TempData["Success"] = "Account Created Successfuly!";
					return Page();
				}
				else
				{
					ViewData["Error"] = "Unable To Create Account!";
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
