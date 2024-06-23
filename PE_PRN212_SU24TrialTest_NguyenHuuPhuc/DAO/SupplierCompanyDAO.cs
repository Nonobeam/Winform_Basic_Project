using DAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SupplierCompanyDAO
    {
        private static SupplierCompanyDAO instance;
        private static readonly object instanceLock = new object();
        private AirConditionerShop2024DbContext context;

        private SupplierCompanyDAO()
        {
            context = AirConditionerShop2024DbContext.Instance;
        }

        public static SupplierCompanyDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SupplierCompanyDAO();
                    }
                }
                return instance;
            }
        }

        public List<SupplierCompany> GetAllSupplierCompanies()
        {
            return context.SupplierCompanies.ToList();
        }

        public SupplierCompany GetSupplierCompanyById(string id)
        {
            return context.SupplierCompanies.Find(id);
        }

        public void AddSupplierCompany(SupplierCompany supplier)
        {
            context.SupplierCompanies.Add(supplier);
            context.SaveChanges();
        }

        public void UpdateSupplierCompany(SupplierCompany supplier)
        {
            context.SupplierCompanies.Update(supplier);
            context.SaveChanges();
        }

        public void DeleteSupplierCompany(string id)
        {
            var supplier = context.SupplierCompanies.Find(id);
            if (supplier != null)
            {
                context.SupplierCompanies.Remove(supplier);
                context.SaveChanges();
            }
        }

        public string FindNameById(string id)
        {
            string name = context.SupplierCompanies.Find(id).SupplierName;
            return name;
        }
    }
}
