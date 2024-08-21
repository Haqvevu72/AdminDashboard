using AdminPanel.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanel.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User
            {
                Id = 1,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                Firstname = "Admin",
                Lastname = "User",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<User>().HashPassword(null, "AdminPassword123!"),
                SecurityStamp = Guid.NewGuid().ToString(),
                IsDeleted = false,
                DeletedAt = null
            },
            new User
            {
                Id = 2,
                UserName = "employee",
                NormalizedUserName = "EMPLOYEE",
                Email = "employee@example.com",
                NormalizedEmail = "EMPLOYEE@EXAMPLE.COM",
                Firstname = "Employee",
                Lastname = "User",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<User>().HashPassword(null, "EmployeePassword123!"),
                SecurityStamp = Guid.NewGuid().ToString(),
                IsDeleted = false,
                DeletedAt = null
            }
        );
    }
}