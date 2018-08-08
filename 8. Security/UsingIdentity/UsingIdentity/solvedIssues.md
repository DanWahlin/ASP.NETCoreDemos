## No service for type 'Microsoft.AspNetCore.Identity.UserManager`1[Microsoft.AspNetCore.Identity.IdentityUser]' has been registered

When customizing the IdentityUser (with ApplicationUser for example), you need to make sure that ApplicationUser is used everywhere.
If your code builds and you get the error above, check Shared/_LoginPartial.cshtml and make sure any injected security types
also use your custom user (such as ApplicationUser).