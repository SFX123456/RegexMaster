using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RegexMaster.Models;

namespace RegexMaster.DB;

public class Solution
{
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public User User { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastChanged { get; set; }
    public string Description { get; set; }
    public bool Visible { get; set; }
    public TestResult TestResult {get; set; } 
    public int TestResultId {get; set; } 
}