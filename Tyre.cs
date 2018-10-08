using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRID
{
    public abstract class Tyre
    {
        private string name;
        private double hardness;
        private double grip;
        private double degradation = 100;

        public string Name { get => name; private set => name = value; }
        public double Hardness { get => hardness; private set => hardness = value; }
        public double Degradation { get => degradation; set => degradation = value; }
        public double Grip { get => grip; private set => grip = value; }

        protected Tyre(string name, double hardness, double grip)
        {
            this.Name = name;
            this.Hardness = hardness;
            this.Grip = grip;
        }
    }
}
