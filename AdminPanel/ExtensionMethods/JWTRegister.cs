using System.Text;
using AdminPanel.Services.Abstract;
using AdminPanel.Services.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace AdminPanel.ExtensionMethods;

public static class JWTRegister
{
    public static void AddJwtRegister(this IServiceCollection Services ,IConfiguration Configuration)
    {
        Services.AddAuthentication(opt => {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidAudience = Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecretKey"]!))
                };
            });

        Services.AddScoped<ITokenService, TokenService>();
        Services.AddScoped<IAuthService, AuthService>();
    }
}