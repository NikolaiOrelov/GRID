using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRID
{
    public class Car
    {
        private int hp;
        private double fuelAmount;
        private Tyre tyre;

        public Car(int hp, double fuelAmount, Tyre tyre)
        {
            this.Hp = hp;
            this.FuelAmount = fuelAmount;
            this.Tyre = tyre;
        }

        public int Hp { get => hp; private set => hp = value; }
        public double FuelAmount
        {
            get { return fuelAmount; }
            set
            {
                if (value > 160)
                {
                    fuelAmount = 160;
                }
                else if (value < 0)
                {
                    throw new InvalidOperationException("Out of fuel");
                }
                else
                {
                    fuelAmount = value;
                }
            }
        }
        public Tyre Tyre { get => tyre; set => tyre = value; }
    }
}
