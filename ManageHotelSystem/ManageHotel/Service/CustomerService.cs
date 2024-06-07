using NguyenHuuPhucWPF.Model;
using NguyenHuuPhucWPF.Repository;

namespace ManageHotel.Service
{
    public class CustomerService(CustomerRepository customerRepo)
    {
        private readonly CustomerRepository _customerRepo = customerRepo;

        public IEnumerable<Customer> GetAllCucstomers()
        {
            IEnumerable<Customer> customers = _customerRepo.GetAllCustomers();
            return customers;
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepo.AddCustomer(customer);
        }

        public Customer GetCustomerByID(int id)
        {
            return _customerRepo.GetCustomerById(id);
        }

        public void DeleteCustmerByID(int id)
        {
            _customerRepo.DeleteCustomer(id);
        }

        public void UpdateCustomer(Customer customer) 
        {
            _customerRepo.UpdateCustomer(customer);
        }

    }
}
