using System.Text.Json.Serialization;

namespace Semestral___DSIV_GS.FolderApi
{
    public class CategoriaDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = "";

        [JsonPropertyName("categoriaPadreId")]
        public int? CategoriaPadreId { get; set; }  // <-- NUEVO: mapea el padre

        [JsonPropertyName("cantidadProductos")]
        public int CantidadProductos { get; set; }
    }
}