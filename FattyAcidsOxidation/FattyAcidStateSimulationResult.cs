using System;
using System.Collections.Generic;
using System.Text;

namespace FattyAcidsOxidation
{
    public class FattyAcidStateSimulationResult
    {
        public Dictionary<int, List<FattyAcidState>> Results { get; set; }
        public List<FattyAcidState> Averaged { get; set; }
    }
}
