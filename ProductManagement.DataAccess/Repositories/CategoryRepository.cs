using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagementWebApi.Models;

namespace ProductManagement.DataAccess.Repositories
{
    public  class CategoryRepository : ICategoryRepository
    {
        private readonly Management_ProductsContext _Context;

        public CategoryRepository(Management_ProductsContext context)
        {

            _Context = context; 

        }
        public async  Task<Category> GetById(int id)
        {

            return await _Context.Categories.FindAsync(id); 

        }

        public async Task<IEnumerable<Category>> GetAll()
        {

            return await _Context.Categories.ToListAsync(); 


        }

        public async Task Add(Category entity)
        {

              await  _Context.Categories.AddAsync(entity); 

        }

        public void Delete(Category entity)
        {
            
            _Context.Categories.Remove(entity);

        }

        public async Task DeleteById(int id)
        {

            var obj = await _Context.Categories.FindAsync(id);
            _Context.Categories.Remove(obj);


        }

        public async Task<IEnumerable<Category>> FindList(Expression<Func<Category, bool>> predicate)
        {
            
            return  await _Context.Categories.Where(predicate).ToListAsync();

        }

        public async  Task<Category> FindEntity(Expression<Func<Category, bool>> predicate)
        {

            return await _Context.Categories.Where(predicate).FirstAsync();

        }

        public async Task<IEnumerable<Category>> GetActiveChildCategory(int parrentId)
        {

            return await _Context.Categories
                .Where(mdl => mdl.ParentId == parrentId)
                .Where(mdl => mdl.IsActive == true)
                .ToListAsync(); 

        }

        public async  Task<IEnumerable<Category>> GetInactiveChildCategory(int parrentId)
        {
            return await _Context.Categories
                .Where(mdl => mdl.ParentId == parrentId)
                .Where(mdl => mdl.IsActive == false)
                .ToListAsync();
        }

        public  async Task<IEnumerable<Category>> GetActiveList()
        {

            return await _Context.Categories.Where(mdl => mdl.IsActive == true).ToListAsync(); 

        }

        public async  Task<IEnumerable<Category>> GetDeActiveList()
        {
            return await _Context.Categories.Where(mdl => mdl.IsActive == false).ToListAsync();
        }
    }
}
