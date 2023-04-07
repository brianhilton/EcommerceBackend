namespace EcommerceBackend.Data.Models;

public class User : IUniqueIdentifier
{
    public int? Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public DateTime? JoinDate { get; set; }
    public string ProfileImageUrl { get; set; }
}