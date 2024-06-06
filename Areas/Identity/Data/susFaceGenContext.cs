using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using susFaceGen.Areas.Identity.Data;
using susFaceGen.Models;
using System.Reflection.Emit;

namespace susFaceGen.Data;

public class susFaceGenContext : IdentityDbContext<susFaceGenUser>
{

    public susFaceGenContext(DbContextOptions<susFaceGenContext> options)
        : base(options)
    {
    }
    public DbSet<Case> Case { get; set; }
    public DbSet<Statement> Statement { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var userId = UserInitialize(builder);
        var roleId = RoleInitialize(builder);
        AssignUserRoles(builder, roleId,userId);
    }

    

    private string UserInitialize(ModelBuilder builder)
    {
        PasswordHasher<susFaceGenUser> passwordHasher = new PasswordHasher<susFaceGenUser>();

        var devUser = new susFaceGenUser()
        {
            FName = "dev",
            LName = "dev",
            JobId = "0000",
            JobPosition = "Global Admin",
            Email = "dev@susfaceGen.lk",
            NormalizedEmail = "DEV@SUSFACEGEN.LK",
            UserName = "dev@susfaceGen.lk",
            NormalizedUserName = "DEV@SUSFACEGEN.LK",
            IsEnabled = true,
            EmailConfirmed = true
        };

        devUser.PasswordHash = passwordHasher.HashPassword(devUser, "susFaceGen");

        builder.Entity<susFaceGenUser>().HasData(devUser);

        return devUser.Id;
    }

    private string[] RoleInitialize(ModelBuilder builder)
    {
        var roleNames = new[] { "admin", "user" };
        List< IdentityRole> roles = new List<IdentityRole>();

        foreach (var roleName in roleNames)
        {
            var role = new IdentityRole
            {
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };
            builder.Entity<IdentityRole>().HasData(role);
            roles.Add(role);
        }
        string[] ids = { roles[0].Id, roles[1].Id }; 
        return ids;
    }

    private void AssignUserRoles(ModelBuilder builder, string[] roleId, string userId)
    {
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = roleId[0],
                UserId = userId
            }
        );
    }
}
