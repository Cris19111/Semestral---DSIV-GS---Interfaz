using System.Text.Json.Serialization;

namespace Semestral___DSIV_GS.FolderApi
{


    public sealed class LoginUsuario
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("user")] public string User { get; set; } = "";
        [JsonPropertyName("rol")] public string Rol { get; set; } = "";
    }

    public sealed class LoginCliente
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("nombre")] public string Nombre { get; set; } = "";
        [JsonPropertyName("apellido")] public string Apellido { get; set; } = "";
        [JsonPropertyName("direccion")] public string Direccion { get; set; } = "";
        [JsonPropertyName("telefono")] public string Telefono { get; set; } = "";
        [JsonPropertyName("correo")] public string Correo { get; set; } = "";
    }
}

