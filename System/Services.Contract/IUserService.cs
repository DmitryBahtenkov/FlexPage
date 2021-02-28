using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using mvc.Models.DbModels;
using mvc.Models.ViewModels;

namespace mvc.System.Services.Contract
{
    public interface IUserService
    {
         public Task<bool> Login(LoginViewModel login, HttpContext context);
         public Task<bool> Register(RegisterViewModel register, HttpContext context);
         public Task<User> GetCurrent(IPrincipal principal);
    }
}