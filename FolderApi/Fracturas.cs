using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
namespace Semestral___DSIV_GS.FolderApi
{

public class Fracturas
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("usuarioId")]
        public int UsuarioId { get; set; }

        [JsonPropertyName("fecha")]
        public DateTime Fecha { get; set; }

        [JsonPropertyName("total")]
        public decimal Total { get; set; }

        [JsonPropertyName("itbms")]
        public decimal Itbms { get; set; }

        [JsonPropertyName("subtotal")]
        public decimal Subtotal { get; set; }

        [JsonPropertyName("descuento")]
        public decimal? Descuento { get; set; }

        [JsonPropertyName("cuponId")]
        public int? CuponId { get; set; }
    }
}

