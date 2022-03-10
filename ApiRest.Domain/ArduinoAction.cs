
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ApiRest.Domain
{
    [Table("ArduinoAction")]
    public class ArduinoAction
    {
        [Key]
        public int IdAction { get; set; }

        [Required(ErrorMessage = "The Field NameAction is Mandatory")]
        public string NameAction { get; set; }

        [Required(ErrorMessage = "The Field TypeAction is Mandatory")]
        public int TypeAction { get; set; }

        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }

        [Required(ErrorMessage = "The Field ArduinoId is Mandatory")]
        [ForeignKey("Arduino")]
        public int ArduinoId { get; set; }
    }
}
