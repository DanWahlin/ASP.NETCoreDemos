using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookieAuthentication.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        static int _claimsIssueCount = 0;

        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Hard-coding the user here but could capture from a login form and validate first
            var userName = $"johndoe{_claimsIssueCount}@test.com";
            const string ISSUER = "https://www.codewithdan.com";

            // 1. Create the claims (user name, any user data, roles, etc.)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName, ClaimValueTypes.String, ISSUER),
                new Claim(ClaimTypes.Role, "Admin")
            };

            // 2. Create an identity
            var userIdentity = new ClaimsIdentity("UserLogin");

            //3. Add claims to identity
            userIdentity.AddClaims(claims);

            //4. Add the user identity to the claims principle
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            //5. Sign the user in (would check user info if this were a dynamic login of course)
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });

            _claimsIssueCount++;

            if (returnUrl != null && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Forbidden()
        {
            return View();
        }

    }
}