using Bootcamp.API.DTOs;
using Bootcamp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Text;

namespace Bootcamp.API.Filters
{
    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
        private readonly string _ipAddress;

        public CustomAuthorizationFilter(string ipAddress)
        {
            this._ipAddress = ipAddress;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var requestIp =
      context.HttpContext.Connection.RemoteIpAddress;

            var ipAddresses = this._ipAddress.Split(';');
            var forbidIP = true;

            if (requestIp.IsIPv4MappedToIPv6)
            {
                requestIp = requestIp.MapToIPv4();
            }

            foreach (var address in ipAddresses)
            {
                var testIp = IPAddress.Parse(address);

                if (testIp.Equals(requestIp))
                {
                    forbidIP = false;
                    break;
                }
            }

            if (forbidIP)
            {
                context.Result = new StatusCodeResult(403);

                return;
            }
        }

    }
}
