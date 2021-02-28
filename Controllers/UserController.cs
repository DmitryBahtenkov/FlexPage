using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc.System.Services.Contract;

namespace mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            return View(await _userService.GetCurrent(base.User));
        }
    }
}