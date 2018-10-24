using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml;

namespace ConsoleRecipes
{
    class Program
    {
        private string RecipesPath = "App_Data/Recipes";
        private Dictionary<long?, Recipe> Recipes = new Dictionary<long?, Recipe>();
        private Random rand = new Random();

        public Program() {

            foreach (string fileName in Directory.GetFiles(RecipesPath))
            {
                string json = File.ReadAllText(fileName);
                Recipe recipe = LoadRecipeFromJson(json);
                recipe.Hits = 0; //initialize # of clicks to 0 for each recipe
                Recipes.Add(recipe.Id, recipe);
            }
            keysEnumerator = Recipes.Keys.GetEnumerator();
        }

        private Recipe LoadRecipeFromJson(string json)
        {
            return JsonConvert.DeserializeObject<Recipe>(json, Converter.Settings);
        }

        private IEnumerator<long?> keysEnumerator;
        public Recipe NextRecipe
        {
            get
            {
                if (!keysEnumerator.MoveNext())
                {
                    keysEnumerator.Reset();
                }

                return Recipes[keysEnumerator.Current];
            }
            set { }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
        }
    }
}
