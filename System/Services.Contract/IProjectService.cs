using System;
using System.Threading.Tasks;
using mvc.Models.DbModels;
using mvc.Models.ViewModels;

namespace mvc.System.Services.Contract
{
    public interface IProjectService
    {
        public Task<Project> CreateProject(ProjectViewModel model, User currentUser);
        public Task<Project> GetProject(Guid id);
    }
}