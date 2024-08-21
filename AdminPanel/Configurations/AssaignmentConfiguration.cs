using AdminPanel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanel.Configurations;

public class AssaignmentConfiguration: IEntityTypeConfiguration<Assaignment>
{
    public void Configure(EntityTypeBuilder<Assaignment> builder)
    {
        builder.HasOne<User>(t => t.Admin)
            .WithMany(a => a.AdminTasks)
            .HasForeignKey(t => t.AdminId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<User>(t => t.Employee)
            .WithMany(e => e.EmployeeTasks)
            .HasForeignKey(t => t.EmployeeId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasData(
            new Assaignment
            {
                Id = 1,
                Description = "Prepare and submit the monthly financial report.",
                Deadline = new DateTime(2024, 9, 30),
                AdminId = 1, // Assigning to Admin (UserId = 1)
                EmployeeId = 2 // Assigning to Employee (UserId = 2)
            },
            new Assaignment
            {
                Id = 2,
                Description = "Implement the new authentication feature.",
                Deadline = new DateTime(2024, 10, 15),
                AdminId = 1, // Assigning to Admin (UserId = 1)
                EmployeeId = 2 // Assigning to Employee (UserId = 2)
            }
        );
    }
}