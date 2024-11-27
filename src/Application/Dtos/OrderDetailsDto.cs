using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class OrderDetailsDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }

        public static OrderDetailsDto ToDto(OrderDetail detail)
        {
            return new OrderDetailsDto
            {
                Id = detail.Id,
                OrderId = detail.Order.Id,
                ProductId = detail.Product.Id,
                Quantity = detail.Quantity,
                Total = detail.Total,
            };
        }
    }
}
