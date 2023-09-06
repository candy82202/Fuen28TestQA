using Fuen28TestQuestion.Models.DTOs;
using Fuen28TestQuestion.Models.EFModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fuen28TestQuestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    { private readonly TestContext _context;
        public MembersController(TestContext context)
        {
            _context =context;
    }
        [HttpGet("GetAllMembers")]
        public async Task<ActionResult<List<MembersDTO>>> GetMembers()
        {
            var members = await _context.Members
             .Select(m => m.ToQDto())
             .ToListAsync();

            if (members == null || members.Count == 0)
            {
                return NotFound();
            }

            return members;
        }
    }
}
