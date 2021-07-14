using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Milyoner.Models;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace Milyoner.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuestion(AddQuestionModel questionModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", questionModel);

            var json = JsonConvert.SerializeObject(questionModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url =$"{_configuration["AppUrl"]}/api/Questions" ;
            using var client = new HttpClient();
            var response = await client.PostAsync(url, data);

            return View();
        }

        [Route("/Error")]
        public IActionResult Error()
        {
            return View();
        }
    }
}
