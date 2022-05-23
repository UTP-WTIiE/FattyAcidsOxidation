using System;
using System.Collections.Generic;
using System.Text;

namespace FattyAcidsOxidation
{
    public interface IComputer
    {
        void SetCurrentState(FattyAcidState state);
        FattyAcidState ComputeQueues();
        double[] GetRates();
        string[] GetRatesNames();
    }
}
