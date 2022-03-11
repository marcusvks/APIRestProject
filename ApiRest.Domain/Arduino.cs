
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiRest.Domain
{
    [Table("Arduino")]
    public class Arduino
    {
        [Key]
        [JsonIgnore]
        public int ArduinoId { get; set; }

        [Required(ErrorMessage = "The Field ArduinoName is Mandatory")]
        public string ArduinoName { get; set; }

        [JsonIgnore]
        public DateTime LastActivity { get; set; }
    }
}
