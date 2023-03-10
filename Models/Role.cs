using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace btw_api.Models
{
    [PrimaryKey("RoleId")]
    [Table("roles")]
    public class Role
    {
        [Column("id")] public int RoleId { get; set; }
        [Column("nombre_rol")] public string RoleName { get; set; }
    }
}
