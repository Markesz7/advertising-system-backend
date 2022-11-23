using Microsoft.AspNetCore.Authorization;

namespace AdvertisingSystem.Api.PolicyRequirements
{
    public class UserIsResourceOwnerRequirement : IAuthorizationRequirement
    {
    }
}
