using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RegexMaster.Models;

namespace RegexMaster.DB;

public class VotesLevel
{
    
 [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public bool Upvote { get; set; }

    public User User { get; set; }
    public string UserId { get; set; }

    public Level Level { get; set; }
    public int LevelId { get; set; }}