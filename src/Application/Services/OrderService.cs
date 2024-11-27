using Application.Dtos;
using Application.Dtos.Request;
using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;

        public OrderService( IOrderRepository orderRepository, IUserRepository userRepository,IProductRepository productRepository,IOrderDetailRepository orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<OrderDto> GetOrderWithDetails(int id)
        {
           var order = await _orderRepository.GetByIdWithOrderDetails(id);

            if (order == null) 
            {
                throw new NotFoundException($" Order with id {id} does not exist");
            }

            return OrderDto.ToDto(order);
           
        }
        public async Task<IEnumerable<OrderDto>> GetAllOrders()
        {
            var list = await _orderRepository.GetAllWithOrderDetails();
            return OrderDto.ToList(list);
        }
        public async Task CreateOrder(RequestCreateOrder orderDto)
        {
            var user = await _userRepository.GetById(orderDto.UserId);
            if (user == null)
            {
                throw new NotFoundException($"User with Id {orderDto.UserId} does not exist");
            }

            List<OrderDetail>detailsOrder = new List<OrderDetail>();
            var listProducts = orderDto.Products;
            decimal total = 0.0m;

            foreach (var product in listProducts) 
            {
                Product entity = await _productRepository.GetById(product.Id);

                if (entity == null) 
                {
                    throw new NotFoundException($"Product with id {product.Id} does not exist");
                }

                if(product.Quantiity > entity.Stock)
                {
                    throw new NotFoundException($"Product with id {product.Id} does not have enough stock");
                }

                total += entity.Price * product.Quantiity;
                entity.Stock -= product.Quantiity;
                await _productRepository.Update(entity);

                OrderDetail detail = new()
                {
                    Product = entity,
                    Quantity = product.Quantiity
                };

                detailsOrder.Add(detail);
            }
            
            Order order = new()
            {
                User = user,
                TotalPrice = total,
                Details = detailsOrder
            };

            await _orderRepository.Create(order);
        }

        public async Task CanceledOrder(int id)
        {
            Order order = await _orderRepository.GetById(id);
            if (order == null)
            {
                throw new NotFoundException($"Order with id {id} does not exist");
            }
            if(order.StatusOrder == Domain.Enums.StatusOrder.Canceled)
            {
                throw new NotFoundException($"this order was canceled");
            }

            var detailsOrder = order.Details;

            foreach (var detail in detailsOrder)
            {
                detail.Product.Stock += detail.Quantity;
                await _productRepository.Update(detail.Product);
            }
            
            order.StatusOrder = Domain.Enums.StatusOrder.Canceled;
            await _orderRepository.Update(order);
        }

    }
}
