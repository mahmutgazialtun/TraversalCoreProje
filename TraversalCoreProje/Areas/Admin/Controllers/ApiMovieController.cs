using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ApiMovieController : Controller
    {
		List<ApiMovieViewModel> apiMovies = new List<ApiMovieViewModel>();
        public async Task<IActionResult> Index()
        {
			//using System.Net.Http.Headers;
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-top-100-movies1.p.rapidapi.com/"),
				Headers =
	{
		{ "X-RapidAPI-Key", "4cbe1221f8msh06a8c50ab5d83d3p189c1djsn4107c3b3c679" },
		{ "X-RapidAPI-Host", "imdb-top-100-movies1.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				apiMovies = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
				return View(apiMovies);
			}
		}
    }
}
