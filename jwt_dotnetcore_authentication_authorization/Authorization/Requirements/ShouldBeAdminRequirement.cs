using Microsoft.AspNetCore.Authorization;

namespace jwt_dotnetcore_authentication_authorization.Authorization.Requirements
{
    public class ShouldBeAdminRequirement : IAuthorizationRequirement
    {
        public ShouldBeAdminRequirement()
        {
            
        }
    }
}
