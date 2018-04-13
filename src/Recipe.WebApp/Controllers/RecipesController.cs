using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Recipe.WebApp.Controllers
{
    public class RecipesController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Recipe.Service.Models.Recipe> recipes = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64407/api/");

                //HTTP GET
                var responseTask = client.GetAsync("recipes");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Recipe.Service.Models.Recipe>>();
                    readTask.Wait();

                    recipes = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    recipes = Enumerable.Empty<Recipe.Service.Models.Recipe>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(recipes);
        }
    }
}