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
using RestSharp;

namespace PublicWebMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string searchString)
        {
            // TIP: 00 - F10 to launch
            List<Recipe> recipes = null;

            // TIP: 01 - Run to click
            // TIP: 02 - Set next statement
            if (!String.IsNullOrEmpty(searchString))
            {
                recipes = RecipeManager.Singleton.GetRecipesByName(searchString);
            }
            else
            {
                recipes = RecipeManager.Singleton.GetRecipes(0, 20, "lastUpdateDate", "desc");
            }
            // TIP: 09b -Debugg Display
            IndexViewModel viewModel = new IndexViewModel(recipes);      
            
            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
