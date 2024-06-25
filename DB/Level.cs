using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RegexMaster.Models;

namespace RegexMaster.DB;

public class Level
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int Difficulty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UpVotes { get; set; }
    public int DownVotes { get; set; }
    public string Description { get; set; }
    public string Headline { get; set; }
    public string CreatedFrom { get; set; }
    public User Creater { get; set; }
    public ICollection<CampaignLevel> CampaignLevels { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<VotesLevel> VotesLevels { get; set; }
    public ICollection<TestResult> TestResults { get; set; }
}