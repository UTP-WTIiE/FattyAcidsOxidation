using System;
using System.Collections.Generic;
using System.Text;

namespace FattyAcidsOxidation
{
    public interface IConstants
    {
        double[] GetState();
        IConstants CreateNew(double[] array);
        IConstants CreateOriginalConsts();
    }
}
