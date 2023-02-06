using Angular2021CourseAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Angular2021CourseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;

        private static IList<IUser> _users = new List<IUser>()
        {
            new ApplicationUser()
                { Id = 1, Name = "Test 1", Email = "test1@test.com", Password = "qwerty", Token = "token" },
            new ApplicationUser()
                { Id = 2, Name = "Test 2", Email = "test2@test.com", Password = "qwerty", Token = "token" },
            new ApplicationUser()
                { Id = 3, Name = "Test 3", Email = "test3@test.com", Password = "qwerty", Token = "token" },
            new ApplicationUser()
                { Id = 4, Name = "Test 4", Email = "test4@test.com", Password = "qwerty", Token = "token" },
            new ApplicationUser()
                { Id = 5, Name = "Test 5", Email = "test5@test.com", Password = "qwerty", Token = "token" },
            new ApplicationUser()
                { Id = 6, Name = "Test 6", Email = "test6@test.com", Password = "qwerty", Token = "token" },
        };

        public AuthController(ILogger<AuthController> logger)
        {
            this._logger = logger;
        }

        [HttpGet]
        public IResponseUsers Get()
        {
            return new ResponseUsers(_users, new ResponseStatus(EnumResponseStatus.OK));
        }

        [HttpGet("{id}")]
        public IResponseUser Get(long id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            if (user != null)
                return new ResponseUser(user, new ResponseStatus(EnumResponseStatus.OK));

            return new ResponseUser(null,
                new ResponseStatus(EnumResponseStatus.Warning, $"User by id='{id}' is not found."));
        }

        [HttpGet("{username}/{password}")]
        public IResponseUser Get(string username, string password)
        {
            var user = _users.FirstOrDefault(x => x.Name.Equals(username) && x.Password.Equals(password));
            if (user != null)
                return new ResponseUser(user, new ResponseStatus(EnumResponseStatus.OK));

            return new ResponseUser(null,
                new ResponseStatus(EnumResponseStatus.Warning, $"User is not signed up."));
        }

        [HttpPost]
        public IResponseBool Post(string name, string email, string password)
        {
            var found = _users.Where(o =>
                o.Email.Equals(email, StringComparison.OrdinalIgnoreCase) ||
                o.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (found.Any())
                return new ResponseBool(false,
                    new ResponseStatus(EnumResponseStatus.Warning,
                        $"user with1 such name='{name}' or email='{email}' already exists"));

            var idNew = _users.Max(o => o.Id) + 1;
            _users.Add(new ApplicationUser()
            { Id = idNew, Name = name, Email = email, Password = password, Token = "token" });

            return new ResponseBool(true, new ResponseStatus(EnumResponseStatus.OK));
        }
    }
}
