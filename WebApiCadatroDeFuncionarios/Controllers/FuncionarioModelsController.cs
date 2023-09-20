using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCadatroDeFuncionarios.Data;
using WebApiCadatroDeFuncionarios.Models;
using WebApiCadatroDeFuncionarios.Services.Funciomarios;

namespace WebApiCadatroDeFuncionarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioModelsController : ControllerBase
    {
        private readonly Contexto _context;
        private readonly IfuncionarioServices _ifuncionarioServices;
        public FuncionarioModelsController(Contexto context, IfuncionarioServices ifuncionarioServices)
        {
            _context = context;
            _ifuncionarioServices = ifuncionarioServices;
        }

        // GET: api/FuncionarioModels
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> Getfuncionarios()
        {
            return Ok(await _ifuncionarioServices.GetFuncioario());

        }

        // GET: api/FuncionarioModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> GetFuncionarioModel(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = await _ifuncionarioServices.GetFuncionarioByID(id);
            return Ok(serviceResponse);
        }

        // PUT: api/FuncionarioModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutFuncionarioModel(FuncionarioModel funcionarioModel)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _ifuncionarioServices.UpdateFuncioario(funcionarioModel);
            return Ok(serviceResponse);
        }

        // POST: api/FuncionarioModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateFuncioario(FuncionarioModel funcionarioModel)
        {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = await _ifuncionarioServices.CreateFuncioario(funcionarioModel);
            return Ok(serviceResponse);    
        }

        // DELETE: api/FuncionarioModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionarioModel(int id)
        {

            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _ifuncionarioServices.DeleteFuncioarioById(id);
            return Ok(serviceResponse);
        }
    }
}
