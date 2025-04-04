using Business;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenuesController : ControllerBase
    {
        private readonly IRevenueService _revenueService;

        public RevenuesController(IRevenueService revenueService)
        {
            _revenueService = revenueService;
        }

        [HttpGet("total/{userId}")]
        public IActionResult GetTotalRevenue(int userId)
        {
            var result = _revenueService.GetTotalRevenue(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        
        [HttpGet("user/{userId}")]
        public IActionResult GetUserRevenues(int userId)
        {
            var result = _revenueService.GetUserRevenues(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _revenueService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    
        [HttpPost]
        public IActionResult Add([FromBody] Revenue revenue)
        {
            var result = _revenueService.Add(revenue);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

       
        [HttpPut]
        public IActionResult Update([FromBody] Revenue revenue)
        {
            var result = _revenueService.Update(revenue);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _revenueService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

     
        [HttpGet("date-range")]
        public IActionResult GetRevenuesByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var result = _revenueService.GetRevenuesByDateRange(startDate, endDate);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        
        [HttpGet("category/{categoryId}")]
        public IActionResult GetRevenuesByCategory(int categoryId)
        {
            var result = _revenueService.GetRevenuesByCategory(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

  
        [HttpGet("user/{userId}/category/{categoryId}")]
        public IActionResult GetRevenuesByUserAndCategory(int userId, int categoryId)
        {
            var result = _revenueService.GetRevenuesByUserAndCategory(userId, categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
