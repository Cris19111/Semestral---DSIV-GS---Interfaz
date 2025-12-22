using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Semestral___DSIV_GS.FolderApi
{
    public class ArticulosResponse
    {
        [JsonPropertyName("articulos")]
        public List<Producto> articulos { get; set; }
    }
}