using System.ComponentModel.DataAnnotations;

namespace RegexMaster.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    public string Email { get; set; }

    [DataType(DataType.Date)]
    public DateTime SignUpDate { get; set; }

    public string Password { get; set; }

}