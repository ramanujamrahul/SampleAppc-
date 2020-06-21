using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace SampleApp.Data
{
    public class SampleAppRepository : ISampleAppRepository
    {
        private readonly SampleAppContext _ctx;
        private readonly ILogger<SampleAppRepository> _logger;

        public SampleAppRepository(SampleAppContext ctx, ILogger<SampleAppRepository> logger)
        {
            this._ctx = ctx;
            this._logger = logger;
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {
                return _ctx.Orders.
                    Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                    .ToList();
            }

            else
            {

                return _ctx.Orders.ToList();
            }
        }

        public IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems)
        {
            if (includeItems)
            {
                return _ctx.Orders.
                    Where(o => o.User.UserName == username).
                    Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                    .ToList();
            }

            else
            {

                return _ctx.Orders
                    .Where(o => o.User.UserName == username).
                    ToList();
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("Get all products called");
                return _ctx.Products
                    .OrderBy(p => p.Title)
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products:{ex}");
                return null;
            }
        }

        public Order GetOrderById(string username, int id)
        {
            return _ctx.Orders.
                 Include(o => o.Items)
                 .ThenInclude(i => i.Product)
                 .Where(o => o.Id == id && o.User.UserName == username)
                 .FirstOrDefault();
        }


        public IEnumerable<Product> GetProductsbyCategory(string category)
        {
            return _ctx.Products
                .Where(p => p.Category == category)
                .ToList();
        }
        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
