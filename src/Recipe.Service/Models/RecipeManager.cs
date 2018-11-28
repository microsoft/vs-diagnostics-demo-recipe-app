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

namespace Recipe.Service.Models
{
    public class RecipeManager
    {
        public static RecipeManager Singleton;

        static RecipeManager()
        {
            Singleton = new RecipeManager();
        }

        private string RecipesPath = "~/App_Data/Recipes";
        private Dictionary<long?, Recipe> Recipes = new Dictionary<long?, Recipe>();
        private Random rand = new Random();


        public RecipeManager()
        {
            string resolvedPath = System.Web.HttpContext.Current.Server.MapPath(RecipesPath);

            foreach (string fileName in Directory.GetFiles(resolvedPath))
            {
                string json = File.ReadAllText(fileName);
                Recipe recipe = LoadRecipeFromJson(json);
                Recipes.Add(recipe.Id, recipe);
            }
            keysEnumerator = Recipes.Keys.GetEnumerator();
        }

        public Recipe GetRecipeById(long id)
        {
            if (!Recipes.ContainsKey(id))
            {
                return null;
            }
            return Recipes[id];
        }

        public List<Recipe> GetRecipesByName(string name) {
            Recipe[] recipesArray = Recipes.Values.ToArray();
            List<Recipe> recipes = null;

            for (int i = 0; i < recipesArray.Length; i++) {

                // Perform case insensitive search
                if (recipesArray[i].Title.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0) {
                    recipes.Add(recipesArray[i]);
                }
            }
            return recipes;
        }

        public List<Recipe> GetRecipes(int start, int limit, string sortBy, string orderBy)
        {
            IEnumerable<Recipe> recipes = (from recipe in Recipes.Values
                                           orderby recipe.SpoonacularScore descending
                                           select recipe).Skip(start).Take(limit);

            //var temp = "   Hello world!   ".ToLower().ToUpper().Trim();
            return recipes.ToList();
        }

        public bool SpeedTest()
        {
            List<Recipe> linqRecipes = GetRecipesLinqSpeedTest();

            List<Recipe> bubbleSortRecipes = GetRecipesBubbleSortSpeedTest();

            // Pointless comparison.
            bool hasSameTopResult = linqRecipes[0].Id == bubbleSortRecipes[0].Id;

            return hasSameTopResult;
        }

        private Recipe LoadRecipeFromJson(string json)
        {
            return JsonConvert.DeserializeObject<Recipe>(json, Converter.Settings);
        }

        internal class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

        private List<Recipe> GetRecipesLinqSpeedTest()
        {
            List<Recipe> linqRecipes = null;
            for (int i = 0; i < 100; i++)
            {
                List<Recipe> lingqLocalCopy = new List<Recipe>(Recipes.Values);
                linqRecipes = GetRecipesLinqSpeedTestInner(lingqLocalCopy);
            }

            return linqRecipes;
        }

        private List<Recipe> GetRecipesLinqSpeedTestInner(List<Recipe> recipes)
        {
            recipes = ( from recipe in recipes
                        orderby recipe.SpoonacularScore descending
                        select recipe).Take(10).ToList();

            return recipes;
        }
        private List<Recipe> GetRecipesBubbleSortSpeedTest()
        {
            List<Recipe> bubbleSortRecipes=null;
            for (int i = 0; i < 100; i++)
            {
                List<Recipe> bubbleSortLocalCopy = new List<Recipe>(Recipes.Values);
                bubbleSortRecipes = GetRecipesBubbleSortSpeedTestInner(bubbleSortLocalCopy);
            }

            return bubbleSortRecipes;
        }

        private List<Recipe> GetRecipesBubbleSortSpeedTestInner(List<Recipe> recipes)
        {
            for (int i = 0; i < recipes.Count; i++)
            {
                for (int j = recipes.Count - 1; j > i; j--)
                {
                    if (recipes[j].SpoonacularScore < recipes[j - 1].SpoonacularScore)
                    {
                        var temp = recipes[j];
                        recipes[j] = recipes[j - 1];
                        recipes[j - 1] = temp;
                    }
                }
            }

            return recipes;
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
    }
}