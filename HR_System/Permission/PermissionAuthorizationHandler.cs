using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace HR_System.Permission
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        public PermissionAuthorizationHandler()
        {
            
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User == null)
                return;

            var Permission = context.User.Claims.Where(x => x.Type == "Permission" && x.Value == requirement
            ._Permission && x.Issuer == "LOCAL AUTHORITY");


            if (Permission.Any())
            {
                context.Succeed(requirement);
                return;
            }
        }
    }
}
