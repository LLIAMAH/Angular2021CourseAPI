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

        /// <summary>
        /// Initializes a new instance of the <see cref="DataApiController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public DataApiController(ILogger<DataApiController> logger)
        {
            _logger = logger;
        }

    }
}
