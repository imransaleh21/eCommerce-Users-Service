namespace eCommerce.Core.Entities;

/// <summary>
/// Represents an application user in the e-commerce system.
/// Which acts as entity model class to strore user information in the data store.
/// </summary>
public class ApplicationUser
{
    public Guid UserId { get; set; }
    public string? Email { get; set; }
    public string? PersonName { get; set; }
    public string? Password { get; set; }
    public string? Gender { get; set; }
}
