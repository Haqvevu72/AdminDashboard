using AdminPanel.Entities;

namespace AdminPanel.Services.Abstract;

public interface ITokenService
{ 
     Task<string> GenerateJwtToken(User user);
}