using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;
        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }
        public IActionResult Index()
        {

            return View();
        }


        //public async Task<IActionResult> IndexAsync()
        //{
        //    try
        //    {
        //        var request = new HttpRequestMessage(HttpMethod.Get,
        //         "http://localhost:4688/RTPortfolioStatus");
               

        //        request.Headers.Add("clientid", "25");

        //        var client = _clientFactory.CreateClient();
        //        client.DefaultRequestHeaders.Clear();
        //        //Define request data format  
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        var response = await client.SendAsync(request);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            using var responseStream = await response.Content.ReadAsStreamAsync();
        //            //Branches = await JsonSerializer.DeserializeAsync
        //            //    <IEnumerable<GitHubBranch>>(responseStream);
        //        }
               
        //    }
        //    catch(Exception ex)
        //    {

        //    }
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
