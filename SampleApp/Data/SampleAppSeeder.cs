using DutchTreat.Data.Entities;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SampleApp.Data
{
    public class SampleAppSeeder
    {
        private readonly SampleAppContext _ctx;
        private readonly IHostEnvironment _hosting;

        public SampleAppSeeder(SampleAppContext ctx, IHostEnvironment hosting)
        {
            _ctx = ctx;
            this._hosting = hosting;
        }
        public void Seed()
        {
            _ctx.Database.EnsureCreated();
            if (!_ctx.Products.Any())
            {
                //need to seed
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                _ctx.Products.AddRange(products);

                var order = _ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if (order != null)
                {
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product=products.First(),
                            Quantity=5,
                            UnitPrice=products.First().Price
                }
            };
                }
                _ctx.SaveChanges();

            }
        }
    }
}
