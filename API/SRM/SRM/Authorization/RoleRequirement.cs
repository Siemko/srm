using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace SRM.Authorization
{
    public class RoleRequirement : AuthorizationHandler<RoleRequirement>, IAuthorizationRequirement
    {
        private readonly string _roleName;

        public RoleRequirement(string roleName)
        {
            _roleName = roleName;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            if (context.User.IsInRole(_roleName))
                context.Succeed(requirement);
            else
                context.Fail();

            return Task.CompletedTask;
        }
    }
}
