using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace btw_api.Models
{
    [PrimaryKey("Id")]
    [Table("usuarios")]
    public class User
    {
        public User() { }

        [Column("id")] public int Id { get; set; }
        [Column("nombres")] public string Name { get; set; }
        [Column("apellido1")] public string FirstLastName { get; set; }
        [Column("apellido2")] public string? SecondLastName { get; set; } // El ? es para prevenir si el valor viene nulo de la bd
        [Column("email")] public string Email { get; set; }
        [Column("clave")] public string Password { get; set; }
        [Column("rol")] public int Role { get; set; }
    }
}
