namespace WebApiCadatroDeFuncionarios.Models
{
    public class ServiceResponse<T>
    {
        public T? Dados { get; set; }
        public string menssagem { get; set; } = string.Empty;
        public bool sucesso { get; set; } = true;
    }
}
