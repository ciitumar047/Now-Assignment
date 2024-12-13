namespace Assignment.Domain.Entities;
public class User
{
    public string UserId { get; set; } = Guid.NewGuid().ToString();
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Device { get; set; }
    public string IpAddress { get; set; }
    public DateTime? LastLoginTime { get; set; }
    public decimal Balance { get; set; }
}
