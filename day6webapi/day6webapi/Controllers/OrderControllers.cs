using Business_Layer;
using Domain_Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace day6webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderBusiness _orderBusiness;

        public OrderController(ILogger<OrderController> logger, IOrderBusiness orderBusiness)
        {
            _logger = logger;
            _orderBusiness = orderBusiness;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", Type = typeof(IEnumerable<AmazonOrders>))]
        [Route("get-all")]
        public async Task<ActionResult<IEnumerable<AmazonOrders>>> GetAllOrders()
        {
            try
            {
                var resp = await _orderBusiness.GetAllOrders();

                if (resp == null || resp.Count == 0)
                {
                    return StatusCode(404, "No Data available.");
                }
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", Type = typeof(AmazonOrders))]
        [Route("get-order")]
        public async Task<ActionResult<AmazonOrders>> GetOrderById(int Id)
        {
            try
            {
                var resp = await _orderBusiness.GetOrderById(Id);

                if (resp == null)
                {
                    return StatusCode(404, "No Data available.");
                }
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("insert-order")]
        public async Task<ActionResult> InsertOrder([FromBody] AmazonOrders amazonOrders)
        {
            try
            {
                await _orderBusiness.InsertOrder(amazonOrders);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("update-order")]
        public async Task<ActionResult> UpdateOrder([FromBody] AmazonOrders amazonOrders)
        {
            try
            {
                await _orderBusiness.UpdateOrder(amazonOrders);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("delete-order")]
        public async Task<ActionResult> DeleteOrderById(int Id)
        {
            try
            {
                await _orderBusiness.DeleteOrderById(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", Type = typeof(IEnumerable<AmazonOrders>))]
        [Route("get-all-orders-by-country-name")]
        public async Task<ActionResult<List<AmazonOrders>>> GetAllOrdersByCountryName(string name)
        {
            try
            {




                var resp = await _orderBusiness.GetAllOrdersByCountryName(name);




                if (resp == null || resp.Count == 0)
                {
                    return StatusCode(404, "No Data available.");
                }
                return Ok(resp);


            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", Type = typeof(IEnumerable<AmazonOrders>))]
        [Route("get-sum-of-orders-cost-by-country-name")]
        public async Task<ActionResult<int>> SumOfOrdersCostByCountryName(string name)
        {
            try
            {

                var resp = await _orderBusiness.SumofOrdersCostByCountryName(name);

                return Ok(resp);


            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }


}

    



