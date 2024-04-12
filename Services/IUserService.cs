namespace AppLogin.Services
{
    public interface IUserService
    {
        User? ValidateUser(string username, string password);
        User RegisterUser(string name, string username, string email, string password);
        User? GetUserByUsername(string username);
        User? UpdateUser(string name, string username, string email, string password);
        User? GetUserByUsernameOrEmail(string username, string email);
        void CreateUser(User user);
    }
}
