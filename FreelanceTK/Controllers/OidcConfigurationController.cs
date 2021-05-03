using System;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FreelanceTK.Controllers
{
    [AllowAnonymous]
    public class OidcConfigurationController : Controller
    {
        private readonly IClientRequestParametersProvider _clientRequestParametersProvider;
        private readonly ILogger<OidcConfigurationController> _logger;

        public OidcConfigurationController(IClientRequestParametersProvider clientRequestParametersProvider,
            ILogger<OidcConfigurationController> logger)
        {
            _clientRequestParametersProvider = clientRequestParametersProvider;
            _logger = logger;
        }

        [HttpGet("_configuration/{clientId}")]
        public IActionResult GetClientRequestParameters([FromRoute] string clientId)
        {
            string hostName = this.Request.Host.Host;
            var parameters = _clientRequestParametersProvider.GetClientParameters(HttpContext, clientId);

            if (clientId.Contains("prod"))
            {
                UriBuilder redirectUriBuilder = new UriBuilder(parameters["redirect_uri"])
                {
                    Host = hostName
                };
                parameters["redirect_uri"] = redirectUriBuilder.Uri.ToString();

                UriBuilder postLogoutUriBuilder = new UriBuilder(parameters["post_logout_redirect_uri"])
                {
                    Host = hostName
                };
                parameters["post_logout_redirect_uri"] = postLogoutUriBuilder.Uri.ToString();
            }

            return Ok(parameters);
        }
    }
}