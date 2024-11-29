using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces;
using MercadoPago.Client.Preference;
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

        public async Task<Preference> ProccessPaymentAsync(int id)
        {
            Order order = await _orderRepository.GetByIdWithOrderDetails(id);
            if (order == null)
            {
                throw new NotFoundException($"order with id {id} does not exist");
            }

            //var payment = new Payment
            //{
            //    OrderId = order.Id,
            //    Amount = order.TotalPrice,
            //    CreatedAt = DateTime.UtcNow,
            //    Provider = "MercadoPago",
            //    Status = PaymentStatus.Pending
            //};


            List<PreferenceItemRequest> list = new List<PreferenceItemRequest>();
            foreach (var item in order.Details) 
            {
                list.Add(new PreferenceItemRequest
                {
                    Id = item.Product.Id.ToString(),
                    Title = item.Product.Name,
                    CurrencyId = "ARS",
                    Quantity = item.Quantity,
                    Description = "Descripcion de mi producto",
                    UnitPrice = item.Product.Price,
                });
                
            }
            var (name, surname) = SplitFullName(order.User.FullName);
            //aca se arma request;
            var request = new PreferenceRequest
            {
                Items = list,
                Payer = new PreferencePayerRequest
                {
                    Name = name,
                    Surname = surname,
                    Email = order.User.Email,

                },
                BackUrls = new PreferenceBackUrlsRequest
                {
                    Success = "http://httpbin.org/get?back_url=success",
                    Failure = "http://httpbin.org/get?back_url=failure",
                    Pending = "http://httpbin.org/get?back_url=pending"
                },

                AutoReturn = "approved",
                PaymentMethods = new PreferencePaymentMethodsRequest
                {
                    ExcludedPaymentMethods = [],
                    ExcludedPaymentTypes = [],
                    Installments = 8,
                    DefaultPaymentMethodId = "account_money"

                },
                StatementDescriptor = "Eccomerce Ramos",
                ExternalReference = order.Id.ToString(),
                Expires = true,
                ExpirationDateFrom = DateTime.Now,
                ExpirationDateTo = DateTime.Now.AddMinutes(10)
            };

            return await _mpProvider.CreatePaymentPreferenceAsync(request);
        }

        private static (string Name, string Surname) SplitFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return (string.Empty, string.Empty);

            var nameParts = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = nameParts.Length > 0 ? nameParts[0] : string.Empty;
            string surname = nameParts.Length > 1
                ? string.Join(' ', nameParts.Skip(1))
                : string.Empty;

            return (name, surname);
        }
    }
}
