using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace BlazorServerWindowsAuth.Data
{
    public class AppClaimsTransformation : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal is not null) {
                ClaimsIdentity claimsIdentity = new ClaimsIdentity();
                AddRoleClaim(principal, claimsIdentity, "User");
                if (principal.IsInRole("GG-6401-Computer-admins"))
                {
                    AddRoleClaim(principal, claimsIdentity, "Support");
                }
                if (principal.Identity.Name.EndsWith("asala") || principal.Identity.Name.EndsWith("mfernan5"))
                {
                    AddRoleClaim(principal, claimsIdentity, "Admin");
                }
                principal.AddIdentity(claimsIdentity);
            }
            return Task.FromResult(principal);
        }

        private static void AddRoleClaim(ClaimsPrincipal principal, ClaimsIdentity claimsIdentity, string role)
        {
            if (!principal.HasClaim(claim => claim.Type == ClaimTypes.Role && claim.Value == role))
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
            }
        }
    }
}
