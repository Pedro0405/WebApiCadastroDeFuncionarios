using System.ComponentModel.DataAnnotations;
using WebApiCadatroDeFuncionarios.Enums;

namespace WebApiCadatroDeFuncionarios.Models
{
    public class FuncionarioModel
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set;}
        public DepartamentoEnum departamento { get; set;}
        public TurnoEnum turno { get; set;}
        public bool ativo { get; set;}
        public DateTime DataCriacao { get; set;} = DateTime.Now.ToLocalTime();
        public DateTime UltimaAtualização { get; set;} = DateTime.Now.ToLocalTime();
    }
}
