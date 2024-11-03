using McERPSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McERPSystem.Services.Invoices
{
    public interface IInvoiceService
    {
        Task<Invoice> CreateInvoiceAsync(int orderId, List<InvoiceItem> invoiceItems);
        Task<List<Invoice>> GetInvoicesByOrderIdAsync(int orderId);
        Task<Invoice> GetInvoiceByIdAsync(int id);

        Task<int> GetTotalInvoicedQuantityForOrderItem(int orderItemId);
    }
}
