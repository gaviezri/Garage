using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal abstract class Fillable
    {
        internal abstract bool AmountInRange(float amount);
    }
}
