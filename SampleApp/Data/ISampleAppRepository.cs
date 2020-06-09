﻿using DutchTreat.Data.Entities;
using System.Collections.Generic;

namespace SampleApp.Data
{
    public interface ISampleAppRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsbyCategory(string category);
        bool SaveAll();
        IEnumerable<Order> GetAllOrders();
    }
}