using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using IdentityServer4;

namespace Identity.Services
{
    public class ExtendedProfileService : IProfileService
    {
        protected readonly ILogger logger;
 
        protected readonly UserService userService;
 
        public ExtendedProfileService(UserService userService, ILogger<ExtendedProfileService> logger)
        {
            this.userService = userService;
            this.logger = logger;
        }
 
 
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
 
            this.logger.LogDebug("Get profile called for subject {subject} from client {client} with claim types {claimTypes} via {caller}",
                sub,
                context.Client.ClientName ?? context.Client.ClientId,
                context.RequestedClaimTypes,
                context.Caller);
 
            var user = this.userService.FindById(sub);
 
            var claims = new List<Claim>
            {
                new Claim("username", user.Username),
                new Claim("email", user.Email),
                new Claim("authorities", "AUTHORITY")
            };
 
            user.Roles.ForEach(r => claims.Add(new Claim("authorities", "ROLE_" + r)));
            user.Roles.ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r)));

            context.IssuedClaims = claims;
        }
 
        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = userService.FindById(sub);
            context.IsActive = user != null;
        }
    }
}