using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RegexMaster.Models;

namespace RegexMaster.DB;

public class Comment
{
     [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
     public int Id { get; set; }
     public string CreatedFromId { get; set; }
     public User CreatedFrom { get; set; }
     public int LevelId { get; set; }
     public Level Level { get; set; }
     public int? AnswerToId { get; set; }
     public Comment AnswerTo { get; set; }
     public ICollection<Comment> AnswerToColl { get; set; }
     public DateTime CreatedAt { get; set; }
     public ICollection<VotesComment> VotesComments { get; set; }
}