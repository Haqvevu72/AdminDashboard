using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanel.Configurations;

public class UserRoleConfiguration: IEntityTypeConfiguration<IdentityUserRole<int>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
    {
        builder.HasData(
            new IdentityUserRole<int>
            {
                UserId = 1, // Admin User Id
                RoleId = 1  // Admin Role Id
            },
            new IdentityUserRole<int>
            {
                UserId = 2, // Employee User Id
                RoleId = 2  // Employee Role Id
            }
        );
    }
}