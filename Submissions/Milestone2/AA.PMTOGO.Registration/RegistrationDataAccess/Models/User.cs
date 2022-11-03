using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationDataAccess.Models;

public class User
{
    [Key]
    [Required]
    [MaxLength(100)]
    [Column(TypeName = "varchar(100)")]
    public string Email { get; set; }
    [Required]
    [MaxLength(100)]
    [Column(TypeName = "varchar(100)")]
    public string UserName { get; set; }
    [Required]
    [MaxLength(100)]
    [Column(TypeName ="varchar(100)")]
    public string Password { get; set; }
}
