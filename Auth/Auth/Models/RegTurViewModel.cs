using System.ComponentModel.DataAnnotations;

namespace Auth.Models;

public class RegTurViewModel
{
    [EmailAddress(ErrorMessage = "Пожалуйста, введите правильный адрес электронной почты.")]
    public string Email { get; set; }
}