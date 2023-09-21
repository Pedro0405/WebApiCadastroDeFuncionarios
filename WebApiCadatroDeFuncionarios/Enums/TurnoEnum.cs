using System.Text.Json.Serialization;

namespace WebApiCadatroDeFuncionarios.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TurnoEnum
    {
        manha,
        intermediario,
        tarde,
        noturno,
    }
}
