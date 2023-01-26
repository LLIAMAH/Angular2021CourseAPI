using Angular2021CourseAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace Angular2021CourseAPI.Controllers
{
    /// <summary>
    /// The data api controller.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DataApiController : Controller
    {
        private readonly ILogger<DataApiController> _logger;
        private IList<Project>? _projects = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataApiController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public DataApiController(ILogger<DataApiController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the projects.
        /// </summary>
        /// <returns>A list of Projects.</returns>
        [HttpGet(Name = "GetProjects")]
        public IResponse<IEnumerable<Project>> GetProjects()
        {
            if (this._projects == null)
            {
                this._projects = new List<Project>()
                {
                    new () { Id = 1, Name = "Project 1", Description = "Description of the first project." },
                    new () { Id = 2, Name = "Project 2", Description = "Description of the second project." },
                    new () { Id = 3, Name = "Project 3", Description = "Description of the third project." },
                    new () { Id = 4, Name = "Project 4", Description = "Description of the fourth project." },
                    new () { Id = 5, Name = "Project 5", Description = "Description of the fifth project." },
                    new () { Id = 6, Name = "Project 6", Description = "Description of the sixth project." },
                    new () { Id = 7, Name = "Project 7", Description = "Description of the seventh project." }
                };
            }

            return new ResponseProject(this._projects,
                new ResponseStatus(EnumResponseStatus.OK));
        }
    }
}
