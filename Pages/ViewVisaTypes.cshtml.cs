using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Text;

using VisaApplicationUI.Model;

namespace VisaApplicationUI.Pages
{
	public class ViewVisaTypesModel : PageModel
	{
		private readonly HttpClient _httpClient;
		public IList<VisaTypeViewModel> _visaTypes { get; set; } = default!;

		public ViewVisaTypesModel(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("Visa.api");
		}
		public async Task OnGetAsync()
		{
			try
			{
				var request = new HttpRequestMessage(HttpMethod.Get, _httpClient.BaseAddress + "GetAllVisaType");

				_visaTypes = new List<VisaTypeViewModel>();
				var response = await _httpClient.GetAsync(request.RequestUri).ConfigureAwait(false);
				string rsp = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
				_visaTypes = JsonConvert.DeserializeObject<List<VisaTypeViewModel>>(rsp);
				//HttpContext.Session.SetString("AppSes", rsp);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
