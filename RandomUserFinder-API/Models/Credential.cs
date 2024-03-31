using System.ComponentModel.DataAnnotations;

namespace RandomUserFinder.Models;

public class Credential
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}
