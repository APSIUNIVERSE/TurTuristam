﻿using System.ComponentModel.DataAnnotations;

namespace Auth.Identity;

public class UserTur
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Mail { get; set; }
    public string? Password { get; set; }
}
