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
            IEnumerable<Recipe> recipes =  (from recipe in Recipes.Values
                                            orderby recipe.SpoonacularScore descending
                                            select recipe).Skip(start).Take(limit);
            // var temp = "   Hello world!   ".ToLower().ToUpper().Trim();
            return recipes.ToList();
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