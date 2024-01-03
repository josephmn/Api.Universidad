using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Model
{
    public class Result<T>
    {
        public string? Descripcion { get; set; }
        public List<T>? Resultado { get; set; }
        public bool ExisteError { get; set; }
        public List<string>? Errores { get; set; }
    }
}
