using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Universidad.Model.DTO
{
    public class mCarreraMoverDTO
    {
        [JsonPropertyName("facultad")]
        public int facultad { get; set; }
    }
}
