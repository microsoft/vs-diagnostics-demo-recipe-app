using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicWebMVC.Models
{
    public class IndexViewModel
    {
        public string PageTitle;
        public List<Recipe> Recipes;

        public IndexViewModel(List<Recipe> Recipes)
        {
            this.Recipes = Recipes;
            this.PageTitle = "Recipes";
        }
    }
}
