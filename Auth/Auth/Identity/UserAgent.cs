using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Auth.Models;

namespace Auth.Identity;

public class UserAgent
{
    [Key] 
    public int Id { get; set; }
    public string? RegOrgName { get; set; }
    public string? RegOrgInn { get; set; }
    public string? RegOrgOgrn { get; set; }
    public string? RegOrgAdressUr { get; set; }
    public string? RegOrgAdressFact { get; set; }
    public string? RegOrgLicense { get; set; }
    public string? RegOrgContact { get; set; }
    public string? RegOrgMail { get; set; }
    public byte[]? RegOrgSkan { get; set; }
    public string? RegOrgPass { get; set; }
    /*public ImageModel imageModel { get; set; }*/
    
}