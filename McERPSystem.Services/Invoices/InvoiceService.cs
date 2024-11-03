using McERPSystem.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McERPSystem.Services.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ApplicationDbContext _context;

        public InvoiceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Invoice> CreateInvoiceAsync(int orderId, List<InvoiceItem> invoiceItems)
        {
            var invoice = new Invoice
            {
                OrderId = orderId,
                InvoiceDate = DateTime.UtcNow,
                TotalAmount = invoiceItems.Sum(i => i.QuantityInvoiced * i.Price),
                InvoiceItems = invoiceItems
            };

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task<List<Invoice>> GetInvoicesByOrderIdAsync(int orderId)
        {
            return await _context.Invoices
                .Include(i => i.InvoiceItems)
                .Where(i => i.OrderId == orderId)
                .ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            return await _context.Invoices
                .Include(i => i.InvoiceItems)
                .FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<int> GetTotalInvoicedQuantityForOrderItem(int orderItemId)
        {
            return await _context.InvoiceItems
                .Where(ii => ii.OrderItemId == orderItemId)
                .SumAsync(ii => ii.QuantityInvoiced);
        }

    }
}
