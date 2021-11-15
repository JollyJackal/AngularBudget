////using AngularBudget.Data;
//using AngularBudget.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
////using Microsoft.EntityFrameworkCore;
////using System.Security.Claims;

//namespace AngularBudget.Controllers
//{
//    [Authorize]
//    [ApiController]
//    [Route("[controller]")]
//    public class UserBudgetsController : ControllerBase
//    {
//        //    private static readonly string[] Summaries = new[]
//        //    {
//        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//        //};

//        //private readonly ILogger<UserBudgetsController> _logger;
//        //private readonly ApplicationDbContext _context;

//        //public UserBudgetsController(ApplicationDbContext context)
//        //{
//        //    _context = context;
//        //}
//        public UserBudgetsController()
//        {
//        }

//        [HttpGet]
//        public UserBudget Get()
//        {
//            //var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
//            //var id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
//            //var id = User.Identity?.GetUserId();
//            //var userBudget = await _context.UserBudget.FindAsync(id);
//            //UserBudget? userBudget = null;

//            ////userBudget = _context.UserBudget.SingleOrDefault(x => x.ApplicationUserId == id);
//            //if (userBudget == null)
//            //{
//            //    userBudget = new UserBudget
//            //    {
//            //        FrequencyAmount = 69
//            //    };
//            //}

//            var userBudget = new UserBudget
//            {
//                FrequencyAmount = 69
//            };

//            return userBudget;

//            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//            //{
//            //    Date = DateTime.Now.AddDays(index),
//            //    TemperatureC = Random.Shared.Next(-20, 55),
//            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//            //})
//            //.ToArray();
//        }
//    }
//}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularBudget.Data;
using AngularBudget.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using AngularBudget.DTO;

namespace AngularBudget.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserBudgetsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserBudgetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //// GET: api/UserBudgets
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<UserBudget>>> GetUserBudget()
        //{
        //    return await _context.UserBudget.ToListAsync();
        //}

        // GET: api/UserBudgets/5
        //[HttpGet("{userId}")]
        //public async Task<ActionResult<UserBudget>> GetUserBudget(Guid userId) //Fetching by user ID. Only 1 budget per user
        //{
        //    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    //var id = User.Identity?.GetUserId();
        //    //var userBudget = await _context.UserBudget.FindAsync(id);
        //    UserBudget? userBudget = null;
        //    try
        //    {
        //        userBudget = await _context.UserBudget.SingleOrDefaultAsync(x => x.ApplicationUserId == id);
        //    }
        //    catch (InvalidOperationException)

        //    {
        //        if (!UserBudgetExistsByUserId(userId))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    if (userBudget == null)
        //    {
        //        return NotFound();
        //    }

        //    return userBudget;
        //}

        //// GET: api/UserBudgets
        [HttpGet]
        public async Task<ActionResult<UserBudgetDTO>> GetUserBudget() //Fetching by user ID. Only 1 budget per user
        {
            //var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            //var id = User.Identity?.GetUserId();
            //var userBudget = await _context.UserBudget.FindAsync(id);
            UserBudget? userBudget = null;
            UserBudgetDTO? userBudgetDTO = null;
            try
            {
                userBudget = await _context.UserBudget.SingleOrDefaultAsync(x => x.ApplicationUserId == userId);
                if (userBudget != null)
                    userBudgetDTO = new UserBudgetDTO { FrequencyAmount = userBudget.FrequencyAmount, FrequencyId = userBudget.FrequencyId };
            }
            catch (InvalidOperationException)

            {
                if (!UserBudgetExistsByUserId(userId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            if (userBudgetDTO == null)
            {
                //return NotFound();
                return NoContent();
            }

            return userBudgetDTO;
        }

        // PUT: api/UserBudgets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserBudget(Guid id, UserBudget userBudget)
        {
            if (id != userBudget.UserBudgetId)
            {
                return BadRequest();
            }

            _context.Entry(userBudget).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserBudgetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserBudgets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserBudget>> PostUserBudget([FromBody] UserBudgetDTO userBudget)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var newBudget = new UserBudget { UserBudgetId = Guid.NewGuid(), ApplicationUserId = userId, FrequencyId = userBudget.FrequencyId, FrequencyAmount = userBudget.FrequencyAmount };
            Console.WriteLine(newBudget.ToString());
            _context.UserBudget.Add(newBudget);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserBudget", new { id = newBudget.UserBudgetId }, 
                new UserBudgetDTO { UserBudgetId = newBudget.UserBudgetId, FrequencyId = newBudget.FrequencyId, FrequencyAmount = newBudget.FrequencyAmount});
        }

        // DELETE: api/UserBudgets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserBudget(Guid id)
        {
            var userBudget = await _context.UserBudget.FindAsync(id);
            if (userBudget == null)
            {
                return NotFound();
            }

            _context.UserBudget.Remove(userBudget);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserBudgetExists(Guid id)
        {
            return _context.UserBudget.Any(e => e.UserBudgetId == id);
        }

        private bool UserBudgetExistsByUserId(Guid userId)
        {
            return _context.UserBudget.Any(e => e.ApplicationUserId == userId);
        }
    }
}
