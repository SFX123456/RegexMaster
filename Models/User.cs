using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using RegexMaster.DB;

namespace RegexMaster.Models;

public class User : IdentityUser
{
    public ICollection<RewardUser> RewardUsers { get; set; } 
    public ICollection<Level> CreatedLevels { get; set; } 
    public ICollection<Campaign> LastChangedCampaigns { get; set; } 
    public ICollection<Comment> Comments{ get; set; } 
    public ICollection<VotesLevel> VotesLevels{ get; set; } 
    public ICollection<VotesComment> VotesComments{ get; set; } 
    public ICollection<Solution> Solutions{ get; set; } 
    public ICollection<TestResult> TestResults{ get; set; } 
    
    public User() : base()
    {
        
    }
}