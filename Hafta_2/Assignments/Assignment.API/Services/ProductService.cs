using Assignment.API.Models;
using System.Linq.Expressions;

namespace AssignmentHafta2.API.Services
{
    public class ProductService : IProductService
    {
        private List<Product> _products;

        public ProductService()
        {
            _products = new List<Product>();
            Seeds();
        }

        public Product Add(Product entity)
        {

            entity.Id = _products.OrderBy(x=> x.Id).Last().Id + 1;
            _products.Add(entity);
            return entity;
        }

        public IEnumerable<Product> AddRange(IEnumerable<Product> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            _products.AddRange(items);
            return items;
        }

        public bool Any(Expression<Func<Product, bool>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            return _products.AsQueryable().Any(expression);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Remove(Product entity)
        {
            _products.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Product> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            foreach (var item in items)
            {
                _products.Remove(item);
            }
        }

        public void Update(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingProduct = _products.FirstOrDefault(p => p.Id == entity.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = entity.Name;
                existingProduct.Price = entity.Price;
            }
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            return _products.AsQueryable().Where(expression);
        }

        private void Seeds()
        {
            _products.Add(new Product { Id = 1, Name = "Product 1", Price = 10.0 });
            _products.Add(new Product { Id = 2, Name = "Product 2", Price = 20.0 });
            _products.Add(new Product { Id = 3, Name = "Product 3", Price = 10.0 });
            _products.Add(new Product { Id = 4, Name = "Product 4", Price = 20.0 });
            _products.Add(new Product { Id = 5, Name = "Product 5", Price = 10.0 });
            _products.Add(new Product { Id = 6, Name = "Product 6", Price = 20.0 });
            _products.Add(new Product { Id = 7, Name = "Product 7", Price = 10.0 });
            _products.Add(new Product { Id = 8, Name = "Product 8", Price = 20.0 });
            _products.Add(new Product { Id = 9, Name = "Product 9", Price = 10.0 });
            _products.Add(new Product { Id = 10, Name = "Product 10", Price = 20.0 });
            _products.Add(new Product { Id = 11, Name = "Product 11", Price = 10.0 });
            _products.Add(new Product { Id = 12, Name = "Product 12", Price = 20.0 });
        }
       
    }
}
