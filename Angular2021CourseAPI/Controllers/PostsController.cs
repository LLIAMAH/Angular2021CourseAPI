using Angular2021CourseAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace Angular2021CourseAPI.Controllers
{
    /// <summary>
    /// The posts controller.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PostsController : Controller
    {
        private static IList<Post>? _posts = null;
        private readonly ILogger<PostsController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostsController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public PostsController(ILogger<PostsController> logger)
        {
            this._logger = logger;
            InitPosts();
        }

        /// <summary>
        /// Initializes the posts list.
        /// </summary>
        private void InitPosts()
        {
            if (_posts == null || _posts.Count == 0)
            {
                _posts = new List<Post>()
                {
                    new Post() { Id = 1, Title = "Test post 1", Description = "Description of the first post" },
                };
            }
        }

        /// <summary>
        /// Gets the by title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>A Post? .</returns>
        private static Post? GetByTitle(string title)
        {
            return !string.IsNullOrEmpty(title)
                ? _posts?.FirstOrDefault(o => o.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                : null;
        }

        /// <summary>
        /// Gets the.
        /// </summary>
        /// <returns>An IResponse.</returns>
        [HttpGet(Name = "GetPosts")]
        public IResponse<IEnumerable<Post>> Get()
        {
            return _posts != null
                ? new ResponsePosts(_posts!, new ResponseStatus(EnumResponseStatus.OK))
                : new ResponsePosts(new List<Post>(),
                    new ResponseStatus(EnumResponseStatus.Warning, "Get: data list is empty."));
        }

        /// <summary>
        /// Posts the.
        /// </summary>
        /// <param name="post">The post.</param>
        /// <returns>An IResponse.</returns>
        [HttpPost(Name = "post")]
        public IResponse<bool> Post(Post? post)
        {
            if (post == null)
                return new ResponseBool(false,
                    new ResponseStatus(EnumResponseStatus.Error, "Post: passed not valid 'post' item"));

            var found = GetByTitle(post.Title);
            if (found != null)
                return new ResponseBool(false,
                    new ResponseStatus(EnumResponseStatus.Warning, "Post: this items is already in the list."));

            post.Id = _posts!.Max(o => o.Id) + 1;
            _posts!.Add(post);
            return new ResponseBool(true, new ResponseStatus(EnumResponseStatus.OK));
        }

        /// <summary>
        /// Puts the.
        /// </summary>
        /// <param name="post">The post.</param>
        /// <returns>An IResponse.</returns>
        [HttpPut(Name = "put")]
        public IResponse<bool> Put(Post? post)
        {
            if (post == null)
                return new ResponseBool(false,
                    new ResponseStatus(EnumResponseStatus.Error, "Put: passed not valid 'post' item"));

            var found = _posts!.FirstOrDefault(o => o.Id == post.Id);
            if (found == null)
                return new ResponseBool(false,
                    new ResponseStatus(EnumResponseStatus.Warning, $"Put: the item with such id='{post!.Id}' does not exist."));

            found.Title = post.Title;
            found.Description = post.Description;
            return new ResponseBool(true, new ResponseStatus(EnumResponseStatus.OK));
        }

        /// <summary>
        /// Deletes the.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>An IResponse.</returns>
        [HttpDelete(Name = "delete")]
        public IResponse<bool> Delete(long id)
        {
            var found = _posts!.FirstOrDefault(o => o.Id == id);
            if (found == null)
                return new ResponseBool(false,
                    new ResponseStatus(EnumResponseStatus.Warning, $"Delete: the item with such id='{id}' does not exist."));

            _posts!.Remove(found);
            return new ResponseBool(true, new ResponseStatus(EnumResponseStatus.OK));
        }
    }
}
