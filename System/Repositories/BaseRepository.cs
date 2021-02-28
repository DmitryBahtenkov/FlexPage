using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvc.Models.DbModels;

namespace mvc.System.Repositories
{
    public class BaseRepository<TModel> : IRepository<TModel> where TModel : BaseModel
    {
        private readonly AppContext _context;

        public BaseRepository(AppContext context)
        {
            _context = context;
            _context.Users.Include(x=>x.Projects);
            _context.Project.Include(x=>x.User);   
        }

        public async Task<TModel> Create(TModel model)
        {
            _context.Set<TModel>().Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task Delete(global::System.Guid id)
        {
            var delete = _context.Set<TModel>().FirstOrDefault(x=>x.Id == id);
            _context.Set<TModel>().Remove(delete);
            await _context.SaveChangesAsync();
        }

        public async Task<TModel> Get(global::System.Guid id)
        {
            return _context.Set<TModel>().FirstOrDefault(m => m.Id == id);
        }

        public Task<List<TModel>> GetAll()
        {
            return Task.FromResult(_context.Set<TModel>().ToList());
        }

        public async Task<TModel> Update(TModel model)
        {
            var toUpdate = _context.Set<TModel>().FirstOrDefault(m => m.Id == model.Id);
            if (toUpdate != null)
            {
                toUpdate = model;
            }
            _context.Update(toUpdate);
            await _context.SaveChangesAsync();
            return toUpdate;
        }
    }
}