using Microsoft.AspNetCore.Identity;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface ITokenRepository
    {

        string CreateJWTToken(IdentityUser user, List<string> roles);

    }
}