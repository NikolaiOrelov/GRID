using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRID
{
    public class AggressiveDriver : Driver
    {
        private const double AggressiveDriverFuelConsumptionPerKm = 2.7;
        private const double AggressiveDriverSpeedBoost = 1.3;
        
        public AggressiveDriver(string name, Car car) : base(name, car, AggressiveDriverFuelConsumptionPerKm, AggressiveDriverSpeedBoost) { }
    }
}
