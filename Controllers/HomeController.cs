using System.Diagnostics;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegexMaster.DB;
using RegexMaster.Models;

namespace RegexMaster.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserContext _userContext;

    public HomeController(ILogger<HomeController> logger, UserContext userContext)
    {
        _logger = logger;
        _userContext = userContext;
    }

    public string Index()
    {
        Console.WriteLine("hallo");
        var d =  _userContext.Users.ToList();
        foreach (User user in d)
        {
            Console.WriteLine(user.Id); 
        }

        return "hallo";
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public string Welcome(string name, int numTimes = 1)
    {
        return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
