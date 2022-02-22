using Domain.Models;

namespace DataAccess.Interfeces
{
    public interface IRepInvoice
    {
        DetailInvoice GetInvoiceDetailById(int id);
        void AddInvoice(DetailInvoice[] detalis);
        Invoice GetInvoiceById(int id);
        Invoice[] GetInvoice();
    }
}
