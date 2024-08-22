using AdminPanel.Data;
using AdminPanel.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register via extension methods ...
builder.Services.AddJwtRegister(builder.Configuration);
builder.Services.AddDbContextRegister(builder.Configuration);
builder.Services.AddIdentityRegister();
builder.Services.AddSwaggerRegister();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdminPanel v1"));
 
}

app.UseHttpsRedirection();

app.UseAuthentication(); 
app.UseAuthorization();
app.MapControllers();


app.Run();
