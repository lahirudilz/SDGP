using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using susFaceGen.Models;

namespace susFaceGen.Areas.Identity.Data;

// Add profile data for application users by adding properties to the susFaceGenUser class
public class susFaceGenUser : IdentityUser
{
    [MaxLength(50), Required, PersonalData]
    public string FName { get; set; }
    [MaxLength(50), Required, PersonalData]
    public string LName { get; set; }
    [MaxLength(20), Required]
    public string JobId { get; set; }
    [MaxLength(50), Required]
    public string JobPosition { get; set; }

    public bool IsEnabled { get; set; }

    IEnumerable<Case> Cases { get; set; }
}

