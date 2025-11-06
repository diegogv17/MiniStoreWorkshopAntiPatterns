using MiniStoreWorkshopAntiPatterns.ENTIDADES;
using MiniStoreWorkshopAntiPatterns.Factorias;
using MiniStoreWorkshopAntiPatterns.Interfaces;
using MiniStoreWorkshopAntiPatterns.Promociones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreWorkshopAntiPatterns
{
    public class OrderService
    {
        private readonly INotifier _notifier;
        private readonly IOrderRepository _repo;

        public List<Product> Products { get; private set; } = new();
        public List<Customer> Customers { get; private set; } = new();
        public List<Order> Orders { get; private set; } = new();

        private static int _customerCounter = 0;

        private static int _orderCounter = 0;

        public OrderService(INotifier notifier, IOrderRepository repo)
        {
            _notifier = notifier;
            _repo = repo;
        }

        public void Seed()
        {
            Products = new List<Product> {
                new Product{Sku="P1",Name="Mouse",Price=100m,WeightKg=0.2m},
                new Product{Sku="P2",Name="Teclado",Price=300m,WeightKg=0.8m},
                new Product{Sku="P3",Name="Laptop",Price=6000m,WeightKg=2.5m},
            };
        }

        public void ListProducts()
        {
            foreach (var p in Products)
                Console.WriteLine($"{p.Sku} - {p.Name} - {p.Price:C} - {p.WeightKg}kg");
        }

        public void RegisterCustomer(string name, string email, string phone)
        {
            _customerCounter++;
            var id = _customerCounter.ToString("D4"); // genera 0001, 0002, 0003...
            var c = new Customer { Id = id, Name = name, Email = email, Phone = phone };
            Customers.Add(c);
            Console.WriteLine($"Cliente registrado: {c.Name} ({c.Id})");
        }

        public void CreateOrderAndPay(string? customerId, string? sku, int qty, string? promo, string? payment, string? shipping)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(customerId) || string.IsNullOrWhiteSpace(sku) || qty <= 0)
                {
                    Console.WriteLine("Datos inválidos.");
                    return;
                }

                var c = Customers.FirstOrDefault(x => x.Id == customerId);
                var p = Products.FirstOrDefault(x => x.Sku == sku);
                if (c == null || p == null)
                {
                    Console.WriteLine("Cliente/Producto no encontrado.");
                    return;
                }

                var order = new Order
                {
                    Id = $"ORD-{++_orderCounter:D4}",
                    CustomerId = c.Id,
                    PaymentType = payment ?? "cash",
                    ShippingType = shipping ?? "standard"
                };
                order.Lines.Add(new OrderLine { Sku = p.Sku, Qty = qty, UnitPrice = p.Price, WeightKg = p.WeightKg });

                order.Subtotal = order.Lines.Sum(l => l.UnitPrice * l.Qty);
                order.Subtotal = PromotionFactory.Create(promo).Apply(order.Subtotal);

                var shipService = ShippingFactory.Create(shipping);
                var totalWeight = order.Lines.Sum(l => l.WeightKg * l.Qty);
                order.Shipping = shipService.CostFor(totalWeight, order.Subtotal);

                var paymentService = PaymentFactory.Create(payment);
                bool paid = paymentService.Charge(order.Subtotal + order.Shipping);
                if (!paid)
                {
                    Console.WriteLine("Pago rechazado.");
                    return;
                }

                shipService.Ship("Zona 10, Ciudad", totalWeight);

                order.Total = order.Subtotal + order.Shipping;
                order.Paid = true;

                Orders.Add(order);
                _repo.Save(order);

                _notifier.SendEmail(c.Email, "Pedido confirmado", $"Total: {order.Total:C}");
                Console.WriteLine($"Pedido {order.Id} creado y pagado. Total: {order.Total:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[WARN] Algo falló pero ignoramos: " + ex.Message);
            }
        }

        public void ListOrders()
        {
            foreach (var o in Orders)
                Console.WriteLine($"{o.Id} - C:{o.CustomerId} Sub:{o.Subtotal:C} Ship:{o.Shipping:C} Total:{o.Total:C} Paid:{o.Paid}");
        }
    }

}
