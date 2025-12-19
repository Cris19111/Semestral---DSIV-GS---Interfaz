using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestral___DSIV_GS.FolderApi
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? CategoriaPadreId { get; set; }
    }
}
