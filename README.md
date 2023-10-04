# BlazorServerWindowsAuth
![BlazorServer-Windows-Auth-example](https://github.com/CyberEdX/BlazorServerWindowsAuth/assets/84814386/282bb76d-370e-4f67-85d8-d4f7905e9dd1)

## Blazor Server with Windows Authentication / Authorization
![BlazorServerWinAuth](https://github.com/CyberEdX/BlazorServerWindowsAuth/assets/84814386/8a98ac20-1183-41ef-84a4-e11955c6e220)

- Updates on Program.cs:
<code>
 builder.Services.AddAuthorization(options =>
 {
     // By default, all incoming requests will be authorized according to the default policy.
     options.FallbackPolicy = options.DefaultPolicy;
     options.AddPolicy("IsSupport", policy => policy.RequireRole("Support"));
     options.AddPolicy("IsUser", policy => policy.RequireRole("User"));
     options.AddPolicy("IsAdmin", policy => policy.RequireRole("Support", "Admin"));
 });
 ...
 builder.Services.AddSingleton<UserInfoService>();
 builder.Services.AddTransient<IClaimsTransformation, AppClaimsTransformation>();

</code>

### Under Data folder:
- Class Services:
public class AppClaimsTransformation : IClaimsTransformation
public class UserInfoService

- Class Model:
public class UserInfoAD

### Under Shared folder (updated and new components): 
- LoginDisplay (updated)
- FooterLayout (new)
- SupportLabel (new)

### Links:
- blazor-top-navbar:
  https://github.com/martinmogusu/blazor-top-navbar
- Adding Authentication to your Blazor Server web app:
  https://blog.matrixpost.net/blazor-server-basics-part-5-authentication-and-authorization/
- Configuring Policy-based Authorization with Blazor:
  https://chrissainty.com/securing-your-blazor-apps-configuring-policy-based-authorization-with-blazor/
- Extend or add custom claims using IClaimsTransformation:
  https://learn.microsoft.com/en-us/aspnet/core/security/authentication/claims?view=aspnetcore-7.0#extend-or-add-custom-claims-using-iclaimstransformation

