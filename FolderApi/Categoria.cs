using System.Text.Json.Serialization;

namespace Semestral___DSIV_GS.FolderApi
{
    public class Categoria
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = "";

        [JsonPropertyName("categoriaPadreId")]
        public int? CategoriaPadreId { get; set; }  

        [JsonPropertyName("cantidadProductos")]
        public int CantidadProductos { get; set; }
    }
}