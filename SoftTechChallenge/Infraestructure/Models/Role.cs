using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftTechChallenge.Infraestructure.Models;
[Table("Roles")]
public class Role
{
    public Role()
    {
        Users = new HashSet<UserRole>();
    }
    [Key]
    public int RoleId { get; set; }

    public string Name { get; set; }
    
    public ICollection<UserRole> Users { get; set; }
}