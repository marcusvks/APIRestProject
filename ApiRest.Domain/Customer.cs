using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Domain
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Field Name is Mandatory")]
        [MaxLength(50, ErrorMessage = "The Maximum Length for the Field {0} is {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Field Cpf is Mandatory")]
        [MaxLength(14, ErrorMessage = "The Maximum Length for the Field {0} is {1}")]
        [MinLength(14, ErrorMessage = "The Minimum Length for the Field {0} is {1}")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "The Field Age is Mandatory")]
        public int Age { get; set; }

        public string Password {get;set;}
    }
}