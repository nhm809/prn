using DAL.Data;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>
    {
        public PaymentRepository() : base()
        {
        }

        public async Task CreatePendingPaymentAsync(int orderId)
        {
            var payment = new Payment
            {
                OrderId = orderId,
                PaymentType = "VNPay",
                PaymentStatus = "Pending",
                PaymentDate = DateTime.Now
            };

            await AddAsync(payment);
            await SaveChangesAsync();
        }

        public async Task UpdatePaymentStatusAsync(int orderId, string status)
        {
            var payment = await FindAsync(p => p.OrderId == orderId);
            var first = payment.FirstOrDefault();
            if (first != null)
            {
                first.PaymentStatus = status;
                Update(first);
                await SaveChangesAsync();
            }
        }
    }

}
