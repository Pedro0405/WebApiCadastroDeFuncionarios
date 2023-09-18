using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCadatroDeFuncionarios.Data;
using WebApiCadatroDeFuncionarios.Models;

namespace WebApiCadatroDeFuncionarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioModelsController : ControllerBase
    {
        private readonly Contexto _context;

        public FuncionarioModelsController(Contexto context)
        {
            _context = context;
        }

        // GET: api/FuncionarioModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioModel>>> Getfuncionarios()
        {
          if (_context.funcionarios == null)
          {
              return NotFound();
          }
            return await _context.funcionarios.ToListAsync();
        }

        // GET: api/FuncionarioModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FuncionarioModel>> GetFuncionarioModel(int id)
        {
          if (_context.funcionarios == null)
          {
              return NotFound();
          }
            var funcionarioModel = await _context.funcionarios.FindAsync(id);

            if (funcionarioModel == null)
            {
                return NotFound();
            }

            return funcionarioModel;
        }

        // PUT: api/FuncionarioModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionarioModel(int id, FuncionarioModel funcionarioModel)
        {
            if (id != funcionarioModel.id)
            {
                return BadRequest();
            }

            _context.Entry(funcionarioModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioModelExists(id))
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

        // POST: api/FuncionarioModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FuncionarioModel>> PostFuncionarioModel(FuncionarioModel funcionarioModel)
        {
          if (_context.funcionarios == null)
          {
              return Problem("Entity set 'Contexto.funcionarios'  is null.");
          }
            _context.funcionarios.Add(funcionarioModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuncionarioModel", new { id = funcionarioModel.id }, funcionarioModel);
        }

        // DELETE: api/FuncionarioModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionarioModel(int id)
        {
            if (_context.funcionarios == null)
            {
                return NotFound();
            }
            var funcionarioModel = await _context.funcionarios.FindAsync(id);
            if (funcionarioModel == null)
            {
                return NotFound();
            }

            _context.funcionarios.Remove(funcionarioModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuncionarioModelExists(int id)
        {
            return (_context.funcionarios?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
