using AdminPanel.Configurations;
using AdminPanel.Data.Interceptors;
using AdminPanel.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Data;

public class AdminPanelDB: IdentityDbContext<User,IdentityRole<int>,int>
{
    private readonly IConfiguration _configuration;

    public AdminPanelDB(DbContextOptions<AdminPanelDB> options,IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
            .AddInterceptors(new SoftDeleteInterceptor());
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new AssaignmentConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new RoleConfiguration());
        builder.ApplyConfiguration(new UserRoleConfiguration());
        
        // Filter deleted entities
        builder.Entity<Assaignment>().HasQueryFilter(a => a.IsDeleted == false);
        builder.Entity<User>().HasQueryFilter(u => u.IsDeleted == false);
        base.OnModelCreating(builder);
    }

    public DbSet<Assaignment> Assaignments { get; set; }
}