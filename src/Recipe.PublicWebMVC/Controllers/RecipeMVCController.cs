using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Recipe.Service.Models;

namespace Recipe.PublicWebMVC.Controllers
{
    public class RecipeMVCController : Controller
    {
        public async Task<IActionResult> Index(string searchString)
        {
            Service.Models.Recipe recipe = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64407/api/recipes/");
            HttpResponseMessage response = await client.GetAsync(searchString);

            if (response.IsSuccessStatusCode)
            {
                recipe = await response.Content.ReadAsAsync<Service.Models.Recipe>();
                System.Console.Write(recipe);
            }
            System.Console.Write(recipe);


            return View(recipe);
        }
    }
}