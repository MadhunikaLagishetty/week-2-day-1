using DataAccessLayer.Models;
using Domain_Layer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AmazonRepository : IAmazonRepository
    {

        public async Task<List<AmazonOrders>> GetAllAmazonCountries()
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var amazonorders = await dbContext.Orders.ToListAsync();


                List<AmazonOrders> domainModels = new List<AmazonOrders>();

                foreach (var cm in amazonorders)
                {
                    domainModels.Add(new AmazonOrders
                    {

                        Id = cm.Id,
                        UserName = cm.UserName,


                    });
                }

                return domainModels;
            }
        }


        public async Task<AmazonOrders> GetAmazonCountryById(int Id)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {

                var amazonorders = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == Id);
                AmazonOrders domainModel = new AmazonOrders
                {

                    Id = amazonorders.Id,
                    UserName = amazonorders.UserName,

                };

                return domainModel;
            };
        }

        public async Task InsertAmazonCountry(AmazonOrders amazonOrders)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var dbModel = new Order
                {

                    Id = amazonOrders.Id,
                    UserName = amazonOrders.UserName,


                };

                dbContext.Orders.Add(dbModel);
                await dbContext.SaveChangesAsync();
            };
        }

        public async Task UpdateAmazonCountry(AmazonOrders amazonOrders)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == amazonOrders.Id);

                findOrder.Id = amazonOrders.Id;
                findOrder.UserName = amazonOrders.UserName;


                dbContext.Orders.Update(findOrder);
                await dbContext.SaveChangesAsync();
            };
        }



        public async Task DeleteAmazonCountryById(int Id)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == Id);
                dbContext.Orders.Remove(findOrder);
                await dbContext.SaveChangesAsync();
            };
        }

        public async Task<List<AmazonOrders>> GetAllOrders()
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var orders = await dbContext.Orders.ToListAsync();


                List<AmazonOrders> domainModels = new List<AmazonOrders>();

                foreach (var ord in orders)
                {
                    domainModels.Add(new AmazonOrders
                    {

                        Id = ord.Id,
                        UserName = ord.UserName,
                        Cost = (int)ord.Cost,
                        ItemQty = ord.ItemQty,
                        CreatedDate = ord.CreatedDate,
                        UpdatedDate = ord.UpdatedDate,
                        AmazonID = ord.AmazonId,
                    });
                }

                return domainModels;
            };
        }
        public async Task InsertOrder(AmazonOrders amazonOrders)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var dbModel = new Order
                {
                    UserName = amazonOrders.UserName,
                    Cost = amazonOrders.Cost,
                    ItemQty = amazonOrders.ItemQty,
                    CreatedDate = amazonOrders.CreatedDate,
                    UpdatedDate = amazonOrders.UpdatedDate,
                    AmazonId = amazonOrders.AmazonId
                };

                dbContext.Orders.Add(dbModel);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateOrder(AmazonOrders amazonOrders)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == amazonOrders.Id);

                findOrder.UserName = amazonOrders.UserName;
                findOrder.Cost = amazonOrders.Cost;
                findOrder.ItemQty = amazonOrders.ItemQty;

                dbContext.Orders.Update(findOrder);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderById(int Id)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == Id);
                dbContext.Orders.Remove(findOrder);
                await dbContext.SaveChangesAsync();
            };
        }

        public async Task<AmazonOrders> GetOrderById(int id)
        {
            // return TempData.Data.Find(x => x.Id == id);
            // return TempData.Data.FirstOrDefault(x => x.Id == id);

            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var amazonOrders = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

                AmazonOrders domainModel = new AmazonOrders
                {
                    AmazonId = (int)amazonOrders.AmazonId,
                    UserName = amazonOrders.UserName,
                    Cost = (int)amazonOrders.Cost,
                    ItemQty = amazonOrders.ItemQty,
                    CreatedDate = amazonOrders.CreatedDate,
                    UpdatedDate = amazonOrders.UpdatedDate,

                };

                return domainModel;
            }
        }

        public async Task<List<AmazonOrders>> GetAllOrdersByCountryName(string name)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {

                var amazonOrders = await dbContext.Orders.Include(x => x.Amazon).Where(x => x.Amazon.Name == name).ToListAsync();


                List<AmazonOrders> domainModels = new List<AmazonOrders>();

                foreach (var ord in amazonOrders)
                {
                    domainModels.Add(new AmazonOrders
                    {
                        Id = ord.Id,
                        UserName = ord.UserName,
                        Cost = (int)ord.Cost,
                        ItemQty = ord.ItemQty,
                        CreatedDate = ord.CreatedDate,
                        UpdatedDate = ord.UpdatedDate,
                        AmazonId = (int)ord.AmazonId


                    });

                }

                return domainModels;


            }
        }


        public async Task<List<AmazonOrders>> SumofOrdersCostByCountryName(string name)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {

                var amazonOrders = await dbContext.Orders.Include(x => x.Amazon).Where(x => x.Amazon.Name == name).ToListAsync();

                List<AmazonOrders> domainModels = new List<AmazonOrders>();

                foreach (var cm in amazonOrders)
                {
                    domainModels.Add(new AmazonOrders
                    {

                        Id = cm.Id,
                        UserName = cm.UserName,
                        ItemQty = cm.ItemQty,
                        Cost = (int)cm.Cost,

                    });

                }

                return domainModels;

            }
        }

        
    }
}
        

       
    


