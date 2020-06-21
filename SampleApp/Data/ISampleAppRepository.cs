using DutchTreat.Data.Entities;
using System.Collections.Generic;

namespace SampleApp.Data
{
    public interface ISampleAppRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsbyCategory(string category);
        bool SaveAll();
        IEnumerable<Order> GetAllOrders(bool includeItems);
        IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems);

        Order GetOrderById(string username, int id);
        void AddEntity(object model);
    }
}