namespace Angular2021CourseAPI.Model
{
    /// <summary>
    /// The post.
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// The response posts.
    /// </summary>
    public class ResponsePosts : IResponse<IList<Post>>
    {
        /// <summary>
        /// Gets the status.
        /// </summary>
        public IResponseStatus Status { get; private set; }

        /// <summary>
        /// Gets the data.
        /// </summary>
        public IList<Post> Data { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponsePosts"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="status">The status.</param>
        public ResponsePosts(IList<Post> data, IResponseStatus status)
        {
            this.Data = data;
            this.Status = status;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponsePosts"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="message">The message.</param>
        /// <param name="status">The status.</param>
        public ResponsePosts(IList<Post> data, string message, EnumResponseStatus status)
        {
            this.Data = data;
            this.Status = new ResponseStatus(status, message);
        }
    }
}
