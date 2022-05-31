using Microsoft.AspNetCore.Http;
using Powers.Blog.Core.Utility;
using Powers.Blog.IServices;
using Powers.Blog.Shared.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Powers.Blog.Common.Auth
{
    public class AspNetUser : IHttpContextUser<Guid>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IServiceGen<Guid> _serviceGen;

        public AspNetUser(IHttpContextAccessor httpContextAccessor, IServiceGen<Guid> serviceGen)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceGen = serviceGen;
        }

        public User User => _serviceGen.QueryById<User>(Id);

        public Guid Id => GetClaimValueByType("Id").FirstOrDefault().ConvertTo<Guid>();

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _httpContextAccessor.HttpContext.User.Claims;
        }

        public IEnumerable<string> GetClaimValueByType(string claimType)
        {
            return (from item in GetClaimsIdentity()
                    where item.Type == claimType
                    select item.Value).ToList();
        }

        public string GetToken()
        {
            return _httpContextAccessor.HttpContext.Request.Headers["Authorization"]
                .ToString().Replace("Bearer ", "");
        }

        public IEnumerable<string> GetUserInfoFromToken(string claimType)
        {
            var jwtHandler = new JwtSecurityTokenHandler();

            if (GetToken().IsNullOrEmpty())
            {
                JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(GetToken());

                return (from item in jwtToken.Claims
                        where item.Type == claimType
                        select item.Value).ToList();
            }
            else
            {
                return new List<string>() { };
            }
        }

        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}