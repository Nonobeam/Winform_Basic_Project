using DAO.Entities;
using System.ComponentModel.DataAnnotations;

namespace DAO.DTO
{
    public partial class AirConditionerDTO
    {
        private SupplierCompanyDAO supplierCompanyDAO;

        public int AirConditionerId { get; set; }
        public string AirConditionerName { get; set; } = null!;
        public string? Warranty { get; set; }
        public string? SoundPressureLevel { get; set; }
        public string? FeatureFunction { get; set; }
        public int? Quantity { get; set; }
        public double? DollarPrice { get; set; }
        public string? SupplierName { get; set; }

        public AirConditionerDTO(int airConditionerId,
            string airConditionerName, 
            string? warranty, 
            string? soundPressureLevel,
            string? featureFunction,
            int? quantity,
            double? dollarPrice,
            string? supplierName
            )
        {
            AirConditionerId = airConditionerId;
            AirConditionerName = airConditionerName;
            Warranty = warranty;
            SoundPressureLevel = soundPressureLevel;
            FeatureFunction = featureFunction;
            Quantity = quantity;
            DollarPrice = dollarPrice;
            SupplierName = supplierName;
        }
    }
}
