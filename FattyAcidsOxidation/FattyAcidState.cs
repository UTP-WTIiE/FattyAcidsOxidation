using System;
using System.Collections.Generic;
using System.Text;

namespace FattyAcidsOxidation
{
    public struct FattyAcidState
    {
        public FattyAcidState(double[] array)
        {
            C16AcylCoACYT = array[0];
            C16AcylCarCYT = array[1];
            C16AcylCarMAT = array[2];
            C16AcylCoAMAT = array[3];
            C16EnoylCoAMAT = array[4];
            C16HydroxyacylCoAMAT = array[5];
            C16KetoacylCoAMAT = array[6];
            C14AcylCoAMAT = array[7];
            C14EnoylCoAMAT = array[8];
            C14HydroxyacylCoAMAT = array[9];
            C14KetoacylCoAMAT = array[10];
            C12AcylCoAMAT = array[11];
            C12EnoylCoAMAT = array[12];
            C12HydroxyacylCoAMAT = array[13];
            C12KetoacylCoAMAT = array[14];
            C10AcylCoAMAT = array[15];
            C10EnoylCoAMAT = array[16];
            C10HydroxyacylCoAMAT = array[17];
            C10KetoacylCoAMAT = array[18];
            C8AcylCoAMAT = array[19];
            C8EnoylCoAMAT = array[20];
            C8HydroxyacylCoAMAT = array[21];
            C8KetoacylCoAMAT = array[22];
            C6AcylCoAMAT = array[23];
            C6EnoylCoAMAT = array[24];
            C6HydroxyacylCoAMAT = array[25];
            C6KetoacylCoAMAT = array[26];
            C4AcylCoAMAT = array[26];
            C4EnoylCoAMAT = array[27];
            C4HydroxyacylCoAMAT = array[28];
            C4AcetoacylCoAMAT = array[29];
            AcetylCoAMAT = array[30];

            FADHMAT = 0.46;
            NADHMAT = 16;
        }

        public static FattyAcidState LiteratureStart()
        {
            var c = new FattyAcidState();
            c.C16AcylCoACYT = 1.6;
            c.C16AcylCarCYT = 0.171;
            c.C16EnoylCoAMAT = 0;
            c.C14EnoylCoAMAT = 0;
            c.C12EnoylCoAMAT = 0;
            c.C10EnoylCoAMAT = 0;
            c.C8EnoylCoAMAT = 0;
            c.C6EnoylCoAMAT = 0;
            c.C4EnoylCoAMAT = 0;
            c.AcetylCoAMAT = 30;
            c.C16AcylCarMAT = 0;
            c.C16HydroxyacylCoAMAT = 0;
            c.C14HydroxyacylCoAMAT = 0;
            c.C12HydroxyacylCoAMAT = 0;
            c.C10HydroxyacylCoAMAT = 0;
            c.C8HydroxyacylCoAMAT = 0;
            c.C6HydroxyacylCoAMAT = 0;
            c.C4HydroxyacylCoAMAT = 0;
            c.FADHMAT = 0.46;
            c.C16AcylCoAMAT = 0;
            c.C16KetoacylCoAMAT = 0;
            c.C14AcylCoAMAT = 0;
            c.C14KetoacylCoAMAT = 0;
            c.C12AcylCoAMAT = 0;
            c.C12KetoacylCoAMAT = 0;
            c.C10AcylCoAMAT = 0;
            c.C10KetoacylCoAMAT = 0;
            c.C8AcylCoAMAT = 0;
            c.C8KetoacylCoAMAT = 0;
            c.C6AcylCoAMAT = 0;
            c.C6KetoacylCoAMAT = 0;
            c.C4AcylCoAMAT = 0;
            c.C4AcetoacylCoAMAT = 0;
            c.NADHMAT = 16;

            return c;
        }

        public double C16AcylCoACYT;
        public double C16AcylCarCYT;
        public double C16AcylCarMAT;
        public double C16AcylCoAMAT;
        public double C16EnoylCoAMAT;
        public double C16HydroxyacylCoAMAT;
        public double C16KetoacylCoAMAT;
        public double C14AcylCoAMAT;
        public double C14EnoylCoAMAT;
        public double C14HydroxyacylCoAMAT;
        public double C14KetoacylCoAMAT;
        public double C12AcylCoAMAT;
        public double C12EnoylCoAMAT;
        public double C12HydroxyacylCoAMAT;
        public double C12KetoacylCoAMAT;
        public double C10AcylCoAMAT;
        public double C10EnoylCoAMAT;
        public double C10HydroxyacylCoAMAT;
        public double C10KetoacylCoAMAT;
        public double C8AcylCoAMAT;
        public double C8EnoylCoAMAT;
        public double C8HydroxyacylCoAMAT;
        public double C8KetoacylCoAMAT;
        public double C6AcylCoAMAT;
        public double C6EnoylCoAMAT;
        public double C6HydroxyacylCoAMAT;
        public double C6KetoacylCoAMAT;
        public double C4AcylCoAMAT;
        public double C4EnoylCoAMAT;
        public double C4HydroxyacylCoAMAT;
        public double C4AcetoacylCoAMAT;
        public double AcetylCoAMAT;
        public double FADHMAT;
        public double NADHMAT;

        public double C16 { 
            get
            {
                double sum = C16AcylCarCYT + C16AcylCarMAT + C16AcylCoAMAT + C16EnoylCoAMAT + C16HydroxyacylCoAMAT + C16KetoacylCoAMAT;
                return sum;
            } 
        }

        public double C14
        {
            get
            {
                double sum = C14AcylCoAMAT + C14EnoylCoAMAT + C14HydroxyacylCoAMAT + C14KetoacylCoAMAT;
                return sum;
            }
        }

        public double C12
        {
            get
            {
                double sum = C12AcylCoAMAT + C12EnoylCoAMAT + C12HydroxyacylCoAMAT + C12KetoacylCoAMAT;
                return sum;
            }
        }

        public double C10
        {
            get
            {
                double sum = C10AcylCoAMAT + C10EnoylCoAMAT + C10HydroxyacylCoAMAT + C10KetoacylCoAMAT;
                return sum;
            }
        }

        public double C8
        {
            get
            {
                double sum = C8AcylCoAMAT + C8EnoylCoAMAT + C8HydroxyacylCoAMAT + C8KetoacylCoAMAT;
                return sum;
            }
        }

        public double C6
        {
            get
            {
                double sum = C6AcylCoAMAT + C6EnoylCoAMAT + C6HydroxyacylCoAMAT + C6KetoacylCoAMAT;
                return sum;
            }
        }

        public double C4
        {
            get
            {
                double sum = C4AcylCoAMAT + C4EnoylCoAMAT + C4HydroxyacylCoAMAT + C4AcetoacylCoAMAT;
                return sum;
            }
        }

        public static string[] GetHeader()
        {
            return new string[]
            {
                "C16AcylCoACYT rate1- FUEL",
                "C16AcylCarCYT rate1+ rate2-",
                "C16AcylCarMAT rate2+ rate3-",
                "C16AcylCoAMAT rate3+ rate4-",
                "C16EnoylCoAMAT rate4+ rate5-",
                "C16HydroxyacylCoAMAT rate5+ rate6-",
                "C16KetoacylCoAMAT rate6+ rate10-",
                "C14AcylCoAMAT rate9+ rate10+ rate11-",
                "C14EnoylCoAMAT rate11+ rate12-",
                "C14HydroxyacylCoAMAT rate12+ rate13-",
                "C14KetoacylCoAMAT rate13+ rate17-",
                "C12AcylCoAMAT rate16+ rate17+ rate18-",
                "C12EnoylCoAMAT rate18+ rate19-",
                "C12HydroxyacylCoAMAT rate19+ rate20-",
                "C12KetoacylCoAMAT rate20+ rate24-",
                "C10AcylCoAMAT rate23+ rate24+ rate25-",
                "C10EnoylCoAMAT rate25+ rate26-",
                "C10HydroxyacylCoAMAT rate26+ rate27-",
                "C10KetoacylCoAMAT rate27+ rate31-",
                "C8AcylCoAMAT rate30+ rate31+ rate32-",
                "C8EnoylCoAMAT rate32+ rate33-",
                "C8HydroxyacylCoAMAT rate33+ rate34-",
                "C8KetoacylCoAMAT rate34+ rate38-",
                "C6AcylCoAMAT rate37+ rate38+ rate39-",
                "C6EnoylCoAMAT rate39+ rate40-",
                "C6HydroxyacylCoAMAT rate40+ rate41-",
                "C6KetoacylCoAMAT rate41+ rate45-",
                "C4AcylCoAMAT rate44+ rate45+ rate46-",
                "C4EnoylCoAMAT rate46+ rate47-",
                "C4HydroxyacylCoAMAT rate47+ rate48-",
                "C4AcetoacylCoAMAT rate48+ rate49-",
                "AcetylCoAMAT *+ rate50-"
            };
        }

        public double[] GetState()
        {
            return new double[]
            {
                C16AcylCoACYT,
                C16AcylCarCYT,
                C16AcylCarMAT,
                C16AcylCoAMAT,
                C16EnoylCoAMAT,
                C16HydroxyacylCoAMAT,
                C16KetoacylCoAMAT,
                C14AcylCoAMAT,
                C14EnoylCoAMAT,
                C14HydroxyacylCoAMAT,
                C14KetoacylCoAMAT,
                C12AcylCoAMAT,
                C12EnoylCoAMAT,
                C12HydroxyacylCoAMAT,
                C12KetoacylCoAMAT,
                C10AcylCoAMAT,
                C10EnoylCoAMAT,
                C10HydroxyacylCoAMAT,
                C10KetoacylCoAMAT,
                C8AcylCoAMAT,
                C8EnoylCoAMAT,
                C8HydroxyacylCoAMAT,
                C8KetoacylCoAMAT,
                C6AcylCoAMAT,
                C6EnoylCoAMAT,
                C6HydroxyacylCoAMAT,
                C6KetoacylCoAMAT,
                C4AcylCoAMAT,
                C4EnoylCoAMAT,
                C4HydroxyacylCoAMAT,
                C4AcetoacylCoAMAT,
                AcetylCoAMAT
            };
        }
    
        public double[] GetAggregatedState()
        {
            return new double[]
            {
                C16, C14, C12, C10, C8, C6, C4
            };
        }

        public static string[] AggregatedStateHeader => new string[]
        {
            "C16", "C14", "C12", "C10", "C8", "C6", "C4"
        };
    }
}
