using DAO.Entities;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services
{
    public class SupplierCompanyService
    {
        private SupplierCompanyDAO supplierCompanyDAO;

        public SupplierCompanyService()
        {
            supplierCompanyDAO = SupplierCompanyDAO.Instance;
        }

        public List<SupplierCompany> GetAllSupplierCompanies()
        {
            return supplierCompanyDAO.GetAllSupplierCompanies();
        }

        public SupplierCompany GetSupplierCompanyById(string id)
        {
            return supplierCompanyDAO.GetSupplierCompanyById(id);
        }

        public void AddSupplierCompany(SupplierCompany supplier)
        {
            supplierCompanyDAO.AddSupplierCompany(supplier);
        }

        public void UpdateSupplierCompany(SupplierCompany supplier)
        {
            supplierCompanyDAO.UpdateSupplierCompany(supplier);
        }

        public void DeleteSupplierCompany(string id)
        {
            supplierCompanyDAO.DeleteSupplierCompany(id);
        }
    }
}
