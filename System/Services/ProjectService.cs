using System;
using System.Threading.Tasks;
using mvc.Models.DbModels;
using mvc.Models.ViewModels;
using mvc.System.Repositories;
using mvc.System.Services.Contract;

namespace mvc.System.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _repository;
        private readonly IRepository<User> _userRepository;

        public ProjectService(IRepository<Project> repository, IRepository<User> userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<Project> CreateProject(ProjectViewModel model, User currentUser)
        {
            var project = new Project
            {
                Name = model.Name,
                Description = model.Description,
                State = ProjectState.IDEA,
                User = currentUser,
                IsPrivate = model.IsPrivate
            };
            return await _repository.Create(project);
        }

        public async Task<Project> GetProject(Guid id)
        {
            var project = await _repository.Get(id);
            project.User ??= await _userRepository.Get(project.UserId);
            return project;
        }
    }
}