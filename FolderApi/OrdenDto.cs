// ============================================================================
// File: /FolderApi/OrdenDto.cs
// ============================================================================
using System;
using System.Text.Json.Serialization;

namespace Semestral___DSIV_GS.FolderApi
{
    public class OrdenDto
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("estado")] public string Estado { get; set; } = "";
        [JsonPropertyName("fecha")] public DateTime Fecha { get; set; }
        [JsonPropertyName("usuario_id")] public int? UsuarioId { get; set; }
        [JsonPropertyName("cuponId")] public int? CuponId { get; set; }

        [JsonPropertyName("total")] public decimal Total { get; set; }




    }
}
