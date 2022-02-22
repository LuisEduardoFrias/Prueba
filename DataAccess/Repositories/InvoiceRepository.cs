using DataAccess.Db_Context;
using Domain.ExtensionMethods;
using Domain.Models;
using System.Data;

namespace DataAccess.Repositories
{
    public class InvoiceRepository : RepositoryBase, IRepInvoice
    {
        public InvoiceRepository(string Connection)
        {
            sqlCommand = DbContext.GetContext(Connection, CommandType.Text);
        }

        public Invoice[] GetInvoice()
        {
            return Get<Invoice>((facturas, reader) =>
            {
                return new Invoice
                {
                    Fecha = reader.DateTimeValue("Fecha"),
                    Rnc = reader.StringValue("Rnc"),
                    Ncf = reader.StringValue("Ncf")
                };

            }, "Invoices");
        }

        public Invoice GetInvoiceById(int id)
        {
            return GetById<Invoice>((facturas, reader) =>
            {
                return new Invoice
                {
                    Fecha = reader.DateTimeValue("Fecha"),
                    Rnc = reader.StringValue("Rnc"),
                    Ncf = reader.StringValue("Ncf")
                };

            }, "Invoices", id);
        }

        public void AddInvoice(DetailInvoice[] detalis)
        {
            #region Insert Invoices

            string query = $"Insert into Invoices values "
               + $"({detalis[0].FacturaId.Fecha}, "
               + $"{detalis[0].FacturaId.Rnc}, "
               + $"{detalis[0].FacturaId.Ncf})";

            sqlCommand.ExecuteQuery(query,
                (value) =>
                {
                    if (value < 1)
                        throw new System.Exception();

                }, (ex) =>
                {

                });

            #endregion

            #region Insert Product

            new ProductRepository(connection).AddProduct(detalis[0].ProductoId);

            #endregion

            #region Insert Detalle de factura

            foreach (DetailInvoice detalle in detalis)
            {
                AddInvoiceDetail(detalle);
            }

            #endregion
        }

        private void AddInvoiceDetail(DetailInvoice invoiceDetail)
        {
            string query = $"Insert into InvoiceDetail value "
                       + $"({invoiceDetail.FacturaId.Id}, "
                       + $"{invoiceDetail.ProductoId.Id}, "
                       + $"{invoiceDetail.Cantidad}, "
                       + $"{invoiceDetail.Precio})";


            sqlCommand.ExecuteQuery(query,
                (value) =>
                {
                    if (value < 1)
                        throw new System.Exception();

                }, (ex) =>
                {

                });
        }

        public DetailInvoice GetInvoiceDetailById(int id)
        {
            return GetById<DetailInvoice>((invoiceDetail, reader) =>
            {
                Product producto = new ProductRepository(connection).GetInvoiceById(reader.IntValue("ProductoId"));

                return new DetailInvoice
                {
                    FacturaId = GetInvoiceById(reader.IntValue("FacturaId")),
                    ProductoId = producto,
                    Cantidad = reader.IntValue("Cantidad"),
                    Precio = reader.DecimalValue("Precio"),
                };

            }, "InvoiceDetails", id);
        }
    }
}
