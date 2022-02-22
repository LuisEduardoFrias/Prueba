using Domain.Models;

namespace DataAccess.Interfeces
{
    public interface IRepUser
    {
        User[] GetInvoice();
        User GetInvoiceById(int id);
        void AddProduct(User user);
    }
}
