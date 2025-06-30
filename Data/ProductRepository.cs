using CosmeticsApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CosmeticsApp.Data
{
    public class ProductRepository
    {
        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();

            using (var connection = Database.GetConnection())
            {
                string query = "SELECT * FROM products";
                using var command = new MySqlCommand(query, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var product = new Product
                    {
                        Id = reader.GetInt32("id"),
                        Type = reader.GetString("type"),
                        Brand = reader.GetString("brand"),
                        Manufacturer = reader.GetString("manufacturer"),
                        ExpirationDate = reader.GetDateTime("expiration_date"),
                        Price = reader.GetDecimal("price")
                    };

                    products.Add(product);
                }
            }

            return products;
        }

        public void AddProduct(Product product)
        {
            using var connection = Database.GetConnection();
            string query = @"INSERT INTO products (type, brand, manufacturer, expiration_date, price) 
                             VALUES (@type, @brand, @manufacturer, @expiration_date, @price)";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@type", product.Type);
            command.Parameters.AddWithValue("@brand", product.Brand);
            command.Parameters.AddWithValue("@manufacturer", product.Manufacturer);
            command.Parameters.AddWithValue("@expiration_date", product.ExpirationDate);
            command.Parameters.AddWithValue("@price", product.Price);

            command.ExecuteNonQuery();
        }

        public void UpdateProduct(Product product)
        {
            using var connection = Database.GetConnection();
            string query = @"UPDATE products 
                             SET type = @type, brand = @brand, manufacturer = @manufacturer, 
                                 expiration_date = @expiration_date, price = @price 
                             WHERE id = @id";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@type", product.Type);
            command.Parameters.AddWithValue("@brand", product.Brand);
            command.Parameters.AddWithValue("@manufacturer", product.Manufacturer);
            command.Parameters.AddWithValue("@expiration_date", product.ExpirationDate);
            command.Parameters.AddWithValue("@price", product.Price);
            command.Parameters.AddWithValue("@id", product.Id);

            command.ExecuteNonQuery();
        }

        public void DeleteProduct(int id)
        {
            using var connection = Database.GetConnection();
            string query = "DELETE FROM products WHERE id = @id";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public List<Product> SearchProducts(string keyword)
        {
            var results = new List<Product>();
            using var connection = Database.GetConnection();
            string query = @"SELECT * FROM products 
                             WHERE type LIKE @kw OR brand LIKE @kw OR manufacturer LIKE @kw";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@kw", $"%{keyword}%");
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var product = new Product
                {
                    Id = reader.GetInt32("id"),
                    Type = reader.GetString("type"),
                    Brand = reader.GetString("brand"),
                    Manufacturer = reader.GetString("manufacturer"),
                    ExpirationDate = reader.GetDateTime("expiration_date"),
                    Price = reader.GetDecimal("price")
                };
                results.Add(product);
            }

            return results;
        }
    }
}
