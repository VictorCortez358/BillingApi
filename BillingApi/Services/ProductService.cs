using BillingApi.Models;
using BillingApi.Repositories;

namespace BillingApi.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public IEnumerable<Product> GetProducts()
    {
        return productRepository.GetAllProducts();
    }

    public Product? GetProduct(int id)
    {
        var product = productRepository.GetProductBydId(id);
        var found = product ?? throw new NullReferenceException("Product not found");
        return found;
    }

    public void CreateProduct(Product product)
    {
        if (product.Price <= 0)
        {
            throw new ArgumentException("Price cannot be negative");
        }

        if (product.Stock < 0)
        {
            throw new ArgumentException("Stock cannot be negative");
        }
        
        if (product.Barcode == null)
        {
            throw new ArgumentException("Barcode cannot be null");
        }
        
        productRepository.AddProduct(product);
    }

    public void UpdateProduct(Product product)
    {
        if (product.Price <= 0)
        {
            throw new ArgumentException("Price cannot be negative");
        }

        if (product.Stock < 0)
        {
            throw new ArgumentException("Stock cannot be negative");
        }
        
        if (product.Barcode == null)
        {
            throw new ArgumentException("Barcode cannot be null");
        }
        
        productRepository.UpdateProduct(product);
    }

    public void DeleteProduct(int id)
    {
        var product = productRepository.GetProductBydId(id);
        var found = product ?? throw new NullReferenceException("Product not found");
        productRepository.DeleteProduct(found.Id);
    }
}