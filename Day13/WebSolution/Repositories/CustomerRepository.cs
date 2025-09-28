//create respository to read products from json file
using System.Text.Json;
using Entities;
using Repositories;

public class CustomerRepository : ICustomerRepository
{
    //automic operations
    public IEnumerable<Customer> GetAllCustomers()
    {
        return JSONCatalogManager.LoadCustomers();
    }


    public Customer? GetCustomerById(int id)
    {
        IEnumerable<Customer> custmers = GetAllCustomers();
        return custmers.FirstOrDefault(p => p.Id == id);
    }

    public void AddCustomer(Customer customer)
    {
        List<Customer> custmers = GetAllCustomers().ToList();
        custmers.Add(customer);
        JSONCatalogManager.SaveCustomers(custmers);
    }
}