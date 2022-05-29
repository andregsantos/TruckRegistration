using System.Linq;
using TruckRegistration.Data.Entity;

namespace TruckRegistration.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Trucks.Count() > 0)
                return;

            var trucks = new Truck[]
            {
                new Truck { Year = 2000,  YearOfModel =2000,   Model = "FH"
                },
                new Truck {Year = 2000, YearOfModel = 2001,  Model = "FH"
                },
                new Truck {Year = 2000, YearOfModel =2000,  Model = "FM"
                }
            };

            foreach (Truck c in trucks)
            {
                context.Trucks.Add(c);
            }

            context.SaveChanges();
        }
    }
}
