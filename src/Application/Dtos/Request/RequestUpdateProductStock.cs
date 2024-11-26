using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Request
{
    public class RequestUpdateProductStock
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Stock {  get; set; }
    }
}
