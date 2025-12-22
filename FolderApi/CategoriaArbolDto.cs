using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Semestral___DSIV_GS.FolderApi
{
    public class CategoriaArbolDto
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("nombre")] public string Nombre { get; set; } = "";
        [JsonPropertyName("hijos")] public List<CategoriaArbolDto> Hijos { get; set; } = new List<CategoriaArbolDto>();
    }
}
