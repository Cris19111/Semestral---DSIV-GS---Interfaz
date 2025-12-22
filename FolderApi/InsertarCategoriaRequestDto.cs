using System.Text.Json.Serialization;

namespace Semestral___DSIV_GS.FolderApi
{

    public class InsertarCategoriaRequestDto
    {
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = "";


        [JsonPropertyName("categoriaPadreId")]
        public int CategoriaPadreId { get; set; }
    }
}