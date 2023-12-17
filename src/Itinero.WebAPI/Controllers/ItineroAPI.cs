using System.Net.Http.Headers;
using MauiMapsui.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Spatial;

namespace Itinero.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItineroAPI : Controller
    {
        // GET
        [HttpPost("/route")]
        public async Task<string> GetRoute([FromBody] RouteRequest route)
        {
            var baseUrl = "http://localhost:5000/portugal/";

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{baseUrl}routing?profile={route.Profile}&loc={route?.StartPoint?.Latitude},{route?.StartPoint?.Longitude}&loc={route?.EndPoint?.Latitude},{route?.EndPoint?.Longitude}");
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}