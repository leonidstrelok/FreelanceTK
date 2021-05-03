using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceTK.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("/home/error")]
        public IActionResult Error()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            return LocalRedirect("/");
        }
    }
}