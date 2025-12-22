using System;
using System.Text.Json.Serialization;

namespace Semestral___DSIV_GS.FolderApi
{
    public class OrdenDto
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("estado")] public string Estado { get; set; } = "";
        [JsonPropertyName("fecha")] public DateTime Fecha { get; set; }
        [JsonPropertyName("usuario_Id")] public int Usuario_Id { get; set; }

        [JsonPropertyName("created_At")] public DateTime Created_At { get; set; }
        [JsonPropertyName("updated_At")] public DateTime Updated_At { get; set; }

        [JsonPropertyName("cupon_Id")] public int? Cupon_Id { get; set; }

        [JsonPropertyName("subtotal")] public decimal Subtotal { get; set; }
        [JsonPropertyName("total")] public decimal Total { get; set; }
        [JsonPropertyName("descuento")] public decimal Descuento { get; set; }
        [JsonPropertyName("itbms")] public decimal Itbms { get; set; }
    }
}