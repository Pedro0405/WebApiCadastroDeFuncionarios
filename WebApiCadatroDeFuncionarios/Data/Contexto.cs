using Microsoft.EntityFrameworkCore;
using WebApiCadatroDeFuncionarios.Models;

namespace WebApiCadatroDeFuncionarios.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        // Adicione DbSet para cada entidade do seu banco de dados aqui
        public DbSet<FuncionarioModel> funcionarios { get; set; }

    }
}
