using Microsoft.Data.SqlClient;
using dapperplay.Models;
using Dapper;

var pizzas = new List<Product>();


string connectionString = "Server=localhost;Database=ContosoPizza;User Id=sa;Password=P@ssw0rd;Encrypt=false;";

// using (var connection = new SqlConnection(connectionString))
// {
//     connection.Open();
//     var sql = "SELECT * FROM Products";
//     using (var command = new SqlCommand(sql, connection))
//     {
//         using (var reader = command.ExecuteReader())
//         {
//             while (reader.Read())
//             {
//                 var pizza = new Product
//                 {
//                     Id = (int)reader["Id"],
//                     Name = (string)reader["Name"],
//                     Price = (decimal)reader["Price"]
//                 };
//                 pizzas.Add(pizza);
//             }
//         }
//     }
// }

// using (var connection = new SqlConnection(connectionString))
// {
//     var sql = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price)";
//     var parameters = new { Name = "Pepperoni", Price = 12.99m };
//     connection.Execute(sql, parameters);
// }

using (var connection = new SqlConnection(connectionString))
{
    var sql = "SELECT * FROM Products";
    pizzas = connection.Query<Product>(sql).ToList();
}

foreach (var pizza in pizzas)
{
    Console.WriteLine($"Id: {pizza.Id}, Name: {pizza.Name}, Price: {pizza.Price}");
}