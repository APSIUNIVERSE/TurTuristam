namespace Auth.Models;

public class OrgProfileModel
{
    public int currentUserId { get; set; }
    public string? CurrentUserName { get; set; }
    public string? CurrentUserInn { get; set; }
    public string? CurrentUserOgrn { get; set; }
    public string? CurrentUserAdressUr { get; set; }
    public string? CurrentUserAdressFact { get; set; }
    public string? CurrentUserLicense { get; set; }
    public string? CurrentUserContact { get; set; }
    public string? CurrentUserMail { get; set; }
    public string? CurrentUserPass { get; set; }
}