using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helicopter.API.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetBaseUrl(this HttpContext context) => $"{context.Request.Scheme}://{context.Request.Host.ToUriComponent()}";
    }
}
