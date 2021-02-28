using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using mvc.Models.DbModels;

namespace mvc.System.Repositories
{
    public interface IRepository<TModel> where TModel : BaseModel
    {
         public Task<List<TModel>> GetAll();
         public Task<TModel> Get(Guid id);
         public Task<TModel> Create(TModel model);
         public Task<TModel> Update(TModel model);
         public  Task Delete(Guid id);
    }
}