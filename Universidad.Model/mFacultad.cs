using System.Text.Json.Serialization;

namespace Universidad.Model
{
    public class mFacultad
    {
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("nombre")]
        public string? nombre_facultad { get; set; }
        [JsonPropertyName("codigo")]
        public string? codigo_facultad { get; set; }
        [JsonPropertyName("estado")]
        public int estado_facultad { get; set; }
        [JsonPropertyName("creado")]
        public DateTime? creado_tmstp { get; set; }
        [JsonPropertyName("actualizado")]
        public DateTime? actualizado_tmstp { get; set; }
        [JsonPropertyName("lista_carreras")]
        public List<mCarrera>? lista_carreras { get; set; }

        public mFacultad()
        {
            estado_facultad = 1;  // Asignación de valor por defecto (por ejemplo, 1 para "Activo")
        }
    }
}
