using Angular2021CourseAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace Angular2021CourseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : Controller
    {
        private IList<Post>? _posts = null;
        private readonly ILogger<PostsController> _logger;

        public PostsController(ILogger<PostsController> logger)
        {
            this._logger = logger;
            InitPosts();
        }

        private void InitPosts()
        {
            if (this._posts == null || this._posts.Count == 0)
            {
                this._posts = new List<Post>()
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
        private Post? GetByTitle(string title)
        {
            return !string.IsNullOrEmpty(title)
                ? this._posts?.FirstOrDefault(o => o.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                : null;
        }

        /// <summary>
        /// Gets the.
        /// </summary>
        /// <returns>An IResponse.</returns>
        [HttpGet(Name = "GetPosts")]
        public IResponse<IEnumerable<Post>> Get()
        {
            return this._posts != null
                ? new ResponsePosts(this._posts!, new ResponseStatus(EnumResponseStatus.OK))
                : new ResponsePosts(new List<Post>(),
                    new ResponseStatus(EnumResponseStatus.Warning, "Data list is empty."));
        }

        /// <summary>
        /// Posts the.
        /// </summary>
        /// <param name="post">The post.</param>
        /// <returns>An IResponse.</returns>
        [HttpPost(Name = "post")]
        public IResponse<bool> Post(Post post)
        {
            var found = this.GetByTitle(post.Title);
            if (found != null)
                return new ResponseBool(false,
                    new ResponseStatus(EnumResponseStatus.Warning, "This items is already in the list."));

            post.Id = this._posts!.Max(o => o.Id) + 1;
            this._posts!.Add(post);
            return new ResponseBool(true, new ResponseStatus(EnumResponseStatus.OK));
        }

        [HttpDelete(Name = "delete")]
        public IResponse<bool> Delete(long id)
        {
            var found = this._posts!.FirstOrDefault(o => o.Id == id);
            if (found == null)
                return new ResponseBool(false,
                    new ResponseStatus(EnumResponseStatus.Warning, $"The item with such id='{id}' does not exist."));

            this._posts!.Remove(found);
            return new ResponseBool(true, new ResponseStatus(EnumResponseStatus.OK));
        }
    }
}
