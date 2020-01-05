using IdentityServer4.Validation;
using IdentityModel;
using System.Threading.Tasks;
 
namespace Identity.Services
{
    public class ExtendedResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserService userService;
 
        public ExtendedResourceOwnerPasswordValidator(UserService userService)
        {
            this.userService = userService;
        }
 
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (this.userService.ValidateCredentials(context.UserName, context.Password))
            {
                var user = this.userService.FindByUsername(context.UserName);
                context.Result = new GrantValidationResult(user.Id, OidcConstants.AuthenticationMethods.Password);
            }
 
            return Task.FromResult(0);
        }
    }
}