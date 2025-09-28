namespace Services;

using Entities;
using System.Collections.Generic;
public interface ICustomerService
{
    IEnumerable<Customer> GetAllCustomers();
    Customer? GetCustomerById(int id);
    void AddCustomer(Customer customer);

}