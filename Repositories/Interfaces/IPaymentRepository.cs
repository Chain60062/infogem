using InfoGem.Models;

namespace InfoGem.Repositories;

public interface IPaymentRepository
{
    public Task<Payment?> GetOrderPayment(long orderId);
    public Task<Payment?> PayOrder(Payment payment);
    public Task<Payment?> CancelPayment(Payment payment);
    public Task<Payment?> GetPaymentById(long paymentId);
}