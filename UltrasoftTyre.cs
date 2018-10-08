using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRID
{
    public class UltrasoftTyre : Tyre
    {
        private const string UltrasoftName = "Ultrasoft";

        public UltrasoftTyre(double hardness, double grip) : base(UltrasoftName, hardness, grip) { }
    }
}
