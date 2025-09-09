using Dominio.Entities;
using Dominio.Ports.Secundary;
using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace JsonRepository
{
    public class ProductRepository: IRepository
    {
        private readonly string _path;

        public ProductRepository(string path)
        {
            _path = path;
        }

        public void Save(Product product)
        {
            var products = GetAll();
            products.Add(product);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(products, options);
            File.WriteAllText(_path, jsonString);

       }

        public List<Product> GetAll()
        {
            if (!File.Exists(_path))
            {
                return new List<Product>();
            }
            string jsonString = File.ReadAllText(_path);
            var products = JsonSerializer.Deserialize<List<Product>>(jsonString);

            return products ?? new List<Product>();
        }





    }
}