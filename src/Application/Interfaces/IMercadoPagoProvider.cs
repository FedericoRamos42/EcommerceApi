﻿using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMercadoPagoProvider
    {
        Task<Preference> CreatePaymentPreferenceAsync(PreferenceRequest request);

    }
}
