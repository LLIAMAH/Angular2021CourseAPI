namespace Angular2021CourseAPI.Model
{
    /// <summary>
    /// The enum response status.
    /// </summary>
    public enum EnumResponseStatus
    {
        Unknown,
        // ReSharper disable once InconsistentNaming
        OK,
        Warning,
        Error
    }

    /// <summary>
    /// The response.
    /// </summary>
    public interface IResponse<out T>
    {
        /// <summary>
        /// Gets the status.
        /// </summary>
        IResponseStatus Status { get; }

        /// <summary>
        /// Gets the data.
        /// </summary>
        T? Data { get; }
    }

    /// <summary>
    /// The response status.
    /// </summary>
    public interface IResponseStatus
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        EnumResponseStatus Value { get; }

        /// <summary>
        /// Gets the message.
        /// </summary>
        string Message { get; }
    }

    /// <summary>
    /// The response.
    /// </summary>
    public class Response<T> : IResponse<T>
    {
        /// <summary>
        /// Gets the status.
        /// </summary>
        public IResponseStatus Status { get; protected init; }

        /// <summary>
        /// Gets the data.
        /// </summary>
        public T? Data { get; protected init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Response{T}"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="status">The status.</param>
        public Response(T? data, IResponseStatus status)
        {
            Status = status;
            Data = data;
        }
    }

    /// <summary>
    /// The response status.
    /// </summary>
    public class ResponseStatus : IResponseStatus
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public EnumResponseStatus Value { get; protected set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseStatus"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="message">The message.</param>
        public ResponseStatus(EnumResponseStatus value = EnumResponseStatus.Unknown, string message = "Succeeded")
        {
            this.Value = value;
            this.Message = message;
        }
    }

    /// <summary>
    /// The response bool.
    /// </summary>
    public interface IResponseBool: IResponse<bool>{}

    /// <summary>
    /// The response bool.
    /// </summary>
    public class ResponseBool : Response<bool>, IResponseBool
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseBool"/> class.
        /// </summary>
        /// <param name="data">If true, data.</param>
        /// <param name="status">The status.</param>
        public ResponseBool(bool data, IResponseStatus status) : base(data, status) { }
    }
}
