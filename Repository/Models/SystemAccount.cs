using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models;

public partial class SystemAccount
{
    public int AccountId { get; set; }
    [Required]
    public string AccountPassword { get; set; } = null!;
    
    public string AccountFullName { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string? AccountEmail { get; set; }

    public int? Role { get; set; }
}
