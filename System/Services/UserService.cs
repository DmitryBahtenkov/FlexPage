using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using mvc.Models.DbModels;
using mvc.Models.ViewModels;
using mvc.System.Repositories;
using mvc.System.Services.Contract;

namespace mvc.System.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IRepository<Project> _projectRepository;

        public UserService(IRepository<User> repository, IRepository<Project> projectRepository)
        {
            _repository = repository;
            _projectRepository = projectRepository;
        }

        private async Task Authentificate(User user, HttpContext context)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username)
            };
            // создаем объект ClaimsIdentity
            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<bool> Login(LoginViewModel login, HttpContext context)
        {
            var user = (await _repository.GetAll()).Find(x=>x.Username == login.Username && x.Password == login.Password);
            if(user is not null)
            {
                await Authentificate(user, context);
                return true;
            }
            return false;
        }

        public async Task<bool> Register(RegisterViewModel register, HttpContext context)
        {
            var user = (await _repository.GetAll()).Find(x=>x.Username == register.Username);
            if(user is null)
            {
                var newUser = await _repository.Create(new User
                {
                    Username = register.Username,
                    Password = register.Password,
                    Bio = register.Bio
                });

                await Authentificate(newUser, context);
                return true;
            }

            return false;
        }

         public async Task<User> GetCurrent(IPrincipal principal)
         {
            if(principal.Identity.IsAuthenticated)
            {
                var user = (await _repository.GetAll()).Find(x=>x.Username == principal?.Identity?.Name);
                user.Projects ??= (await _projectRepository.GetAll()).Where(x=>x.UserId == user.Id).ToList();
                return user;
            }
            return TechnicalUsers.GuestUser;
         }

    }
}