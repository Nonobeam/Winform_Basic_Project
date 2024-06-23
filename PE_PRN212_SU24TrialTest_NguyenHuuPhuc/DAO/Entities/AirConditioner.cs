using System.ComponentModel.DataAnnotations;

namespace DAO.Entities;

public partial class AirConditioner
{
    public AirConditioner() { }

    public AirConditioner(int airConditionerId, string airConditionerName, string? warranty, string? soundPressureLevel, string? featureFunction, int? quantity, double? dollarPrice, string? supplierId, SupplierCompany supplierCompany)
    {
        AirConditionerId = airConditionerId;
        AirConditionerName = airConditionerName;
        Warranty = warranty;
        SoundPressureLevel = soundPressureLevel;
        FeatureFunction = featureFunction;
        Quantity = quantity;
        DollarPrice = dollarPrice;
        SupplierId = supplierId;
        Supplier = supplierCompany;
    }

    [Key]
    public int AirConditionerId { get; set; }

    [Required]
    [StringLength(200)]
    public string AirConditionerName { get; set; } = null!;

    [StringLength(60)]
    public string? Warranty { get; set; }

    [StringLength(80)]
    public string? SoundPressureLevel { get; set; }

    [StringLength(250)]
    public string? FeatureFunction { get; set; }

    public int? Quantity { get; set; }

    public double? DollarPrice { get; set; }

    [StringLength(20)]
    public string? SupplierId { get; set; }

    public virtual SupplierCompany? Supplier { get; set; }
}
