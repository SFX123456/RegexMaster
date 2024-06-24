using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegexMaster.DB;

public class Reward
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string ShortDesc { get; set; }
    public string LongDesc { get; set; }
    public DateTime AvailableFrom { get; set; }
    public string IconUrl { get; set; }
    public ICollection<RewardUser> RewardsUsers { get; set; }
    public ICollection<Campaign> Campaigns { get; set; }
}