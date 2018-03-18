using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MatchedBetMate.WebApi.Controllers.Base
{
    public class BaseController : Controller
    {
        protected readonly UserManager<IdentityUser> UserManager;

        public BaseController(UserManager<IdentityUser> userManager)
        {
            UserManager = userManager;
        }

        protected async Task<IdentityUser> GetUser()
        {
            return await UserManager.FindByNameAsync(User.Identity.Name);
        }

        protected IActionResult GetErrorStatusCodeAndGenericMessage()
        {
            return StatusCode(500, "A problem occurred while handling your request");
        }
    }
}
