

using HappyInventoryAPP.Server;

namespace HappyInventoryAPP.Server.Authorization
{

    public class JwtMiddleware
    {
        private readonly Microsoft.AspNetCore.Http.RequestDelegate _next;

        public JwtMiddleware(Microsoft.AspNetCore.Http.RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context, IUserRepository user, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = await user.GetUser(userId.Value);
            }

            await _next(context);
        }
    }
}