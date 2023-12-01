using Assignment.API.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq.Expressions;

namespace AssignmentHafta2.API.Services
{
    public interface IProductService
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        IQueryable<Product> Where(Expression<Func<Product, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<Product, bool>> expression);
        Task<IEnumerable<Product>> AddRangeAsync(IEnumerable<Product> items);
        Task<Product> AddAsync(Product entity);
        Task UpdateAsync(Product entity);
        Task RemoveAsync(int id);
        Task RemoveRangeAsync(IEnumerable<Product> items);
    }
}
