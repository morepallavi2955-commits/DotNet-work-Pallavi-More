namespace Repositories;

using Entities;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
 public interface ICustomerRepository
    {
    IEnumerable<Customer> GetAllCustomers();
    Customer? GetCustomerById(int id);
    void AddCustomer(Customer customer);

    }
