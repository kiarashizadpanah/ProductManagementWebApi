using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using Attribute = ProductManagementWebApi.Models.Attribute;

namespace ProductManagement.DataAccess.Repositories
{
    public  class  AttributeRepository : IAttributesRepository
    {
        private readonly Management_ProductsContext _Context;

        public AttributeRepository(Management_ProductsContext context)
        {

            _Context = context; 

        }
        public async  Task<Attribute> GetById(int id)
        {

            return await _Context.Attributes.FindAsync(id); 

        }

        public async  Task<IEnumerable<Attribute>> GetAll()
        {

            return await _Context.Attributes.ToListAsync(); 

        }

        public async  Task Add(Attribute entity)
        {

            await _Context.Attributes.AddAsync(entity); 

        }

        public void Delete(Attribute entity)
        {
           
            _Context.Attributes.Remove(entity); 

        }

        public async  Task DeleteById(int id)
        {

            var obj = await _Context.Attributes.FindAsync(id);
            _Context.Attributes.Remove(obj); 

        }

        public async Task<IEnumerable<Attribute>> FindList(Expression<Func<Attribute, bool>> predicate)
        {

            return await _Context.Attributes.Where(predicate).ToListAsync(); 

        }

        public async Task<Attribute> FindEntity(Expression<Func<Attribute, bool>> predicate)
        {

            return await _Context.Attributes.Where(predicate).FirstAsync(); 

        }

        public async Task<IEnumerable<Attribute>> GetAttributesByParentId(int parentId)
        {

            return await _Context.Attributes.Where(mdl => mdl.ParentId == parentId).ToListAsync(); 

        }
    }
}
