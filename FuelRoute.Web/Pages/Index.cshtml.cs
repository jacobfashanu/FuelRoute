using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;
using System.Text.Json;
using FuelRoute.Web.Models;


namespace FuelRoute.Web.Pages
{
    public class IndexModel : PageModel
    {
        // Razor DI injects a HttpClientFactory
        // This is used to send requests to the API layer
        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //The followwing properties bind to the UI inputs

        [BindProperty]
        public string? ErrorMessage { get; set; }


        [BindProperty]
        public string StartLocation { get; set; } = string.Empty;

        [BindProperty]
        public string EndLocation { get; set; } = string.Empty;

        public ApiResult? ApiResponse { get; set; }

        public async Task<IActionResult> OnPost()
        {
            // Clear previous UI state
            ApiResponse = null;
            ErrorMessage = null;

            var client = _httpClientFactory.CreateClient("FuelRouteAPI");

            var requestBody = new
            {
                startAddress = StartLocation,
                endAddress = EndLocation
            };

            var response = await client.PostAsJsonAsync("api/route/suggest/address", requestBody);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                ApiResponse = JsonSerializer.Deserialize<ApiResult>(
                    json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
            }
            else
            {
                // Extract backend error message if available
                var error = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    ErrorMessage = "No gas stations were found near your route.";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ErrorMessage = "The address could not be processed. Please check your input.";
                }
                else
                {
                    ErrorMessage = "Something went wrong while searching for gas stations.";
                }
            }

            return Page();
        }


    }
}
