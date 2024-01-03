using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Universidad.Model.DTO
{
    public class mCarreraDTO
    {
        [JsonPropertyName("facultad")]
        public int facultad { get; set; }
        [JsonPropertyName("nombre_carrera")]
        public string? nombre_carrera { get; set; }
        [JsonPropertyName("codigo_carrera")]
        public string? codigo_carrera { get; set; }
        [JsonPropertyName("estado_carrera")]
        public int estado_carrera { get; set; }

        public mCarreraDTO()
        {
            estado_carrera = 1;  // Asignación de valor por defecto (por ejemplo, 1 para "Activo")
            facultad = 0;
        }
    }
}
