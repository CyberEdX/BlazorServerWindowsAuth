# BlazorServerWindowsAuth

Blazor Server with Windows Authentication / Authorization

- Updates on Program.cs:
<code>
 builder.Services.AddAuthorization(options =>\n
 {\n
     // By default, all incoming requests will be authorized according to the default policy.\n
     options.FallbackPolicy = options.DefaultPolicy;\n
     options.AddPolicy("IsSupport", policy => policy.RequireRole("Support"));\n
     options.AddPolicy("IsUser", policy => policy.RequireRole("User"));\n
     options.AddPolicy("IsAdmin", policy => policy.RequireRole("Support", "Admin"));\n
 });\n
 ...\n
 builder.Services.AddSingleton<UserInfoService>();\n
 builder.Services.AddTransient<IClaimsTransformation, AppClaimsTransformation>();\n
</code>

Under Data folder:
- Class Services:
public class AppClaimsTransformation : IClaimsTransformation
public class UserInfoService

- Class Model:
public class UserInfoAD

Under Shared folder (updated and new components): 
- LoginDisplay (updated)
- FooterLayout (new)
- SupportLabel (new)

Links:
- blazor-top-navbar:
  https://github.com/martinmogusu/blazor-top-navbar
- Adding Authentication to your Blazor Server web app:
  https://blog.matrixpost.net/blazor-server-basics-part-5-authentication-and-authorization/
- Configuring Policy-based Authorization with Blazor:
  https://chrissainty.com/securing-your-blazor-apps-configuring-policy-based-authorization-with-blazor/
- Extend or add custom claims using IClaimsTransformation:
  https://learn.microsoft.com/en-us/aspnet/core/security/authentication/claims?view=aspnetcore-7.0#extend-or-add-custom-claims-using-iclaimstransformation
