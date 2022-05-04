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
   
    public class AmazonControllers : ControllerBase
    {
        private readonly ILogger<AmazonControllers> _logger;
        private readonly IOrderBusiness _orderBusiness;

        public AmazonControllers(ILogger<AmazonControllers> logger, IOrderBusiness orderBusiness)
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
        public async Task<ActionResult<IEnumerable<AmazonOrders>>> GetAll()
        {
            try
            {
                var resp = await _orderBusiness.GetAllAmazonCountries();

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
        [Route("get-amazon-country-by-id")]
        public async Task<ActionResult<IEnumerable<AmazonOrders>>> GetAmazonCountryById(int Id)
        {
            try
            {
                var resp = await _orderBusiness.GetAmazonCountryById(Id);

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
        [Route("insert-amazoncountries")]
        public async Task<ActionResult> Insertamazoncountries([FromBody] AmazonOrders amazonorders)
        {
            try
            {
                await _orderBusiness.InsertAmazonCountry(amazonorders);
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
        [Route("update-amazoncountries")]
        public async Task<ActionResult> UpdateAmazonCountry([FromBody] AmazonOrders amazonorders)
        {
            try
            {
                await _orderBusiness.UpdateAmazonCountry(amazonorders);
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
        [Route("delete-amazoncountries")]
        public async Task<ActionResult> DeleteAmazonCountry(int id)
        {
            try
            {
                await _orderBusiness.DeleteAmazonCountryById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}