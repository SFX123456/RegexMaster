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
    private readonly ApplicationContext _applicationContext;

    public HomeController(ILogger<HomeController> logger, ApplicationContext applicationContext)
    {
        _logger = logger;
        _applicationContext = applicationContext;
    }

    public string Index()
    {
        Console.WriteLine("hallo");
        foreach (Reward reward in _applicationContext.Rewards.ToList())
        {
            Console.WriteLine(reward); 
        }

        string userId = "3ea0a3df-4a34-45ba-9471-2d3c778e7d19";
        var x = _applicationContext.RewardsUsers
                        .Where(ur => ur.UserId == userId)
                        .Include(ur => ur.User)
                        .Include(ur => ur.Reward)
                        .ToList();
        foreach (RewardUser rewardUser in x)
        {
            if (rewardUser.User == null)
            {
                Console.WriteLine("rewarduser is null");
            }
            Console.WriteLine(rewardUser?.User.Id + " hat das achievment " + rewardUser.Reward.ShortDesc + " am " + rewardUser.AchievedAt + " erlangen");
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
