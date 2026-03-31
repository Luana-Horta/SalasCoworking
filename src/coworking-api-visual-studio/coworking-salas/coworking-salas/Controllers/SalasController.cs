using coworking_salas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace coworking_salas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SalasController(AppDbContext context)
        {
            _context = context;

        }
           [HttpGet]
            public async Task<ActionResult> GetAll ()
        {
            List<Sala> model = await _context.Salas.ToListAsync();

            return Ok(model);
        }
    }
}
