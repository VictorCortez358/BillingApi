using BillingApi.Models;

namespace BillingApi.Repositories;

public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();
    Product? GetProductBydId(int id);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int id);
}