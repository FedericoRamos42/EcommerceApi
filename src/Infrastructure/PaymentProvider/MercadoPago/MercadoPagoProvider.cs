using Azure.Core;
using MercadoPago.Config;
using Microsoft.Extensions.Configuration;
using MercadoPago.Client.Preference;
using Application.Interfaces;
using Newtonsoft.Json;
using MercadoPago.Resource.Preference;

namespace Infrastructure.PaymentProvider.MercadoPago
{
    public class MercadoPagoProvider : IMercadoPagoProvider
    {
        private readonly IConfiguration _configuration;
        public MercadoPagoProvider(IConfiguration configuration)
        {       
          _configuration = configuration;
        }

        public async Task<Preference> CreatePaymentPreferenceAsync(PreferenceRequest request)
        {
            var tokenAcces = "TEST-8438462373245912-112917-83b88566d7950dfe2b33db8132d61d52-380263351";


            MercadoPagoConfig.AccessToken = tokenAcces;
            
            var client = new PreferenceClient();
            Console.WriteLine(JsonConvert.SerializeObject(request, Formatting.Indented));
            return await client.CreateAsync(request);
        }

    }
}
