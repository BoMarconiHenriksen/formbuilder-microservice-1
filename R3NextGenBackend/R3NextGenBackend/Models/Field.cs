﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendNextGen.Models
{
    public class Field
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [StringLength(25, ErrorMessage = "Component cannot be longer than 25 characters.")]
        public string Component { get; set; }

        [ForeignKey("FormField")]
        public long FormFieldId { get; set; }
        public FormField FormField { get; set; }
    }
}
