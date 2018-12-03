using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PublicWebMVC.Models;

namespace PublicWebMVC.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult View(string id)
        {
            // TIP: 03 - Step into specific
            Models.Recipe recipe = GetRecipeById(RecipeManager.Singleton.GetIdFromString(id));

            if (recipe == null)
            {
                throw new Exception($"Recipe not found for id {id}");
            }

            RecipeViewModel recipeViewModel = new RecipeViewModel(recipe);

            return View(recipeViewModel);
        }

        private Models.Recipe GetRecipeById(long id)
        {
            return RecipeManager.Singleton.GetRecipeById(id);
        }
    }
}