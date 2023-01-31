namespace Angular2021CourseAPI.Model
{
    /// <summary>
    /// The recipe.
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// Gets the ingredients.
        /// </summary>
        public IList<Ingredient> Ingredients { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Recipe"/> class.
        /// </summary>
        public Recipe()
        {
            this.Ingredients = new List<Ingredient>();
        }
    }

    /// <summary>
    /// The response recipes.
    /// </summary>
    public class ResponseRecipes : IResponse<IList<Recipe>>
    {
        /// <summary>
        /// Gets the status.
        /// </summary>
        public IResponseStatus Status { get; private set; }

        /// <summary>
        /// Gets the data.
        /// </summary>
        public IList<Recipe> Data { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseRecipes"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="status">The status.</param>
        public ResponseRecipes(IList<Recipe> data, IResponseStatus status)
        {
            this.Data = data;
            this.Status = status;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseRecipes"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="message">The message.</param>
        /// <param name="status">The status.</param>
        public ResponseRecipes(IList<Recipe> data, string message, EnumResponseStatus status)
        {
            this.Data = data;
            this.Status = new ResponseStatus(status, message);
        }
    }
}
