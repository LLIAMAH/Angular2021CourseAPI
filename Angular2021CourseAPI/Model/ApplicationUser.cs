namespace Angular2021CourseAPI.Model
{
    public interface IUser
    {
        long Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string Token { get; set; }
    }

    public class ApplicationUser : IUser
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }

    public interface IResponseUser : IResponse<IUser>
    {
    }

    public interface IResponseUsers : IResponse<IList<IUser>>
    {
    }

    public class ResponseUser : IResponseUser
    {
        public IResponseStatus Status { get; init; }
        public IUser? Data { get; init; }

        public ResponseUser(IUser data, IResponseStatus status)
        {
            this.Data = data;
            this.Status = status;
        }
    }

    public class ResponseUsers : IResponseUsers
    {
        public IResponseStatus Status { get; init; }
        public IList<IUser>? Data { get; init; }

        public ResponseUsers(IList<IUser> data, IResponseStatus status)
        {
            this.Data = data;
            this.Status = status;
        }
    }
}