using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendNextGen.Models
{
    public class CompletedForm
    {
        public CompletedForm()
        {
            // FormFieldValues = new HashSet<FormFieldValue>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "userId is required.")]
        public long UserId { get; set; }

        [Display(Name = "Completed Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CompletedDate { get; set; }

        [ForeignKey("Form")]
        public long FormId { get; set; }
        public Form Form { get; set; }

        // public ICollection<FormFieldValue> FormFieldValues { get; set; }
    }
}
