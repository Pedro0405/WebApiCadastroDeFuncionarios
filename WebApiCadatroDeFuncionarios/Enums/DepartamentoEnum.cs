using System.Text.Json.Serialization;

namespace WebApiCadatroDeFuncionarios.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartamentoEnum
    {
        Rh,
        Financeiro,
        Compras,
        Zeladoria,
        Atendimento,
        Caixa,
        Gerencia,
        Escritorio,


    }
}
