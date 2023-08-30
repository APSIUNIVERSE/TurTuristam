using System.ComponentModel.DataAnnotations;

namespace Auth.Models;

public class LoginViewModel
{
    [Required]
    [EmailAddress]
    public string nametur { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string passwordtur { get; set; }
}