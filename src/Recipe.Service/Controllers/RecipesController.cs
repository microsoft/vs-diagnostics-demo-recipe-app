using Recipe.Service.Models;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace Recipe.Service.Controllers
{
    public class RecipesController : ApiController
    {
        [HttpGet]
        public Models.Recipe Get(string id)
        {
            long idAsLong = 0;
            if (!long.TryParse(id, out idAsLong))
            {
                throw new HttpException(404, "Invalid id");
            }

            Models.Recipe recipe = Models.RecipeManager.Singleton.GetRecipeById(idAsLong);

            if(recipe == null)
            {
                throw new HttpException(404, $"Recipe not found for id {id}");
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
            return RecipeManager.Singleton.Search(start, limit, sortBy, orderBy);
        }
    }
}