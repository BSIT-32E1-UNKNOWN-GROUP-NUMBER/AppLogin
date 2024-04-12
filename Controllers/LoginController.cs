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

}