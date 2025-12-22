using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Semestral___DSIV_GS.FolderApi
{
    public  class LoginResponse
    {
        [JsonPropertyName("usuario")] public LoginUsuario Usuario { get; set; }
        [JsonPropertyName("cliente")] public LoginCliente Cliente { get; set; } // null si es admin
    }
}
