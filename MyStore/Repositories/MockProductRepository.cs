using MyStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyStore.Repositories
{
    // CHỈ GIỮ LẠI CLASS, KHÔNG ĐỂ INTERFACE Ở ĐÂY
    public class MockProductRepository : IProductRepository 
    {
        private readonly List<Product> _products;

        public MockProductRepository() {
            _products = new List<Product> {
                new Product { Id = 1, Name = "Laptop", Price = 1000, Description = "A high-end laptop" }
            };
        }

        public IEnumerable<Product> GetAll() => _products;

        public Product GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product) {
            product.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(product);
        }

        public void Update(Product product) {
            var index = _products.FindIndex(p => p.Id == product.Id);
            if (index != -1) _products[index] = product;
        }

        public void Delete(int id) {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null) _products.Remove(product);
        }
    }
}