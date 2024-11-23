using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftTechChallenge.Infraestructure.Models;

[Table("Users")]
public class User
{
    public User()
    {
        Roles = new HashSet<UserRole>();
    }
    
    [Key]
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public ICollection<UserRole> Roles { get; set; }
}