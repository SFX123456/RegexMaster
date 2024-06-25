using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RegexMaster.Models;

namespace RegexMaster.DB;

public class TestResult
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public bool Successfull { get; set; }
    
    public User User { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public Level Level;
    public int LevelId { get; set; }
    public string SolutionStr { get; set; }
    public Solution Solution { get; set; }
}