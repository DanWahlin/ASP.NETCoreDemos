using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using UsingOAuth.Models;

public class AuthenticationController : Controller
{
    [HttpGet]
    public IActionResult Login(string returnUrl = "/")
    {
        return Challenge(new AuthenticationProperties() { RedirectUri = returnUrl });
    }
}