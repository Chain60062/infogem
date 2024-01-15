
using InfoGem.Exceptions;
using InfoGem.Models;
using InfoGem.Repositories;

namespace InfoGem.Services;

public class PaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private static readonly Random random = new Random();
    public PaymentService(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<Payment?> GetUserPayment(long orderId)
    {
        return await _paymentRepository.GetOrderPayment(orderId);
    }
    public async Task<Payment?> GetPaymentById(long PaymentId)
    {
        return await _paymentRepository.GetPaymentById(PaymentId);
    }

    public async Task<Payment?> CancelPayment(long paymentId)
    {
        var payment = await _paymentRepository.GetPaymentById(paymentId);

        if (payment is null) throw new NotFoundException("Pagamento não encontrado.");

        return await _paymentRepository.CancelPayment(payment);
    }
}

