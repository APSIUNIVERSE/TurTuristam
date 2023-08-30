using System.ComponentModel.DataAnnotations;

namespace Auth.Models;

public class LoginViewModelAgent
{
    [Required]
    //[EmailAddress]
    public string nameorg { get; set; }

    [Required]
    //[DataType(DataType.Password)]
    public string passwordorg { get; set; }
}