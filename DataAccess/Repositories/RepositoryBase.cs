using DataAccess.Db_Context;
using DataAccess.Enums;
using DataAccess.Interfeces;
using Domain.Models;
using System;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class RepositoryBase : IRepInvoice, IRepProduct, IRepUser
    {
        protected static string connection => sqlCommand.Connection.ConnectionString;
        protected static SqlCommand sqlCommand = null;

        public static RepositoryBase Get(UseRepositories repositories, string connection)
        {
            if (repositories == UseRepositories.Invoice)
            {
                return new InvoiceRepository(connection);
            }
            else if (repositories == UseRepositories.Product)
            {
                return new ProductRepository(connection);
            }
            else
            {
                return new UserRepository(connection);
            }
        }

        protected T[] Get<T>(Func<T[], SqlDataReader, T> func, string table) where T : ErrorBase, new()
        {
            string query = $"Select * from {table}";

            T[] array = new T[0];

            sqlCommand.ExecuteToReader(query,
                (reader) =>
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        Array.Resize(ref array, i + 1);

                        array[i] = func(array, reader);

                        i++;
                    }
                }, (ex) =>
                {
                    array = new T[] { new T { IsError = true, ErrorMessage = ex.Message } };
                });

            return array;
        }

        protected T GetById<T>(Func<T, SqlDataReader, T> func, string table, int id) where T : ErrorBase, new()
        {
            string query = $"Select * from {table} where Id = {id}";

            T t = new T();

            sqlCommand.ExecuteToReader(query,
                (reader) =>
                {
                    while (reader.Read())
                    {
                        t = func(t, reader);
                    }
                }, (ex) =>
                {
                    t = new T { IsError = true, ErrorMessage = ex.Message };
                });

            return t;
        }

        #region NotImplementedException

        public DetailInvoice GetInvoiceDetailById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddInvoice(DetailInvoice[] detalis)
        {
            throw new NotImplementedException();
        }

        public Invoice GetInvoiceById(int id)
        {
            throw new NotImplementedException();
        }

        public Invoice[] GetInvoice()
        {
            throw new NotImplementedException();
        }

        Product[] IRepProduct.GetInvoice()
        {
            throw new NotImplementedException();
        }

        Product IRepProduct.GetInvoiceById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        User[] IRepUser.GetInvoice()
        {
            throw new NotImplementedException();
        }

        User IRepUser.GetInvoiceById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(User user)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
