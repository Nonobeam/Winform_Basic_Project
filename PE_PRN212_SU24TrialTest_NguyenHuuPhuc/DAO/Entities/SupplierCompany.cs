using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAO.Entities;

public partial class SupplierCompany
{
    public SupplierCompany() { }

    public SupplierCompany(string supplierId, string supplierName, string? supplierDescription, string? placeOfOrigin, ICollection<AirConditioner> airConditioners)
    {
        SupplierId = supplierId;
        SupplierName = supplierName;
        SupplierDescription = supplierDescription;
        PlaceOfOrigin = placeOfOrigin;
        AirConditioners = airConditioners;
    }

    [Key]
    public string SupplierId { get; set; } = null!;

    [Required]
    [StringLength(80)]
    public string SupplierName { get; set; } = null!;

    [StringLength(250)]
    public string? SupplierDescription { get; set; }

    [StringLength(60)]
    public string? PlaceOfOrigin { get; set; }

    public virtual ICollection<AirConditioner> AirConditioners { get; set; } = new List<AirConditioner>();
}
