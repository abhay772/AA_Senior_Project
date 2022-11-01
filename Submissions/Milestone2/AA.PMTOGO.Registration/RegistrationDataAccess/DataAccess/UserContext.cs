using Microsoft.EntityFrameworkCore;
using RegistrationDataAccess.Models;

namespace RegistrationDataAccess.DataAccess;

public class UserContext : DbContext
{
    public UserContext() { }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=AA.RegistrationDB;Trusted_Connection=True;Encrypt=false;");
    }
}