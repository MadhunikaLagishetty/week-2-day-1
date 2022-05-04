using DataAccessLayer;
using Domain_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class OrderBusiness : IOrderBusiness
    {

        private readonly IAmazonRepository _amazonRepository;

        public OrderBusiness(IAmazonRepository amazonRepository)
        {
            _amazonRepository = amazonRepository;
        }
        public async Task DeleteAmazonCountryById(int Id)
        {
            await _amazonRepository.DeleteAmazonCountryById(Id);
        }

        public async Task DeleteOrderById(int Id)
        {
            await _amazonRepository.DeleteOrderById(Id);
        }

        public async Task<List<AmazonOrders>> GetAllAmazonCountries()
        {
            return await _amazonRepository.GetAllAmazonCountries();
        }

        public async Task<List<AmazonOrders>> GetAllOrders()
        {
            return await _amazonRepository.GetAllOrders();
        }

        public async Task<List<AmazonOrders>> GetAllOrdersByCountryName(string name)
        {
            return await _amazonRepository.GetAllOrdersByCountryName(name);
        }

        public async Task<AmazonOrders> GetAmazonCountryById(int Id)
        {
            return await _amazonRepository.GetAmazonCountryById(Id);
        }

        public async Task<AmazonOrders> GetOrderById(int Id)
        {
            return await _amazonRepository.GetOrderById(Id);
        }

        public async Task InsertAmazonCountry(AmazonOrders amazonOrders)
        {
            await _amazonRepository.InsertAmazonCountry(amazonOrders);
        }

        public async Task InsertOrder(AmazonOrders amazonOrders)
        {
            await _amazonRepository.InsertOrder(amazonOrders);
        }

        public async Task<SumofCountries> SumofOrdersCostByCountryName(string name)
        {
            var Orders = await _amazonRepository.SumofOrdersCostByCountryName(name);

            var TotalCostofCountry = Orders.Sum(x => x.Cost);

            SumofCountries oc = new SumofCountries();

            oc.TotalCostofCountry = TotalCostofCountry;
            return oc;
        }

        public async Task UpdateAmazonCountry(AmazonOrders amazonOrders)
        {
            await _amazonRepository.UpdateAmazonCountry(amazonOrders);
        }

        public async Task UpdateOrder(AmazonOrders amazonOrders)
        {
            await _amazonRepository.UpdateOrder(amazonOrders);
        }

       

        
    }
}
