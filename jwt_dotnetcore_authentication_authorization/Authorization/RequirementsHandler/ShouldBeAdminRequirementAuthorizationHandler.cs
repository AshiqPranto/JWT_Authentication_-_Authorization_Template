using jwt_dotnetcore_authentication_authorization.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace jwt_dotnetcore_authentication_authorization.Authorization.RequirementsHandler
{
    public static class CustomClaimTypes
    {
        public const string IS_ADMIN = "IsAdmin";
    }
    public class ShouldBeAdminRequirementAuthorizationHandler : AuthorizationHandler<ShouldBeAdminRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ShouldBeAdminRequirement requirement)
        {
            if(!context.User.HasClaim(x => x.Type == CustomClaimTypes.IS_ADMIN))
            {
                return Task.CompletedTask;
            }

            var isUserAdminClaim = context.User.Claims.First(x => x.Type == CustomClaimTypes.IS_ADMIN).Value;
            bool isUserAnAdmin = bool.Parse(isUserAdminClaim);

            if (isUserAnAdmin)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
