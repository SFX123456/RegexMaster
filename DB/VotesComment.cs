using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RegexMaster.Models;

namespace RegexMaster.DB;

public class VotesComment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public bool Upvote { get; set; }

    public User User { get; set; }
    public string UserId { get; set; }

    public Comment Comment { get; set; }
    public int CommentId { get; set; }
}