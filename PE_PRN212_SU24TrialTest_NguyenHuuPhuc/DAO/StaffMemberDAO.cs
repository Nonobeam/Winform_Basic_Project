using DAO.Entities;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class StaffMemberDAO
    {
        private static StaffMemberDAO instance;
        private static readonly object instaneLock = new object();
        private AirConditionerShop2024DbContext context;

        /*---------------------SINGLETON---------------------*/
        private StaffMemberDAO()
        {
            context = AirConditionerShop2024DbContext.Instance;
        }

        public static StaffMemberDAO Instance
        {
            get
            {
                lock(instaneLock)
                {
                    if (instance == null)
                    {
                        instance = new StaffMemberDAO();
                    }
                }
                return instance;
            }
        }


        /*---------------------CRUD FUNCTION---------------------*/


        public List<StaffMember> GetAllStaffMembers()
        {
            return context.StaffMembers.ToList();
        }

        public void AddStaffMember(StaffMember staffMember)
        {
            context.StaffMembers.Add(staffMember);
            context.SaveChanges();
        }

        public void UpdateStaffMember(StaffMember staffMember)
        {
            context.StaffMembers.Update(staffMember);
            context.SaveChanges();
        }

        public void DeleteStaffMember(int id)
        {
            var sm = context.StaffMembers.Find(id);
            if (sm != null)
            {
                context.StaffMembers.Remove(sm);
                context.SaveChanges();
            }
        }


        /*---------------------LOGIN FUNCTION---------------------*/

        public StaffMember Authenticate(string email, string password)
        {
            return context.StaffMembers.SingleOrDefault(sm => sm.EmailAddress == email && sm.Password == password);
        }
    }
}
