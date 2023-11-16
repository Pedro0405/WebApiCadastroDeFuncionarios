using WebApiCadatroDeFuncionarios.Models;

namespace WebApiCadatroDeFuncionarios.Services.Funciomarios
{
    public interface IfuncionarioServices
    {
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncioario();
        Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncioario(FuncionarioModel novofuncionario);
        Task<ServiceResponse<FuncionarioModel>> GetFuncionarioByID(int id);
        Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncioario(FuncionarioModel funcionario);
        Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncioarioById(int id);
        Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id);
    }
}
