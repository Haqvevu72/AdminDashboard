using AdminPanel.Data;
using AdminPanel.Entities;
using Microsoft.AspNetCore.Identity;

namespace AdminPanel.ExtensionMethods;

public static class IdentityRegister
{
    public static void AddIdentityRegister(this IServiceCollection Service)
    {
        Service.AddIdentity<User, IdentityRole<int>>().AddEntityFrameworkStores<AdminPanelDB>()
            .AddDefaultTokenProviders();
    }
}