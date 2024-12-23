//using OrderMicroserviceAPI.Interfaces;
//using OrderMicroserviceAPI.Models.DTOs;
//using OrderMicroserviceAPI.Models;
//using OrderMicroserviceAPI.Repositories;

//namespace OrderMicroserviceAPI.Services
//{
//    public class OrderService : IOrderService
//    {
//        private readonly OrderRepository _orderRepository;
//        private readonly OrderDetailsRepository _orderDetailsRepository;
//        private readonly ILogger<OrderService> _logger;

//        public OrderService(OrderRepository orderRepository,
//                            OrderDetailsRepository orderDetailsRepository,
//                            ILogger<OrderService> logger)
//        {
//            _orderRepository = orderRepository;
//            _orderDetailsRepository = orderDetailsRepository;
//            _logger = logger;
//        }
//        public async Task<Order> AddOrder(OrderDetailsDTO orderDetails)
//        {
//            if (orderDetails == null)
//            {
        //        throw new ArgumentNullException(nameof(orderDetails));
        //    }
        //    if (orderDetails.Products.Count == 0)
        //    {
        //        throw new ArgumentNullException(nameof(orderDetails.Products));
        //    }
        //    var order = new Order
        //    {
        //        OrderStatus = orderDetails.OrderStatus,
        //        OrderDate = DateTime.Now,
        //        Username = orderDetails.Username
        //    };
        //    var orderInserted = await _orderRepository.Add(order);
        //    bool chckOrderDetails = await AddOrderDetails(orderInserted.OrderId, orderDetails.Products);
        //    return orderInserted;
        //}

        //private async Task<bool> AddOrderDetails(int orderId, List<ProductDTO> products)
        //{
        //    foreach (var product in products)
        //    {
        //        var orderDetails = new OrderDetails
        //        {
        //            OrderId = orderId,
        //            ProdcutId = product.ProductId,
        //            Price = product.Price,
        //            Quantity = product.Quantity
        //        };
        //        await _orderDetailsRepository.Add(orderDetails);
        //    }
        //    return true;
        //}

        //public async Task<OrderDetailsDTO> DeleteOrder(int orderId)
        //{
        //    var checkOrderDetails = await DeleteOrderDetails(orderId);
        //    if (checkOrderDetails)
        //    {
        //        var order = await _orderRepository.Get(orderId);
        //        if (order == null)
        //        {
        //            throw new Exception("Order not found");
        //        }
        //        order.OrderStatus = "Cancelled";
        //        var checkOrder = await _orderRepository.Update(orderId, order);
        //        return new OrderDetailsDTO
        //        {
        //            OrderId = checkOrder.OrderId,
        //            OrderStatus = checkOrder.OrderStatus,
        //            OrderDate = checkOrder.OrderDate,
        //            Username = checkOrder.Username
        //        };
        //    }
        //    throw new Exception("Unable to cancel order");
        //}

        //private async Task<bool> DeleteOrderDetails(int orderId)
        //{
        //    var _orderDetails = (await _orderDetailsRepository.Get()).Where(order => order.OrderId == orderId).ToList();
        //    foreach (var orderDetail in _orderDetails)
        //    {
        //        await _orderDetailsRepository.Delete(orderDetail.Id);
        //    }
        //    return true;
        //}

        //public async Task<OrderDetailsDTO> GetOrder(int orderId)
        //{
        //    var order = await _orderRepository.Get(orderId);
        //    if (order == null)
        //    {
        //        throw new Exception("Order not found");
        //    }
        //    var orderDetails = (await _orderDetailsRepository.Get()).Where(order => order.OrderId == orderId).ToList();
        //    var products = new List<ProductDTO>();
        //    foreach (var orderDetail in orderDetails)
        //    {
        //        products.Add(new ProductDTO
        //        {
        //            ProductId = orderDetail.ProdcutId,
        //            Price = orderDetail.Price,
        //            Quantity = orderDetail.Quantity
        //        });
        //    }
        //    return new OrderDetailsDTO
        //    {
        //        OrderId = order.OrderId,
        //        OrderStatus = order.OrderStatus,
        //        OrderDate = order.OrderDate,
        //        Username = order.Username,
        //        Products = products
        //    };
        //}

//        public async Task<OrderDetailsDTO> UpdateOrder(int orderId, OrderDetailsDTO orderDetails)
//        {
//            var order = await _orderRepository.Get(orderId);
//            if (order == null)
//            {
//                throw new Exception("Order not found");
//            }
//            order.OrderStatus = orderDetails.OrderStatus;
//            var checkOrder = await _orderRepository.Update(orderId, order);
//            return new OrderDetailsDTO
//            {
//                OrderId = checkOrder.OrderId,
//                OrderStatus = checkOrder.OrderStatus,
//                OrderDate = checkOrder.OrderDate,
//                Username = checkOrder.Username
//            };
//        }
//    }
//}



﻿using OrderMicroserviceAPI.Interfaces;
using OrderMicroserviceAPI.Models;
using OrderMicroserviceAPI.Models.DTOs;
using OrderMicroserviceAPI.Repositories;

namespace OrderMicroserviceAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order, int> _orderRepository;
        private readonly IRepository<OrderDetails, int> _orderDetailsRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IRepository<Order, int> orderRepository,
                            IRepository<OrderDetails, int> orderDetailsRepository,
                            ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _orderDetailsRepository = orderDetailsRepository;
            _logger = logger;
        }
        public async Task<Order> AddOrder(OrderDetailsDTO orderDetails)
        {
            if (orderDetails == null)
            {
                throw new ArgumentNullException(nameof(orderDetails));
            }
            if (orderDetails.Products.Count == 0)
            {
                throw new ArgumentNullException(nameof(orderDetails.Products));
            }
            var order = new Order
            {
                OrderStatus = orderDetails.OrderStatus,
                OrderDate = DateTime.Now,
                Username = orderDetails.Username
            };
            var orderInserted = await _orderRepository.Add(order);
            bool chckOrderDetails = await AddOrderDetails(orderInserted.OrderId, orderDetails.Products);
            return orderInserted;
        }

        private async Task<bool> AddOrderDetails(int orderId, List<ProductDTO> products)
        {
            foreach (var product in products)
            {
                var orderDetails = new OrderDetails
                {
                    OrderId = orderId,
                    ProdcutId = product.ProductId,
                    Price = product.Price,
                    Quantity = product.Quantity
                };
                await _orderDetailsRepository.Add(orderDetails);
            }
            return true;
        }

        public async Task<OrderDetailsDTO> DeleteOrder(int orderId)
        {
            var checkOrderDetails = await DeleteOrderDetails(orderId);
            if (checkOrderDetails)
            {
                var order = await _orderRepository.Get(orderId);
                if (order == null)
                {
                    throw new Exception("Order not found");
                }
                order.OrderStatus = "Cancelled";
                var checkOrder = await _orderRepository.Update(orderId, order);
                return new OrderDetailsDTO
                {
                    OrderId = checkOrder.OrderId,
                    OrderStatus = checkOrder.OrderStatus,
                    OrderDate = checkOrder.OrderDate,
                    Username = checkOrder.Username
                };
            }
            throw new Exception("Unable to cancel order");
        }

        private async Task<bool> DeleteOrderDetails(int orderId)
        {
            var _orderDetails = (await _orderDetailsRepository.Get()).Where(order => order.OrderId == orderId).ToList();
            foreach (var orderDetail in _orderDetails)
            {
                await _orderDetailsRepository.Delete(orderDetail.Id);
            }
            return true;
        }

        public async Task<OrderDetailsDTO> GetOrder(int orderId)
        {
            var order = await _orderRepository.Get(orderId);
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            var orderDetails = await _orderDetailsRepository.Get();
            orderDetails = orderDetails.Where(order => order.OrderId == orderId).ToList();
            var products = new List<ProductDTO>();
            foreach (var orderDetail in orderDetails)
            {
                products.Add(new ProductDTO
                {
                    ProductId = orderDetail.ProdcutId,
                    Price = orderDetail.Price,
                    Quantity = orderDetail.Quantity
                });
            }
            return new OrderDetailsDTO
            {
                OrderId = order.OrderId,
                OrderStatus = order.OrderStatus,
                OrderDate = order.OrderDate,
                Username = order.Username,
                Products = products
            };
        }

        public async Task<OrderDetailsDTO> UpdateOrder(int orderId, OrderDetailsDTO orderDetails)
        {
            var order = await _orderRepository.Get(orderId);
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            order.OrderStatus = orderDetails.OrderStatus;
            var checkOrder = await _orderRepository.Update(orderId, order);
            return new OrderDetailsDTO
            {
                OrderId = checkOrder.OrderId,
                OrderStatus = checkOrder.OrderStatus,
                OrderDate = checkOrder.OrderDate,
                Username = checkOrder.Username
            };
        }
    }
}