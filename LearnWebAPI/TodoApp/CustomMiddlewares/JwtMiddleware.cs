using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Entities.Models;
using Constants.Enums;
using Constants;

namespace CustomMiddlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;

        public JwtMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public async Task InvokeAsync(HttpContext http)
        {
            var authHeader = http.Request.Headers["Authorization"].FirstOrDefault();

            if (authHeader == null || authHeader.IndexOf(Literals.AUTH_NAME) == -1)
            {
                await _next(http);
                return;
            }

            var token = authHeader.Split(" ").Last();
            if (token != null)
            {
                AttachTokenToContext(http, token);
            }

            await _next(http);
        }

        public void AttachTokenToContext(HttpContext http, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _config["Jwt:Issuer"],
                    ValidAudience = _config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                }, out SecurityToken validationToken);

                var jwtToken = (JwtSecurityToken)validationToken;
                var name = jwtToken.Claims.First(x => x.Type == ClaimTypes.Name).Value;
                var role = jwtToken.Claims.First(x => x.Type == ClaimTypes.Role).Value;

                var employee = new
                {
                    Name = name,
                    Role = Enum.Parse(typeof(Roles), role),
                };

                http.Items["Employee"] = employee;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
