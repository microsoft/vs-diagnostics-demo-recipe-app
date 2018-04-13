using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PublicWebMVC.Models;
using Recipe.Service.Models;

namespace PublicWebMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> SearchResults(string searchString)
        {
            Recipe.Service.Models.Recipe recipe = null;

            if (!String.IsNullOrEmpty(searchString)) {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:64407/api/recipes/");
                HttpResponseMessage response = await client.GetAsync(searchString);

                if (response.IsSuccessStatusCode)
                {
                    string recipeString = await response.Content.ReadAsStringAsync();
                    recipe = JsonConvert.DeserializeObject<Recipe.Service.Models.Recipe>(recipeString);
                }
                else {

                }
            }
            
            return View(recipe);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
