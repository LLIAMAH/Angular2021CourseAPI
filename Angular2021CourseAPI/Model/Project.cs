namespace Angular2021CourseAPI.Model
{
    /// <summary>
    /// The project.
    /// </summary>
    public class Project
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
    }

    /// <summary>
    /// The response project.
    /// </summary>
    public class ResponseProject : IResponse<IList<Project>>
    {
        /// <summary>
        /// Gets the status.
        /// </summary>
        public IResponseStatus Status { get; private set; }

        /// <summary>
        /// Gets the data.
        /// </summary>
        public IList<Project> Data { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseProject"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="status">The status.</param>
        public ResponseProject(IList<Project> data, IResponseStatus status)
        {
            this.Data = data;
            this.Status = status;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseProject"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="status">The status.</param>
        /// <param name="message">The message.</param>
        public ResponseProject(IList<Project> data, EnumResponseStatus status, string message = "Succeeded")
        {
            this.Data = data;
            this.Status = new ResponseStatus(status, message);
        }
    }
}
