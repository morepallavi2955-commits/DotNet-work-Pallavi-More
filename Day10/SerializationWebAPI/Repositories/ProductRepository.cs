namespace SerializationWebAPI.Repositories;

using System.Collections.Generic;
using SerializationWebAPI.Entities;
using System.Text.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;

public class ProductRepository : IProductRepository
{
    private List<Product> _products = new List<Product>();

    public ProductRepository(IWebHostEnvironment env)
    {
        LinkedList<Customer> topCustomers = new LinkedList<Customer>();
        topCustomers.AddLast(new Customer(3, "Smith", 89));
        topCustomers.AddLast(new Customer(4, "Charan", 40));
        topCustomers.AddLast(new Customer(5, "Abhay", 25));

        string jsonString = JsonSerializer.Serialize(topCustomers);
        Console.WriteLine($"Serialized JSON: {jsonString}");
        //Write to file
        File.WriteAllText("customers.json", jsonString);

        var filePath = Path.Combine(env.ContentRootPath, "ReadMockUp", "Products.json");
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions  //handle case sensitiveness
            {
                PropertyNameCaseInsensitive = true
            };
            _products = JsonSerializer.Deserialize<List<Product>>(json, options) ?? new List<Product>();
        }
    }
    //  private void getProducts()
    // {
    //     var json = File.ReadAllText("ReadMockUp/Products.json");
    //     _products = JsonSerializer.Deserialize<List<Product>>(json);
    // }
    public IEnumerable<Product> GetAllProducts() => _products;

    public Product GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        var existingProduct = GetProductById(product.Id);
        if (existingProduct != null)
        {
            existingProduct.Title = product.Title;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
        }
    }

    public void DeleteProduct(int id)
    {
        var product = GetProductById(id);
        if (product != null)
        {
            _products.Remove(product);
        }
    }

}