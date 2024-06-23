using DAO.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAO{
    public class AirConditionerDAO
    {
        private static AirConditionerDAO instance;
        private static readonly object instanceLock = new object();
        private AirConditionerShop2024DbContext context;

        private AirConditionerDAO() 
        {
            context = AirConditionerShop2024DbContext.Instance;
        }

        public static AirConditionerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AirConditionerDAO();
                    }
                }
                return instance;
            }
        }

        public List<AirConditioner> GetAllAirConditioners()
        {
            return context.AirConditioners.ToList();
        }

        public void AddAirConditioner(AirConditioner airConditioner)
        {
            context.AirConditioners.Add(airConditioner);
            context.SaveChanges();
        }

        public void UpdateAirConditioner(AirConditioner airConditions)
        {
            var existingEntity = context.AirConditioners.Local.FirstOrDefault(ac => ac.AirConditionerId == airConditions.AirConditionerId);
            if (existingEntity != null)
            {
                context.Entry(existingEntity).State = EntityState.Detached;
            }
            context.AirConditioners.Update(airConditions);
            context.SaveChanges();
        }

        public void DeleteAirConditioner(int id)
        {
            var airConditioner = context.AirConditioners.Find(id);
            if (airConditioner != null)
            {
                context.AirConditioners.Remove(airConditioner);
                context.SaveChanges();
            }
        }

        public AirConditioner GetAirConditionerById(int id)
        {
            return context.AirConditioners.FirstOrDefault(ac => ac.AirConditionerId == id);
        }
    }
}
