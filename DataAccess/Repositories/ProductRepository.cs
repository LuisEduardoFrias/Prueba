using DataAccess.Db_Context;
using Domain.ExtensionMethods;
using Domain.Models;
using System;
using System.Data;

namespace DataAccess.Repositories
{
    public class ProductRepository : RepositoryBase
    {
        public ProductRepository(string Connection)
        {
            sqlCommand = DbContext.GetContext(Connection, CommandType.Text);
        }

        public Product[] GetInvoice()
        {
            return Get<Product>((facturas, reader) =>
            {
                return new Product
                {
                    CodigoBarra = reader.LongValue("CodigoBarra"),
                    Nombre = reader.StringValue("Nombre"),
                    Precio = reader.DecimalValue("Precio"),
                    Existencias = reader.IntValue("Existencias"),
                };

            }, "Products");
        }

        public Product GetInvoiceById(int id)
        {
            return GetById<Product>((facturas, reader) =>
            {
                return new Product
                {
                    CodigoBarra = reader.LongValue("CodigoBarra"),
                    Nombre = reader.StringValue("Nombre"),
                    Precio = reader.DecimalValue("Precio"),
                    Existencias = reader.IntValue("Existencias"),
                };

            }, "Products", id);
        }

        public void AddProduct(Product product)
        {
            string query = $"Insert into Products values"
                    + $"({product.CodigoBarra}, "
                    + $"{product.Nombre}, "
                    + $"{product.Precio}, "
                    + $"{product.Existencias})";

            sqlCommand.ExecuteQuery(query,
                (value) =>
                {
                    if (value < 1)
                        throw new Exception();

                }, (ex) =>
                {

                });
        }
    }
}
