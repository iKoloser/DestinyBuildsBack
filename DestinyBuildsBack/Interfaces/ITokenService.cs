using DestinyBuildsBack.Models;

namespace DestinyBuildsBack.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
    
}