using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRID
{
    public abstract class Driver
    {
        private string name;
        private double totalTime;
        private string failureReason;
        private Car car;
        private double fuelConsumptionPerKm;
        private double speed;

        protected Driver(string name, Car car, double fuelConsumptionPerKm, double speedBoost)
        {
            this.Name = name;
            this.Car = car;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.Speed = ((this.Car.Hp + this.Car.Tyre.Degradation)/this.Car.FuelAmount) * speedBoost;
        }

        public string Name { get => name; private set => name = value; }
        public double TotalTime { get => totalTime; set => totalTime = value; }
        public Car Car { get => car; private set => car = value; }
        public double FuelConsumptionPerKm { get => fuelConsumptionPerKm; private set => fuelConsumptionPerKm = value; }
        public double Speed { get => speed; private set => speed = value; }
        public string FailureReason { get => failureReason; set => failureReason = value; }

        public void DriveCar(int trackLenght)
        {
            try
            {
                this.Car.FuelAmount -= trackLenght * this.FuelConsumptionPerKm;
            }
            catch (Exception e)
            {
                this.FailureReason = e.Message;
            }
        }

        public void Degradate()
        {
            if (this.Car.Tyre.Name == "Hard")
            {
                this.Car.Tyre.Degradation -= this.Car.Tyre.Hardness;
                if (this.Car.Tyre.Degradation <= 0)
                {
                    this.FailureReason = "Blown Tyre";
                }
            }
            else if (this.Car.Tyre.Name == "Ultrasoft")
            {
                this.Car.Tyre.Degradation -= this.Car.Tyre.Hardness + this.Car.Tyre.Grip;
                if (this.Car.Tyre.Degradation <= 0)
                {
                    this.FailureReason = "Blown Tyre";
                }
            }
        }
    }
}
