using System.Security.Claims;

namespace DeviceManagement.Application.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name)?.Value;      //In Claims principle si TokenService uniqueName este pentru username, iar NameId este pentru ID
        }

        public static int GetUserId(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
