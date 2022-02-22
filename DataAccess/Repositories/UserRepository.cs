using DataAccess.Db_Context;
using Domain.ExtensionMethods;
using Domain.Models;
using System;
using System.Data;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase
    {
        public UserRepository(string Connection)
        {
            sqlCommand = DbContext.GetContext(Connection, CommandType.Text);
        }

        public User[] GetInvoice()
        {
            return Get<User>((facturas, reader) =>
            {
                return new User
                {
                    NombreUsuario = reader.StringValue("NombreUsuario"),
                    Contrasena = reader.StringValue("Contrasena"),
                };

            }, "Users");
        }

        public User GetInvoiceById(int id)
        {
            return GetById<User>((facturas, reader) =>
            {
                return new User
                {
                    NombreUsuario = reader.StringValue("NombreUsuario"),
                    Contrasena = reader.StringValue("Contrasena"),
                };

            }, "Users", id);
        }

        public void AddProduct(User user)
        {
            string query = $"Insert into Users values "
                    + $"({user.NombreUsuario}, "
                    + $"{user.Contrasena})";

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
