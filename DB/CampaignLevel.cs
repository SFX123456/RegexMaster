using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegexMaster.DB;

public class CampaignLevel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public Campaign Campaign { get; set; }
    public int CampaignId { get; set; }
    public Level Level { get; set; }
    public int LevelId { get; set; }
    public DateTime LevelAdded { get; set; }
}