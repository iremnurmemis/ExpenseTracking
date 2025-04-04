using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApı.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Expense expense)
        {
            var result = _expenseService.Add(expense);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] Expense expense)
        {
            var result = _expenseService.Update(expense);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _expenseService.Delete(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _expenseService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _expenseService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getuserexpenses/{userId}")]
        public IActionResult GetUserExpenses(int userId)
        {
            var result = _expenseService.GetUserExpenses(userId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getexpensesbycategory/{categoryId}")]
        public IActionResult GetExpensesByCategory(int categoryId)
        {
            var result = _expenseService.GetExpensesByCategory(categoryId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getexpensesbyuserandcategory/{userId}/{categoryId}")]
        public IActionResult GetExpensesByUserAndCategory(int userId, int categoryId)
        {
            var result = _expenseService.GetExpensesByUserAndCategory(userId, categoryId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("total/{userId}")]
        public IActionResult GetTotalExpense(int userId)
        {
            var result = _expenseService.GetTotalExpense(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
