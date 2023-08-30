using System.ComponentModel.DataAnnotations;

namespace Auth.Models;

public class ChangePassViewModel
{
    [Required(ErrorMessage = "Введите пароль")]
    public string passch { get; set; }
    [Compare("passch", ErrorMessage = "Пароли не совпадают")]
    public string passchrepeat { get; set; }
}