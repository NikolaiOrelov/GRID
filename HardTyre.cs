using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRID
{
    public class HardTyre : Tyre
    {
        private const string HardTyreName = "Hard";

        public HardTyre(double hardness) : base(HardTyreName, hardness, 0.0) { }

    }
}
