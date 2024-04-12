using Microsoft.AspNetCore.Mvc;
using AppLogin.Services;
using AppLogin.Models;

public class LoginController : Controller
{
    private readonly IUserService _userService;

    public LoginController(IUserService userService)
    {
        _userService = userService;
    }

    public static class InMemoryDatabase
    {
        public static List<User> Users = new List<User>();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = InMemoryDatabase.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            return RedirectToAction("Dashboard", "Home");
        }
        else
        {
            ViewBag.ErrorMessage = "Invalid username or password";
            return View("~/Views/Home/Index.cshtml");
        }

    }
    [HttpGet]
    public IActionResult Login()
    {
        return View("~/Views/Home/Index.cshtml");
    }

    public IActionResult Dashboard()
    {
        return View("~/Views/Home/Dashboard.cshtml");
    }
    [HttpPost]
    public IActionResult RegisterUser(string name, string username, string email, string password)
    {
        
        var existingUser = InMemoryDatabase.Users.FirstOrDefault(u => u.Username == username || u.Email == email);

        if (existingUser != null)
        {
            
            ViewBag.ErrorMessage = "User with the same username or email already exists";
            return RedirectToAction("Index", "Home");
        }

        
        var newUser = new User
        {
            Name = name,
            Username = username,
            Email = email,
            Password = password 
        };

        
        InMemoryDatabase.Users.Add(newUser);

        
        return RedirectToAction("Index", "Home");
    }
}