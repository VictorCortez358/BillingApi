using BillingApi.Data;
using BillingApi.Models;

namespace BillingApi.Repositories;

public class ProductRepository(BillingContext context) : IProductRepository
{
    public IEnumerable<Product> GetAllProducts()
    {
        return context.Products.ToList();
    }

    public Product? GetProductBydId(int id)
    {
        var product = context.Products.Find(id);
        return product == null ? null : context.Products.Find(id);
    }

    public void AddProduct(Product product)
    {
        context.Products.Add(product);
        // This confirm the changes 
        context.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
        context.Products.Update(product);
        context.SaveChanges();
    }

    public void DeleteProduct(int id)
    {
        var product = context.Products.Find(id);
        if (product == null) return;
        context.Products.Remove(product);
        context.SaveChanges();
    }
}