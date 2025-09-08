namespace SerializationWebAPI.Entities;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Customer(int id, string name, int age = 18)
    {
        Id = id;
        Name = name;
        Age = age;
    }
}