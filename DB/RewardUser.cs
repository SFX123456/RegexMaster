using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RegexMaster.Models;

namespace RegexMaster.DB;

public class RewardUser
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public User User { get; set; }
    public string UserId { get; set; }
    public Reward Reward { get; set; }
    public int RewardId { get; set; }
    public DateTime AchievedAt { get; set; }
}