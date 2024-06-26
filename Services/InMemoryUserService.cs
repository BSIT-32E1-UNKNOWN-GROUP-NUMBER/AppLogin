namespace AppLogin.Services
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users = new List<User>();

        public User? ValidateUser(string username, string password)
        {
            return users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
        
         public User RegisterUser(string name, string username, string email, string password)
        {
            var user = new User { Name = name, Username = username, Email = email, Password = password };
            users.Add(user);
            return user;
        }
        public User? GetUserByUsername(string username)
        {
            return users.FirstOrDefault(u => u.Username == username);
        }
        public User? UpdateUser(string name, string username, string email, string password)
        {
            var user = users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                user.Name = name;
                user.Email = email;
                user.Password = password;
            }
            return user;
        }
        public User? GetUserByUsernameOrEmail(string username, string email)
        {
            return users.FirstOrDefault(u => u.Username == username || u.Email == email);
        }

        public void CreateUser(User user)
        {
            users.Add(user);
        }
    }
}