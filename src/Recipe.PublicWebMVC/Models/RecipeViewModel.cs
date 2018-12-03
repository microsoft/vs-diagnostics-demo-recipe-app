using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicWebMVC.Models
{
    public class RecipeViewModel
    {
        public string PageTitle;
        public Recipe Recipe;

        public RecipeViewModel(Recipe Recipe)
        {
            this.Recipe = Recipe;
            this.PageTitle = Recipe.Title;
        }
    }
}
