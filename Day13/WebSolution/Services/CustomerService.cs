
namespace Services;

using Entities;
using System.Collections.Generic;
using Repositories;
public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepositories;


    public CustomerService(ICustomerRepository customerRepositories)
    {
        _customerRepositories = customerRepositories;
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        return _customerRepositories.GetAllCustomers();
    }

    public Customer? GetCustomerById(int id)
    {
        return _customerRepositories.GetCustomerById(id);
    }

    public void AddCustomer(Customer customer)
    {
        _customerRepositories.AddCustomer(customer);
    }
}