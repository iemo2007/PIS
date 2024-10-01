using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PIS.API.Middleware
{
    public class StationClaimMiddleware
    {
        private readonly RequestDelegate _next;

        public StationClaimMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity is ClaimsIdentity identity /*&& identity.IsAuthenticated*/)
            {
                var stationClaim = identity.FindFirst("Station");
                if (stationClaim != null)
                {
                    context.Items["Station"] = stationClaim.Value;
                }
            }

            await _next(context);
        }
    }
}
