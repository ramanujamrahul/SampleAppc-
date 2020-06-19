using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using SampleApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SampleApp.Data
{
    public class SampleAppSeeder
    {
        private readonly SampleAppContext _ctx;
        private readonly IHostEnvironment _hosting;
        private readonly UserManager<StoreUser> _userManager;

        public SampleAppSeeder(SampleAppContext ctx, IHostEnvironment hosting, UserManager<StoreUser> userManager)
        {
            _ctx = ctx;
            this._hosting = hosting;
            this._userManager = userManager;
        }
        public async Task SeedAsync()
        {
            _ctx.Database.EnsureCreated();
            StoreUser user = await _userManager.FindByEmailAsync("testtest@test.com");
            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "Test",
                    LastName = "Test",
                    Email = "Testtest@Test.com",
                    UserName = "TestTest@Test.com"
                };
                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidCastException("Could not create seeder user");
                }
            }
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
                    order.User = user;
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
