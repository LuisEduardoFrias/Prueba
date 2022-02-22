using Domain.Models;

namespace DataAccess.Interfeces
{
    public interface IRepProduct
    {
        Product[] GetInvoice();
        Product GetInvoiceById(int id);
        void AddProduct(Product product);
    }
}
