using Azure.Core;
using MercadoPago.Config;
using Microsoft.Extensions.Configuration;
using MercadoPago.Client.Preference;
using Application.Interfaces;
using Newtonsoft.Json;
using MercadoPago.Resource.Preference;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using Domain.Entities;
using Domain.Exceptions;
using Application.Dtos.Response;

namespace Infrastructure.PaymentProvider.MercadoPago
{
    public class MercadoPagoProvider : IMercadoPagoProvider
    {
        private readonly IConfiguration _configuration;
        public MercadoPagoProvider(IConfiguration configuration)
        {       
          _configuration = configuration;
        }

        public async Task<Preference> CreatePaymentPreferenceAsync( Order order)
        {

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

            var request = new PreferenceRequest
            {
                Items = list,
                Payer = new PreferencePayerRequest
                {
                    Email = order.User.Email,

                },

                NotificationUrl = "https://7013-190-103-85-166.ngrok-free.app/api/Payment/webhook",
                StatementDescriptor = "Eccomerce Ramos",
                ExternalReference = order.Id.ToString(),
                Expires = true,
                ExpirationDateFrom = DateTime.Now,
                ExpirationDateTo = DateTime.Now.AddMinutes(10)
            };

            var tokenAcces = "TEST-8438462373245912-112917-83b88566d7950dfe2b33db8132d61d52-380263351";

            MercadoPagoConfig.AccessToken = tokenAcces;
            
            var client = new PreferenceClient();
            return await client.CreateAsync(request);
        }

        public async Task<PaymentResponseDto> ProccesNotification(string id)
        {
            var tokenAccess = "TEST-8438462373245912-112917-83b88566d7950dfe2b33db8132d61d52-380263351";
            string url = $"https://api.mercadopago.com/v1/payments/{id}";

            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenAccess);

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var body = JsonConvert.DeserializeObject<PaymentResponseDto>(responseBody);
                Console.WriteLine(body.DateApproved);
                Console.WriteLine(body.DateCreated);
                Console.WriteLine(body.Status);
                return body;
            }
            else
            {
                throw new Exception($"Error en la solicitud: {response.StatusCode}");
            }
        }
    }
}
