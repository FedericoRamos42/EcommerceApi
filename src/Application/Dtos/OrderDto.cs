using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateTime { get; set; }
        public StatusOrder StatusOrder { get; set; } 
        public List<OrderDetailsDto> Details { get; set; } = new List<OrderDetailsDto>();


        public static OrderDto ToDto(Order order) => new()
        {
            Id = order.Id,
            UserId = order.User.Id,
            TotalPrice = order.TotalPrice,
            DateTime = order.DateTime,
            StatusOrder = order.StatusOrder,
            Details = order.Details.Select(OrderDetailsDto.ToDto).ToList(),

        };

        public static IEnumerable<OrderDto> ToList(IEnumerable<Order> orders)
        {
            List<OrderDto> list = new List<OrderDto>();
            foreach (var order in orders)
            {
                list.Add(ToDto(order));
            }
            return list;
           
        }
    }
}
