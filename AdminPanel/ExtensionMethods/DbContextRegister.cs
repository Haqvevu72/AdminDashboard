using AdminPanel.Data;
using AdminPanel.Repositories.Abstract.Task;
using AdminPanel.Repositories.Abstract.User;
using AdminPanel.Repositories.Concrete.Assaignment;
using AdminPanel.Services.Abstract;
using AdminPanel.Services.Concrete;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.ExtensionMethods;

public static class DbContextRegister
{
    public static void AddDbContextRegister(this IServiceCollection Services,IConfiguration Configuration)
    {
        Services.AddDbContext<AdminPanelDB>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        
        // Register Repositories
        
        // 1. Assaignment
        Services.AddScoped<IAssignmentReadRepository, AssaignmentReadRepository>();
        Services.AddScoped<IAssaignmentWriteRepository, AssaignmentWriteRepository>();
        
        // -----------------------------------------------------------------------------
        
        // Register Services
        
        // 1. User
        Services.AddScoped<IUserService, UserService>();
        
        // 2. Assaignment
        Services.AddScoped<IAssaignmentService, AssaignmentService>();
    }
}