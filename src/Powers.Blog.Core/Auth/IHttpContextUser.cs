using Powers.Blog.Shared.Entity;
using System.Collections.Generic;
using System.Security.Claims;

namespace Powers.Blog.Common.Auth
{
    public interface IHttpContextUser<TId>
    {
        TId Id { get; }
        User User { get; }

        bool IsAuthenticated();

        IEnumerable<Claim> GetClaimsIdentity();

        IEnumerable<string> GetClaimValueByType(string claimType);

        string GetToken();

        IEnumerable<string> GetUserInfoFromToken(string claimType);
    }
}