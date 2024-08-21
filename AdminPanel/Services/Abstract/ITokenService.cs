using AdminPanel.Entities;

namespace AdminPanel.Services.Abstract;

public interface ITokenService
{ 
    string GenerateJwtToken(User user);
}