using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using MercadoPago.Resource.Preference;

namespace Application.Services
{
    public class PaymentProviderService
    {
        private readonly IMercadoPagoProvider _mpProvider;
        private readonly IOrderRepository _orderRepository;
        public PaymentProviderService(IMercadoPagoProvider provider,IOrderRepository orderRepository)
        {
            _mpProvider = provider;
            _orderRepository = orderRepository;
            
        }

        public async Task<Preference> CreatePayment(int id)
        {
            Order order = await _orderRepository.GetByIdWithOrderDetails(id);

            if (order is null)
            {
                throw new NotFoundException($"Order with id {id} does not exist");
            }

            var preference = await  _mpProvider.CreatePaymentPreferenceAsync(order);
            return  preference;
        }

        public async Task GetStatusNotification(string id)
        {
            var response = await _mpProvider.ProccesNotification(id);

            // Imprime el contenido del PaymentResponseDto
            Console.WriteLine($"Id: {response.Id}");
            Console.WriteLine($"Status: {response.Status}");
            Console.WriteLine($"Status Detail: {response.StatusDetail}");
            Console.WriteLine($"Transaction Amount: {response.TransactionAmount}");
            Console.WriteLine($"Date Created: {response.DateCreated}");
            Console.WriteLine($"Date Approved: {response.DateApproved}");
            Console.WriteLine($"Payer Email: {response.PayerEmail}");
            Console.WriteLine($"External Reference: {response.ExternalReference}");


        }
    }
}
