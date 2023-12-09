using Assignment.API.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq.Expressions;

namespace AssignmentHafta2.API.Services
{
    public interface IProductService
    {
        Product GetById(int id);
        List<Product> GetAll();
        IQueryable<Product> Where(Expression<Func<Product, bool>> expression);
        bool Any(Expression<Func<Product, bool>> expression);
        IEnumerable<Product> AddRange(IEnumerable<Product> items);
        Product Add(Product entity);
        void Update(Product entity);
        void Remove(Product entity);
        void RemoveRange(IEnumerable<Product> items);
    }
}
