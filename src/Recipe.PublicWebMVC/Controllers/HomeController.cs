using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PublicWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using System.Text;

namespace PublicWebMVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        // GET: 
        [HttpGet]
        public async Task<IActionResult> CreateRecipe() {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateRecipe() {

        //}

        public async Task<IActionResult> SearchResults(string searchString)
        {
            IList<Models.Recipe> recipes = null;

            if (!String.IsNullOrEmpty(searchString)) {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:64407/api/recipes/search/");
                HttpResponseMessage response = await client.GetAsync(searchString);

                if (response.IsSuccessStatusCode)
                {
                    recipes = await response.Content.ReadAsAsync<IList<Models.Recipe>>();
                    //recipe = JsonConvert.DeserializeObject<Recipe.Service.Models.Recipe>(recipeString);
                }
                else {

                }
            }
            
            return View(recipes);
        }

        public async Task<IActionResult> Recipe(string id)
        {
            long idAsLong = 0;
            if (!long.TryParse(id, out idAsLong))
            {
                throw new Exception("Invalid id");
            }

            Models.Recipe recipe = await GetRecipeById(idAsLong);

            if (recipe == null)
            {
                throw new Exception($"Recipe not found for id {id}");
            }

            // increase hit count for selected recipe
            recipe.Hits++;

            // update recipe with new hit
            StringContent content = new StringContent(JsonConvert.SerializeObject(recipe), Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64407/api/recipes/update/");
            HttpResponseMessage response = await client.PutAsync($"{recipe.Id}", content);
            response.EnsureSuccessStatusCode();

            return View(recipe);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private RestClient apiClient;

        private async Task<Models.Recipe> GetRecipeById(long id)
        {
            // Note: This is all crazytown code to demonstrate snapshots on exceptions
            apiClient = new RestClient("http://localhost:64407"); //http://localhost:64407
            RestRequest request = new RestRequest();
            request.Resource = "api/recipes/{id}";
            request.AddUrlSegment("id", id);

            IRestResponse<Models.Recipe> response = null;

            try
            {
                response = await ExecuteRestSharpAsync(request);
            } 
            catch(Exception ex)
            {
                // Todo: Log errors...
                return null;
            }
            
            return response.Data;
        }

        private async Task<IRestResponse<Models.Recipe>> ExecuteRestSharpAsync(RestRequest request)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            IRestResponse<Models.Recipe> response = await apiClient.ExecuteTaskAsync<Models.Recipe>(request, cancellationTokenSource.Token);
            if(response.ErrorException != null)
            {
                throw response.ErrorException;
            }
            return response;
        }

        private string GetRecipeJsonById(long id)
        {
            return "";
        }

    }
}
