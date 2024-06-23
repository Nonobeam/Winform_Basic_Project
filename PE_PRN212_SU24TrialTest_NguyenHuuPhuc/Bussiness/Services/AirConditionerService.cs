using DAO;
using DAO.DTO;
using DAO.Entities;

namespace Bussiness.Services
{
    public class AirConditionerService
    {
        private AirConditionerDAO airConditionerDAO;
        private SupplierCompanyDAO supplierCompanyDAO;

        public AirConditionerService()
        {
            airConditionerDAO = AirConditionerDAO.Instance;
            supplierCompanyDAO = SupplierCompanyDAO.Instance;
        }

        public List<AirConditioner> GetAllAirConditioners()
        {
            return airConditionerDAO.GetAllAirConditioners();
        }

        public List<AirConditionerDTO> GetAllAirConditionersDTO()
        {
            List<AirConditionerDTO> airConditionersDTO = new List<AirConditionerDTO>();
            List<AirConditioner> airConditioners = airConditionerDAO.GetAllAirConditioners();

            foreach (AirConditioner airConditioner in airConditioners)
            {
                airConditionersDTO.Add(new AirConditionerDTO(
                        airConditioner.AirConditionerId,
                        airConditioner.AirConditionerName,
                        airConditioner.Warranty,
                        airConditioner.SoundPressureLevel,
                        airConditioner.FeatureFunction,
                        airConditioner.Quantity,
                        airConditioner.DollarPrice,
                        supplierCompanyDAO.GetSupplierCompanyById(airConditioner.SupplierId).SupplierName
                    ));
            }

            return airConditionersDTO;
        }

        public void AddAirConditioner(AirConditioner airConditioner)
        {
            airConditionerDAO.AddAirConditioner(airConditioner);
        }

        public void UpdateAirConditioner(AirConditioner airConditioner)
        {
            airConditionerDAO.UpdateAirConditioner(airConditioner);
        }

        public void DeleteAirConditioner(int id)
        {
            airConditionerDAO.DeleteAirConditioner(id);
        }

        public AirConditioner GetAirConditionerById(int id)
        {
            return airConditionerDAO.GetAirConditionerById(id);
        }
    }
}
