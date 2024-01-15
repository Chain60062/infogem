using InfoGem.Data;
using InfoGem.Exceptions;
using InfoGem.Models;

namespace InfoGem.Repositories;

public class EFPaymentRepository : IPaymentRepository
{
    private readonly AppDbContext _db;

    public EFPaymentRepository(AppDbContext db)
    {
        _db = db;
    }
    public async Task<Payment?> GetPaymentById(long paymentId) =>
        await _db.Payments.FindAsync(paymentId);

    public async Task<Payment?> PayOrder(Payment payment)
    {

        payment.Status = PaymentStatus.Pending;

        await _db.Payments.AddAsync(payment);

        await _db.SaveChangesAsync();

        return payment;
    }

    public async Task<Payment?> CancelPayment(Payment payment)
    {
        payment.Status = PaymentStatus.Cancelled;

        await _db.SaveChangesAsync();

        return payment;
    }

    public async Task<Payment?> GetOrderPayment(long orderId)
    {
        var order = await _db.Orders.FindAsync(orderId);

        if (order is null) throw new NotFoundException("Pedido não encontrado");

        return order.Payment;
    }
}