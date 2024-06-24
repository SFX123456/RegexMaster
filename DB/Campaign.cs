using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RegexMaster.Models;

namespace RegexMaster.DB;

public class Campaign
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Headline { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public User LastChangedFrom { get; set; }
    public string LastChangedFromId { get; set; }
    public DateTime LastChangedTime { get; set; }
    public Reward Reward { get; set; }
    public int RewardId { get; set; }
    public ICollection<CampaignLevel> CampaignLevels { get; set; }
}