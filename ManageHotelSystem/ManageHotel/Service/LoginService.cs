using ManageHotel.Data;
using Microsoft.Extensions.Configuration;
using NguyenHuuPhucWPF.Model;
using NguyenHuuPhucWPF.Repository;
using System.Linq;

namespace ManageHotel.Service
{
    public class LoginService
    {
        private readonly IConfiguration _config;
        private readonly CustomerRepository _customerRepo;
        private readonly CustomerService _customerService;

        public LoginService(IConfiguration config, CustomerRepository customerRepo)
        {
            _config = config;
            _customerRepo = customerRepo;
            _customerService = new CustomerService(customerRepo);
        }

        public string GetAdminEmail()
        {
            return _config.GetSection("email").Value;
        }

        public string GetAdminPassword()
        {
            return _config.GetSection("password").Value;
        }

        public string Authenticate(string email, string password)
        {
            string role = "";

            if (email.Equals(GetAdminEmail()) && password.Equals(GetAdminPassword()))
            {
                role = "Admin";
            }
            else
            {
                IEnumerable<Customer> customers = _customerRepo.GetAllCustomers();
                var customer = customers.FirstOrDefault(c => c.EmailAddress == email && c.Password == password);
                if (customer != null)
                {
                    role = "Customer";
                }
            }

            return role;
        }

        public Customer GetCustomerByEmailAndPassword(string email, string password)
        {
            Customer customer = _customerRepo.GetCustomerByEmailAndPassword(email, password);
            return customer;
        }
    }
}
