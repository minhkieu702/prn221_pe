using Repository.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models;

public partial class OilPaintingArt
{
    [Required]
    public int OilPaintingArtId { get; set; }
    [Required]
    [ArtTitleValidation]
    public string ArtTitle { get; set; } = null!;
    [Required]
    public string? OilPaintingArtLocation { get; set; }
    [Required]
    public string? OilPaintingArtStyle { get; set; }
    [Required]
    public string? Artist { get; set; }
    [Required]
    public string? NotablFeatures { get; set; }
    [Required]
    public decimal? PriceOfOilPaintingArt { get; set; }
    [Required]
    [Range(1, 50)]
    public int? StoreQuantity { get; set; }
    [Required]
    public DateTime? CreatedDate { get; set; }
    [Required]
    public string? SupplierId { get; set; }
    public virtual SupplierCompany? Supplier { get; set; }
}
