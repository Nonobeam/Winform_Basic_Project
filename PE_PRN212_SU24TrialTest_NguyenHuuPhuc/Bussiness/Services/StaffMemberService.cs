using DAO.Entities;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services
{
    public class StaffMemberService
    {
        private StaffMemberDAO staffMemberDAO;

        public StaffMemberService()
        {
            staffMemberDAO = StaffMemberDAO.Instance;
        }

        /*---------------------CRUD FUNCTION---------------------*/

        public List<StaffMember> GetAirConditions()
        {
            return staffMemberDAO.GetAllStaffMembers();
        }

        public void AddAirConditioner(StaffMember airConditioner)
        {
            staffMemberDAO.AddStaffMember(airConditioner);
        }

        public void UpdateAirConditioner(StaffMember airConditioner)
        {
            staffMemberDAO.UpdateStaffMember(airConditioner);
        }

        public void DeleteAirConditioner(int id)
        {
            staffMemberDAO.DeleteStaffMember(id);
        }


        /*---------------------LOGIN FUNCTION---------------------*/

        public StaffMember Authenticate(string email, string password)
        {
            return staffMemberDAO.Authenticate(email, password);
        }
    }
}
