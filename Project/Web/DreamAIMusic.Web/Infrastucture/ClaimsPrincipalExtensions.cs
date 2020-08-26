using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;

namespace DreamAIMusic.Web.Infrastucture
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal user) =>
           user.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
    }
}
