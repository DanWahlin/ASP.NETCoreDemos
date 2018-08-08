using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using UsingIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UsingIdentity.Security
{
    // Example of customizing the claims principal factory
    // While you probably don't need to store SubscribeToNewsletter as a claim, any property in
    // the ApplicationUser object could be stored using this technique.
    public class ApplicationClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public ApplicationClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            IOptions<IdentityOptions> optionsAccessor): base(userManager, roleManager, optionsAccessor) { }

        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);

            var identity = ((ClaimsIdentity)principal.Identity);
            identity.AddClaims(new[] { new Claim("SubscribeToNewsletter", user.SubscribeToNewsletter.ToString()) });

            return principal;
        }
    }
}
