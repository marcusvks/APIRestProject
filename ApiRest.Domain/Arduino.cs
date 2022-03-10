
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Domain
{
    [Table("Arduino")]
    public class Arduino
    {
        [Key]
        public int ArduinoId { get; set; }

        [Required(ErrorMessage = "The Field ArduinoName is Mandatory")]
        public string ArduinoName { get; set; }

        public DateTime LastActivity { get; set; }
    }
}
