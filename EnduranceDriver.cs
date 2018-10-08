using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRID
{
    public class EnduranceDriver : Driver
    {
        private const double EnduranceDriverFuelConsumptionPerKm = 1.5;
        private const double EnduranceDriverSpeedBoost = 1;

        public EnduranceDriver(string name, Car car) : base(name, car, EnduranceDriverFuelConsumptionPerKm, EnduranceDriverSpeedBoost)
        {
        }
    }
}
