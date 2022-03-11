
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiRest.Domain
{
    [Table("ArduinoAction")]
    public class ArduinoAction
    {
        [Key]
        [JsonIgnore]
        public int IdAction { get; set; }

        [Required(ErrorMessage = "The Field NameAction is Mandatory")]
        public string NameAction { get; set; }

        [Required(ErrorMessage = "The Field TypeAction is Mandatory")]
        public int TypeAction { get; set; }

        [JsonIgnore]
        public DateTime InsertedDate { get; set; }

        [JsonIgnore]
        public DateTime ExecutionDate { get; set; }

        [Required(ErrorMessage = "The Field ArduinoId is Mandatory")]
        [ForeignKey("Arduino")]
        public int ArduinoId { get; set; }
    }
}
