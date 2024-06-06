using Microsoft.AspNetCore.Identity;
using susFaceGen.Areas.Identity.Data;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace susFaceGen.Models
{
    public class Case
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Case Reference Number")]
        public string CaseRefNum { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Location")]
        public string CaseLocation { get; set; }
        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        
        public DateOnly Date { get; set; }
        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }
        [Required]
        [Display(Name = "Investigating Officer ID")]
        public string InvestigatingOfficerId { get; set; }
        [NotMapped]
        public string? _userId { get; set; }
        public susFaceGenUser? User { get; set; }
        public IEnumerable<Statement>? StatementList { get; set; }

        public string IsDeleted { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        public DateTime? LastUpdatedDate { get; set; }
    }
}
