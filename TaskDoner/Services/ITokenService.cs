using Microsoft.AspNetCore.Identity;

namespace TaskDoner.Services
{
    public interface ITokenService
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
