using Angular2021CourseAPI.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Angular2021CourseAPI.Controllers
{
    /// <summary>
    /// The recipes book.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesBook : ControllerBase
    {
        private static List<Recipe>? _recipeBook = null;
        private readonly ILogger<RecipesBook> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipesBook"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public RecipesBook(ILogger<RecipesBook> logger)
        {
            this._logger = logger;
            _recipeBook = new List<Recipe>();
        }

        /// <summary>
        /// Gets the recipe by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Recipe? .</returns>
        private static Recipe? GetRecipeById(long id)
        {
            return _recipeBook?.FirstOrDefault(o => o.Id == id);
        }

        // GET: api/<RecipesBook>
        /// <summary>
        /// Gets the.
        /// </summary>
        /// <returns>An IResponse.</returns>
        [HttpGet]
        public IResponse<IEnumerable<Recipe>> Get()
        {
            return _recipeBook != null
                ? new ResponseRecipes(_recipeBook, new ResponseStatus(EnumResponseStatus.OK))
                : new ResponseRecipes(new List<Recipe>(),
                    new ResponseStatus(EnumResponseStatus.Warning, "Recipe book is empty."));
        }

        // GET api/<RecipesBook>/5
        /// <summary>
        /// Gets the.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>An IResponse.</returns>
        [HttpGet("{id}")]
        public IResponse<Recipe> Get(int id)
        {
            var result = GetRecipeById(id);
            return result != null
                ? new Response<Recipe>(result, new ResponseStatus(EnumResponseStatus.OK))
                : new Response<Recipe>(null,
                    new ResponseStatus(EnumResponseStatus.Warning, $"Data by request (id == {id}) - was not found."));
        }

        // POST api/<RecipesBook>
        /// <summary>
        /// Posts the.
        /// </summary>
        /// <param name="recipe">The recipe.</param>
        /// <returns>An IResponse.</returns>
        [HttpPost]
        public IResponse<bool> Post(Recipe recipe)
        {
            var result = _recipeBook?.FirstOrDefault(o => o.Name.Equals(recipe.Name, StringComparison.OrdinalIgnoreCase));
            if (result != null)
            {
                return new Response<bool>(false,
                    new ResponseStatus(EnumResponseStatus.Warning,
                        $"Recipe with same title '{recipe.Name}' - already exists"));
            }

            _recipeBook?.Add(recipe);
            return new ResponseBool(true, new ResponseStatus(EnumResponseStatus.OK));
        }

        // PUT api/<RecipesBook>/5
        /// <summary>
        /// Puts the.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="recipe">The recipe.</param>
        /// <returns>An IResponse.</returns>
        [HttpPut("{id}")]
        public IResponse<bool> Put(long id, Recipe recipe)
        {
            var recipeToChange = GetRecipeById(id);
            if (recipeToChange != null)
            {
                recipeToChange.Name = recipe.Name;
                recipeToChange.Description = recipe.Description;
                recipeToChange.ImagePath = recipe.ImagePath;
                recipeToChange.Ingredients.Clear();
                foreach (var recipeIngredient in recipe.Ingredients)
                    recipeToChange.Ingredients.Add(recipeIngredient);

                return new ResponseBool(true, new ResponseStatus(EnumResponseStatus.OK));
            }

            return new ResponseBool(false,
                new ResponseStatus(EnumResponseStatus.Warning, $"Data by request (id == {id}) - was not found."));
        }

        // DELETE api/<RecipesBook>/5
        /// <summary>
        /// Deletes the.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>An IResponse.</returns>
        [HttpDelete("{id}")]
        public IResponse<bool> Delete(int id)
        {
            var recipeToDelete = GetRecipeById(id);
            if (recipeToDelete != null)
            {
                _recipeBook?.Remove(recipeToDelete);
                return new ResponseBool(true, new ResponseStatus(EnumResponseStatus.OK));
            }

            return new Response<bool>(false,
                new ResponseStatus(EnumResponseStatus.Warning, $"Data by request (id == {id}) - was not found."));
        }
    }
}
