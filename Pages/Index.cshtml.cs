using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Text;

namespace VisaApplicationUI.Pages
{
	public class IndexModel : PageModel
	{
		private readonly HttpClient _httpClient;

		public IndexModel(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("Visa.api");
		}

		public void OnGet()
		{

		}

		public async Task<IActionResult> OnPostAsync()
		{
			var email = Request.Form["email"];
			var pass = Request.Form["password"];

			try
			{

				var request = new HttpRequestMessage(HttpMethod.Post, _httpClient.BaseAddress + "UserLogin");
				StringContent content = new StringContent("{\"email\": \"" + email + "\",\"password\": \"" + pass + "\"}", Encoding.UTF8, "application/json");
				
				var response = await _httpClient.PostAsync(request.RequestUri, content).ConfigureAwait(false);
				string rsp = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

				HttpContext.Session.SetString("AppSes", rsp);

				return RedirectToPage("MainPage");
			}
			catch (Exception ex)
			{
				return RedirectToPage("Error");
			}
		}
	}
}