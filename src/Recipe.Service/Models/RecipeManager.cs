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
            string resolvedPath  = System.Web.HttpContext.Current.Server.MapPath(RecipesPath);

            foreach (string fileName in Directory.GetFiles(resolvedPath))
            {
                string json = File.ReadAllText(fileName);
                Recipe recipe = LoadRecipeFromJson(json);
                Recipes.Add(recipe.Id, recipe);
            }
        }

        public Recipe GetRecipeById(long id)
        {
            if(!Recipes.ContainsKey(id))
            {
                return null;
            }
            return Recipes[id];
        }

        public List<Recipe> GetRecipes(int start, int limit, string sortBy, string orderBy)
        {
            // Note: This is obvioussly insane and done for the sake of a demo
            Recipe[] recipesArray = Recipes.Values.ToArray();

            for (int i = 0; i < recipesArray.Length; i++)
            {
                for (int j = 0; j < recipesArray.Length - i - 1; j++)
                {
                    if (recipesArray[j].SpoonacularScore > recipesArray[j + 1].SpoonacularScore)
                    {
                        Recipe tempRecipe = recipesArray[j];
                        recipesArray[j] = recipesArray[j + 1];
                        recipesArray[j + 1] = tempRecipe;
                    }
                }
            }

            IEnumerable<Recipe> returnRecipe = recipesArray.ToList();
            returnRecipe = returnRecipe.Skip(start).Take(limit);

            return (List<Recipe>)returnRecipe.ToList();
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

    }
}