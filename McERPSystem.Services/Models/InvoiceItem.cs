using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McERPSystem.Services.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; } // Navigation property
        public int OrderItemId { get; set; }
        public OrderItem OrderItem { get; set; } // Navigation property
        public int QuantityInvoiced { get; set; } // Partial quantity invoiced
        public decimal Price { get; set; }
    }
}
