using Microsoft.AspNetCore.Identity;

namespace MTSP.API.Services.Abstractions
{
    public interface IAuthorizeService
    {
        string GetToken(IdentityUser user);
    }
}