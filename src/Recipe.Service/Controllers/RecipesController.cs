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
        [Route("api/recipes/{name}")]
        [HttpGet]
        public Models.Recipe Get(string name)
        {
            //List<Models.Recipe> recipes = Models.RecipeManager.Singleton.GetRecipeByName(name);
            Models.Recipe recipe = RecipeManager.Singleton.GetRecipeByName(name);

            if (recipe == null)
            {
                throw new HttpException(404, $"Recipe not found for name {name}");
            }
            return recipe;
        }

        /// <summary>
        /// Lists an index of all recipes
        /// </summary>
        /// <param name="start">Offset of first item to return. Defaul is 0.</param>
        /// <param name="limit">How many items to return. Default is 10.</param>
        /// <param name="sortBy">The field which to sort by. Default is lastUpdateDate.</param>
        /// <param name="orderBy">The order in which the results are sorted (desc or asc). Default is desc.</param>
        /// <response code="200">Array of recipes</response>
        [HttpGet]
        public List<Models.Recipe> GetAll(int start = 0, int limit = 10, string sortBy = "lastUpdateDate", string orderBy = "desc")
        {
            return RecipeManager.Singleton.GetRecipes(start, limit, sortBy, orderBy);
        }
    }
}