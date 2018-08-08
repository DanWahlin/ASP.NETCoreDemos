## This example shows how to customize ASP.NET Identity

* Models/ApplicationUser.cs represents a custom user class that adds an additional property
* Data/ApplicationDbContext.cs represents a custom DbContext that could be used to customize entity relationships, names, and more
* Data/RolesData.cs adds custom roles into the database if none exist as the application starts
* Security/ApplicationClaimsPrincipalFactory.cs shows how a custom claim can be added as a user identity is created in the application
* Startup.cs shows how to configure a custom user identity and DbContext. It also shows customizing several other aspects of security.
* The code in Areas/Identity shows how to create a custom registration page that captures info about the custom ApplicationUser property, 
 how to create a new user, assign a user to a role using the RoleManager, and more.