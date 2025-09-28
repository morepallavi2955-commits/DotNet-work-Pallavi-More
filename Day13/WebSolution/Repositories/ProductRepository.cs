//create respository to read products from json file
using System.Text.Json;
using Entities;
using Repositories;

public class ProductRepository : IProductRepository
{
    public IEnumerable<Product> GetAllProducts()
    {
        return JSONCatalogManager.LoadProducts();
    }


    public Product? GetProductById(int id)
    {
        IEnumerable<Product> products = GetAllProducts();
        return products.FirstOrDefault(p => p.Id == id);
    }

    public void AddProduct(Product product)
    {
        List<Product> products = GetAllProducts().ToList();
        products.Add(product);
        JSONCatalogManager.SaveProducts(products);
    }

    public void UpdateProduct(Product product)
    {
        
        List<Product> products = GetAllProducts().ToList();
        var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
        if (existingProduct != null)
        {
            existingProduct.Title = product.Title;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.ImageUrl = product.ImageUrl;
            JSONCatalogManager.SaveProducts(products);
        }
    }

    public void DeleteProduct(int id)
    {
        List<Product> products = GetAllProducts().ToList();
        var productToRemove = products.FirstOrDefault(p => p.Id == id);
        if (productToRemove != null)
        {
            products.Remove(productToRemove);
            JSONCatalogManager.SaveProducts(products);
        }
    }
}