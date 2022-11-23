using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AdvertisingSystem.Api.PolicyRequirements
{
    public class UserIsResourceOwnerHandler : AuthorizationHandler<UserIsResourceOwnerRequirement>
    {
        IHttpContextAccessor _httpContextAccessor;

        public UserIsResourceOwnerHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        //https://learn.microsoft.com/en-us/aspnet/core/security/authorization/policies?view=aspnetcore-6.0#access-mvc-request-context-in-handlers
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserIsResourceOwnerRequirement requirement)
        {
            if (context.Resource is HttpContext httpContext)
            {
                var path = httpContext.Request.Path.Value ?? "";
                var pathValues = path.Split('/');
                int queryId = -1;
                foreach (var value in pathValues)
                {
                    if (int.TryParse(value, out queryId))
                        break;
                }

                if(context.User == null || queryId == -1)
                {
                    context.Fail();
                    return Task.CompletedTask;
                }

                var userIdString = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if(userIdString == null)
                {
                    context.Fail();
                    return Task.CompletedTask;
                }

                var userId = int.Parse(userIdString);
                if (userId == queryId)
                    context.Succeed(requirement);
                else
                    context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}
