using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicWebMVC.Models
{
    public class SearchViewModel
    {
        public string PageTitle;
        public List<Recipe> Recipes;
        public SearchViewModel(List<Recipe> Recipes)
        {
            this.Recipes = Recipes;
            this.PageTitle = "Recipes";
        }
    }
}
