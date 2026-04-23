using MyStore.Models; // Đã sửa từ YourNamespace thành MyStore
using System.Collections.Generic;

namespace MyStore.Repositories
{
    public interface IProductRepository {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}