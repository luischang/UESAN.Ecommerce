using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UESAN.Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeminiController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public GeminiController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpPost("generate-content")]
        public async Task<IActionResult> GenerateContent([FromBody] object prompt)
        {
            var geminiSettings = _configuration.GetSection("GeminiSettings");
            var apiKey = geminiSettings["ApiKey"];
            var model = geminiSettings["Model"];
            var url = $"https://generativelanguage.googleapis.com/v1beta/models/{model}:generateContent?key={apiKey}";

            var client = _httpClientFactory.CreateClient();
            var requestBody = JsonSerializer.Serialize(new
            {
                contents = new[] {
                    new {
                        parts = new[] {
                            new { text = prompt?.ToString() }
                        }
                    }
                }
            });

            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            var responseString = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, responseString);
            }
            return Ok(JsonDocument.Parse(responseString));
        }
    }
}
