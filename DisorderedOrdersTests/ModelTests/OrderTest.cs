using DisorderedOrdersMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisorderedOrdersTests.ModelTests
{
    public class OrderTest
    {
        [Fact]
        public void CreatedWithoutConstructor()
        {
            var customer = new Customer() { Id = 1, Email = "megan@test.com", IsPreferred = true };
            var orderItem1 = new OrderItem() { Id = 1, Quantity = 5, Item = new Product() { Id = 1, Price = 350, Name = "Hot Dog", StockQuantity = 10 } };
            var orderItem2 = new OrderItem() { Id = 2, Quantity = 1, Item = new Product() { Id = 2, Price = 575, Name = "Not a Hot Dog", StockQuantity = 2 } };
            var order = new Order() { Id = 1, Customer = customer, Items = new List<OrderItem> { orderItem1, orderItem2 } };

            Assert.IsType<Order>(order);
        }

        [Fact]
        public void CalculateTotal_ReturnsCorrectOrderTotal()
        {
            var customer = new Customer() { Id = 1, Email = "megan@test.com", IsPreferred = true };
            var orderItem1 = new OrderItem() { Id = 1, Quantity = 5, Item = new Product() { Id = 1, Price = 350, Name = "Hot Dog", StockQuantity = 10 } };
            var orderItem2 = new OrderItem() { Id = 2, Quantity = 1, Item = new Product() { Id = 2, Price = 575, Name = "Not a Hot Dog", StockQuantity = 2 } };
            var order = new Order() { Id = 1, Customer = customer, Items = new List<OrderItem> { orderItem1, orderItem2 } };

            var total = order.CalculateTotal(order);

            Assert.Equal(350 * 5 + 575 * 1, total);
        }
    }
}
