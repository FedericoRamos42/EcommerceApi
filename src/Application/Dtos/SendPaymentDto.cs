using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class SendPaymentDto
    {
        public string Email { get; set; }
        public string IdentificationType { get; set; } = "CC"; 
        public string IdentificationNumber { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string ZipCode { get; set; }
        public string PhoneAreaCode { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Amount { get; set; } 
        public string Description { get; set; } 
    }
}
