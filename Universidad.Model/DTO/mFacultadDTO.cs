using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Universidad.Model.DTO
{
    public class mFacultadDTO
    {
        [JsonPropertyName("nombre")]
        public string? nombre_facultad { get; set; }
        [JsonPropertyName("codigo")]
        public string? codigo_facultad { get; set; }
        [JsonPropertyName("estado")]
        public int estado_facultad { get; set; }

        public mFacultadDTO()
        {
            estado_facultad = 1;  // Asignación de valor por defecto (por ejemplo, 1 para "Activo")
        }
    }
}
