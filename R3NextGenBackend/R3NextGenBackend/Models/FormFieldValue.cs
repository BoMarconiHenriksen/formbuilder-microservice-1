using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendNextGen.Models
{
    public class FormFieldValue
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [StringLength(25, ErrorMessage = "Value cannot be longer than 25 characters.")]
        public string Value { get; set; }

        [ForeignKey("FormField")]
        public long FormFieldId { get; set; }
        public FormField FormField { get; set; }

        [ForeignKey("CompletedForm")]
        public long CompletedFormId { get; set; }
        public CompletedForm CompletedForm { get; set; }
    }
}
