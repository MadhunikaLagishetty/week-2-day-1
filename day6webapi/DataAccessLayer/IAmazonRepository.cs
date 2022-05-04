using Domain_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IAmazonRepository
    {
        public Task<List<AmazonOrders>> GetAllAmazonCountries();
        public Task<AmazonOrders> GetAmazonCountryById(int Id);
        public Task InsertAmazonCountry(AmazonOrders amazonOrders);
        public Task UpdateAmazonCountry(AmazonOrders amazonOrders);
        public Task DeleteAmazonCountryById(int Id);


        public Task<List<AmazonOrders>> GetAllOrders();
        public Task<AmazonOrders> GetOrderById(int Id);
        public Task InsertOrder(AmazonOrders amazonOrders);
        public Task UpdateOrder(AmazonOrders amazonOrders);
        public Task DeleteOrderById(int Id);

        public Task<List<AmazonOrders>> GetAllOrdersByCountryName(string name);
        public Task<List<AmazonOrders>> SumofOrdersCostByCountryName(string name);
    }
}
