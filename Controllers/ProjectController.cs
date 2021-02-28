using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc.Models.DbModels;
using mvc.Models.ViewModels;
using mvc.System.Services.Contract;

namespace mvc.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IUserService _userService;

        public ProjectController(IProjectService projectService, IUserService userService)
        {
            _projectService = projectService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectViewModel model)
        {
            if(ModelState.IsValid)
            {
                if(User.Identity.IsAuthenticated)
                {
                    var project = _projectService.CreateProject(model, await _userService.GetCurrent(User));
                    return RedirectToAction("current", project);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Current(Guid id)
        {
            return View(await _projectService.GetProject(id));
        }
    }
}