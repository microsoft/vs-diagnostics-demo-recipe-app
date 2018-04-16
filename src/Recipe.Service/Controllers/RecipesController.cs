using Recipe.Service.Models;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Recipe.Service.Controllers
{
    [EnableCors("*", "*", "*")]
    public class RecipesController : ApiController
    {
        /// <summary>
        /// Lists an index of all recipes
        /// </summary>
        /// <param name="start">Offset of first item to return. Defaul is 0.</param>
        /// <param name="limit">How many items to return. Default is 10.</param>
        /// <param name="sortBy">The field which to sort by. Default is lastUpdateDate.</param>
        /// <param name="orderBy">The order in which the results are sorted (desc or asc). Default is desc.</param>
        /// <response code="200">Array of recipes</response>
        [Route("api/recipes/")]
        [HttpGet]
        public List<Models.Recipe> GetAll(int start = 0, int limit = 10, string sortBy = "lastUpdateDate", string orderBy = "desc")
        {
            return RecipeManager.Singleton.GetRecipes(start, limit, sortBy, orderBy);
        }

        [Route("api/recipes/{id}")]
        [HttpGet]
        public Models.Recipe Get(string id)
        {
            long idAsLong = 0;
            if (!long.TryParse(id, out idAsLong))
            {
                throw new HttpException(404, "Invalid id");
            }

            Models.Recipe recipe = Models.RecipeManager.Singleton.GetRecipeById(idAsLong);

            if (recipe == null)
            {
                throw new HttpException(404, $"Recipe not found for id {id}");
            }

            return recipe;
        }

        [Route("api/recipes/search/{name}")]
        [HttpGet]
        public List<Models.Recipe> GetByName(string name)
        {
            List<Models.Recipe> recipes = RecipeManager.Singleton.GetRecipesByName(name);

            if (recipes == null)
            {
                throw new HttpException(404, $"Recipes not found for name {name}");
            }
            return recipes;
        }


        [Route("api/recipes/speedtest/")]
        [HttpGet]
        public bool SpeedTest()
        {
            return RecipeManager.Singleton.SpeedTest();
        }
    }
}