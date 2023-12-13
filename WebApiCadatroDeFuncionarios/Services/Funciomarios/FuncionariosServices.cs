using Microsoft.EntityFrameworkCore;
using WebApiCadatroDeFuncionarios.Data;
using WebApiCadatroDeFuncionarios.Models;

namespace WebApiCadatroDeFuncionarios.Services.Funciomarios
{
    public class FuncionariosServices : IfuncionarioServices
    {
        private readonly Contexto _contexto;

        public FuncionariosServices(Contexto contexto)
        {
            _contexto= contexto;
        }
        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncioario(FuncionarioModel novofuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                if (novofuncionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.menssagem = "Insira os dados";
                    serviceResponse.sucesso = false;
                    return serviceResponse;
                }
                _contexto.funcionarios.Add(novofuncionario);
                await _contexto.SaveChangesAsync();

                serviceResponse.Dados = _contexto.funcionarios.ToList();
            }
            catch(Exception ex)
            { 
                serviceResponse.menssagem = ex.Message;
                serviceResponse.sucesso = false;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncioarioById(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                FuncionarioModel funcionario = _contexto.funcionarios.FirstOrDefault(x => x.id == id);
                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.menssagem = "Funcionario não localizado";
                    serviceResponse.sucesso = false;

                }
                _contexto.funcionarios.Remove(funcionario);
                await _contexto.SaveChangesAsync();
                serviceResponse.Dados = _contexto.funcionarios.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.menssagem += ex.Message;
                serviceResponse.sucesso = false;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncioario()
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                serviceResponse.Dados = _contexto.funcionarios.ToList();
                if(serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.menssagem = "Nenhum dado no banco de dados";
                }
            }
            catch(Exception ex)
            {
                serviceResponse.menssagem=ex.Message;
                serviceResponse.sucesso=false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioByID(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();
            try
            {
                FuncionarioModel funcionario = _contexto.funcionarios.FirstOrDefault(x => x.id == id);
                if(funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.menssagem = "Funcionario não localizado";
                    serviceResponse.sucesso=false;

                }
                serviceResponse.Dados = funcionario;
            }catch(Exception ex)
            { 
                serviceResponse.menssagem+=ex.Message;
                serviceResponse.sucesso=false;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncioario(FuncionarioModel funcionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                FuncionarioModel funcionarioModel = _contexto.funcionarios.AsNoTracking().FirstOrDefault(x => x.id == funcionario.id);
                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.menssagem = "Insira os dados";
                    serviceResponse.sucesso = false;
                    return serviceResponse;
                }
                funcionarioModel.UltimaAtualização = DateTime.Now.ToLocalTime();
                _contexto.funcionarios.Update(funcionario);
                await _contexto.SaveChangesAsync();

                serviceResponse.Dados = _contexto.funcionarios.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.menssagem = ex.Message;
                serviceResponse.sucesso = false;

            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _contexto.funcionarios.FirstOrDefault(x => x.id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.menssagem = "Usuário não localizado!";
                    serviceResponse.sucesso = false;
                    return serviceResponse;
                }

                funcionario.ativo = false;
                funcionario.UltimaAtualização = DateTime.Now.ToLocalTime();

                // Resto do código...


                _contexto.funcionarios.Update(funcionario);
                await _contexto.SaveChangesAsync();

                serviceResponse.Dados = _contexto.funcionarios.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.menssagem = ex.Message;
                serviceResponse.sucesso = false;
            }

            return serviceResponse;
        }


    }
}

