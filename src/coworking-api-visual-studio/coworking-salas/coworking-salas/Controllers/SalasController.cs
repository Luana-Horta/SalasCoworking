using coworking_salas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

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
        public async Task<ActionResult> GetAll()
        {
            List<Sala> model = await _context.Salas.ToListAsync();

            return Ok(model);
        }
        // Cria uma sala no banco de dados
        
        [HttpPost]
        public async Task<ActionResult> Create(Sala model)
        {
            if (model.CriadoEm <= 0 || model.Capacidade <= 0)

            {
                return BadRequest(new { message = "Criado Em e Capacidade são obrigatórios e devem ser maiores que zero" });
            }


            _context.Salas.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetByID", new {id = model.Id}, model);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByID(int id)
        {
            var model = await _context.Salas
                .FirstOrDefaultAsync(c => c.Id == id);
            if (model == null) return NotFound();
            return Ok(model);

        }
        // atualizar os dados da sala

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Sala model)
        {
            //se o id for diferente dá um bad request
            if (id != model.Id) return BadRequest();

            // ver se o modelo existe na base de dados e o asnotracking tira a tag de alteração de dados
            var modeloDb = await _context.Salas.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            //se for null retorna not found
            if (modeloDb == null) return NotFound();

            //se a sala existir vai atualizar os dados
            _context.Salas.Update(model);
            await _context.SaveChangesAsync();

            //não precisa retornar conteúdo porque você só quer atualizar a informação
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            // mesma função do FirstOrDefaultAsyn ele vai recuperar as funções da chave primária do ido que foi passado como parâmetro
            var model = await _context.Salas.FindAsync(id);

            if (model == null) return NotFound();
            //se ele não retornou not found o conteúdo existe então entõ faz:
            _context.Salas.Remove(model);
            //depois manda atualizar e salvar as alterações
            await _context.SaveChangesAsync();

            return NoContent();

        }


    }
    
}
