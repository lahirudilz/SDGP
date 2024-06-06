using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace susFaceGen.Models
{
    public class Statement
    {
        public int Id { get; set; }
        public string? StatementRefNo { get; set; }
        public string? ColorOfHair { get; set; }
        public string? TypeOfHead { get; set; }
        public string? ColorTypeOfEyes { get; set; }
        public string? ShapeOfEyes { get; set; }
        public string? Nose { get; set; }
        public string? Mouth { get; set; }
        public string? Teeth { get; set; }
        public string? Face { get; set; }
        public string? Ears { get; set; }
        public string? Forhead { get; set; }
        public string? Chin { get; set; }
        public string? HairOnHead { get; set; }
        public string? FacialHair { get; set; }
        public string? Complexion { get; set; }
        public string? EyeBrows { get; set; }
        public string? Gender { get; set; }
        public int? Age { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        [Required]
        [Display(Name = "Eyewitness's Name")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Invalid Name")]
        public string? EyewitnessName { get; set; }
        [Required]
        [Display(Name = "Eyewitness's NIC")]
        [RegularExpression(@"^(\d{9}V|\d{12})$", ErrorMessage = "Invalid NIC")]
        public string? EyewitnessNIC { get; set; }
        public string? AdditionalDetails { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public int? _caseId { get; set; }
        public Case? Case { get; set; }


        [NotMapped]
        public IEnumerable<SelectListItem> ColorsOfHair { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Black", Text = "Black" },
            new SelectListItem { Value = "Brown", Text = "Brown" },
            new SelectListItem { Value = "Tinted", Text = "Tinted" },
            new SelectListItem { Value = "Gray", Text = "Gray" },
            new SelectListItem { Value = "White", Text = "White" },
        };

        [NotMapped]
        public IEnumerable<SelectListItem> TypesOfHead { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Round", Text = "Round"},
            new SelectListItem { Value = "Oval", Text = "Oval"},
            new SelectListItem { Value = "Square", Text = "Square"},
            new SelectListItem { Value = "Narrow", Text = "Narrow"},
        };

        [NotMapped]
        public IEnumerable<SelectListItem> ColorTypesOfEyes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Black", Text = "Black" },
            new SelectListItem { Value = "Brown", Text = "Brown" },
            new SelectListItem { Value = "Blue", Text = "Blue" },
            new SelectListItem { Value = "Green", Text = "Green" },
            new SelectListItem { Value = "Gray", Text = "Gray" },
        };

        [NotMapped]
        public IEnumerable<SelectListItem> ShapesOfEyes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Long Lashes", Text = "Long Lashes" },
            new SelectListItem { Value = "Sunken", Text = "Sunken" },
            new SelectListItem { Value = "Sleepy", Text = "Sleepy" },
            new SelectListItem { Value = "Small", Text = "Small" },
            new SelectListItem { Value = "Big", Text = "Big" },
            new SelectListItem { Value = "Squitited", Text = "Squitited" },
        };

        [NotMapped]
        public IEnumerable<SelectListItem> Noses { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Long", Text = "Long" },
            new SelectListItem { Value = "Short", Text = "Short" },
            new SelectListItem { Value = "Large", Text = "Large" },
            new SelectListItem { Value = "Thin", Text = "Thin" },
            new SelectListItem { Value = "Pointed", Text = "Pointed" },
            new SelectListItem { Value = "Flat", Text = "Flat" },
        };

        [NotMapped]
        public IEnumerable<SelectListItem> Mouths { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Wide", Text = "Wide" },
            new SelectListItem { Value = "Small", Text = "Small" },
            new SelectListItem { Value = "Thin Lipped", Text = "Thin Lipped" },
            new SelectListItem { Value = "Thick Lipped", Text = "Thick Lipped" },
            new SelectListItem { Value = "Upper Lip Pro", Text = "Upper Lip Pro" },
            new SelectListItem { Value = "Lower Lip Pro", Text = "Lower Lip Pro" },
            new SelectListItem { Value = "Spotted", Text = "Spotted" },
        };

        [NotMapped]
        public IEnumerable<SelectListItem> Teeths { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Clean", Text = "Clean" },
            new SelectListItem { Value = "Discolored", Text = "Discolored" },
            new SelectListItem { Value = "Decayed", Text = "Decayed" },
            new SelectListItem { Value = "Over lap", Text = "Over lap" },
            new SelectListItem { Value = "Gold Teeth", Text = "Gold Teeth" },
            new SelectListItem { Value = "Well Arranged", Text = "Well Arranged" },
        };

        [NotMapped]
        public IEnumerable<SelectListItem> Faces { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Round", Text = "Round" },
            new SelectListItem { Value = "Oval", Text = "Oval" },
            new SelectListItem { Value = "Long", Text = "Long" },
            new SelectListItem { Value = "Wrinkled", Text = "Wrinkled" },
            new SelectListItem { Value = "Flabby", Text = "Flabby" },
            new SelectListItem { Value = "Fat", Text = "Fat" },
            new SelectListItem { Value = "Thin", Text = "Thin" },
            new SelectListItem { Value = "High Cheek Bones", Text = "High Cheek Bones" },
        };

        [NotMapped]
        public IEnumerable<SelectListItem> Earses { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Large", Text = "Large" },
            new SelectListItem { Value = "Small", Text = "Small" },
            new SelectListItem { Value = "Protruding", Text = "Protruding" },
            new SelectListItem { Value = "Flat", Text = "Flat" },
            new SelectListItem { Value = "Attached", Text = "Attached" },
            new SelectListItem { Value = "Lobe less", Text = "Lobe less" },
            new SelectListItem { Value = "Pierced", Text = "Pierced" },
            new SelectListItem { Value = "Large Lobes", Text = "Large Lobes" },
            new SelectListItem { Value = "Hairy", Text = "Hairy" },
        };

        [NotMapped]
        public IEnumerable<SelectListItem> Forheads { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Broad", Text = "Broad" },
            new SelectListItem { Value = "Narrow", Text = "Narrow" },
            new SelectListItem { Value = "High", Text = "High" },
            new SelectListItem { Value = "Low", Text = "Low" },
            new SelectListItem { Value = "Receding", Text = "Receding" },
            new SelectListItem { Value = "Wrinkled", Text = "Wrinkled" },
            //////////////////////////////////////////////////////////////////////////////////////////
        };

        [NotMapped]
        public IEnumerable<SelectListItem> Chins { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Double", Text = "Double" },
            new SelectListItem { Value = "Protrudes", Text = "Protrudes" },
            new SelectListItem { Value = "Pointed", Text = "Pointed" },
            new SelectListItem { Value = "Round", Text = "Round" },
            new SelectListItem { Value = "Square Jaw", Text = "Square Jaw" },
            new SelectListItem { Value = "Cleft", Text = "Cleft" },
        };

        [NotMapped]
        public IEnumerable<SelectListItem> HairOnHeads { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Short", Text = "Short" },
            new SelectListItem { Value = "Medium", Text = "Medium" },
            new SelectListItem { Value = "Long", Text = "Long" },
            new SelectListItem { Value = "Curly", Text = "Curly" },
            new SelectListItem { Value = "Straight", Text = "Straight" },
            new SelectListItem { Value = "Wavy", Text = "Wavy" },
            new SelectListItem { Value = "Bald", Text = "Bald" },
            new SelectListItem { Value = "Brushed ", Text = "Brushed Back" },
            new SelectListItem { Value = "Parted", Text = "Parted" },
        };

        [NotMapped]
        public IEnumerable<SelectListItem> FacialHairs { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Beard", Text = "Beard" },
            new SelectListItem { Value = "Moustache", Text = "Moustache" },
            new SelectListItem { Value = "Goatee", Text = "Goatee" },
            new SelectListItem { Value = "Sideburns", Text = "Sideburns" },
            new SelectListItem { Value = "Clean Shaven", Text = "Clean Shaven" },
        };

        [NotMapped]
        public IEnumerable<SelectListItem> Complexions { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Fair", Text = "Fair" },
            new SelectListItem { Value = "Dark", Text = "Dark" },
            new SelectListItem { Value = "Medium", Text = "Medium" },
        };

        [NotMapped]
        public IEnumerable<SelectListItem> EyeBrowses { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Thick", Text = "Thick" },
            new SelectListItem { Value = "Thin", Text = "Thin" },
            new SelectListItem { Value = "Arched", Text = "Arched" },
            new SelectListItem { Value = "Meets in Centre", Text = "Meets" },
            new SelectListItem { Value = "Bushy", Text = "Bushy" },
            new SelectListItem { Value = "Sparse", Text = "Sparse" },
        };
    }
}
