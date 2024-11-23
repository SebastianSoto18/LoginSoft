using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftTechChallenge.Infraestructure.Models;

[Table("UserRoles")]
public class UserRole
{
    [Key]
    public int UserRoleId { get; set; }
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    [ForeignKey(nameof(Role))]
    public int RoleId { get; set; }
    
    public User User { get; set; }
    public Role Role { get; set; }
}