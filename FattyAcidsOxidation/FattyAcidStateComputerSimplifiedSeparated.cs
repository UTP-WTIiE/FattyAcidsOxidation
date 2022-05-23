using FattyAcidsOxidation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FattyAcidsOxidation
{
    public class FattyAcidStateComputerSimplifiedSeparated : IComputer
    {
        FattyAcidState c;
        FattyAcidConstantsSimplifiedSeparated d_original;
        FattyAcidConstantsSimplifiedSeparated d;
        Random b = new Random();
        public double noise_amplitude;


        public FattyAcidStateComputerSimplifiedSeparated(FattyAcidConstantsSimplifiedSeparated constants, double noise_amplitude)
        {
            this.d_original = constants;
            this.noise_amplitude = noise_amplitude;
        }

        public void SetCurrentState(FattyAcidState state)
        {
            this.c = state;
        }

        private void set_noised_constants()
        {
            this.d = new FattyAcidConstantsSimplifiedSeparated(this.d_original.GetState().Select(x => x * (1.0 + this.noise_amplitude * b.NextGaussian())).ToArray());
        }

        public FattyAcidState ComputeQueues()
        {
            set_noised_constants();

            double r() => b.NextDouble();

            if (r() < rate1() && c.C16AcylCoACYT >= delta)
            {
                c.C16AcylCoACYT -= delta;
                c.C16AcylCarCYT += delta;
            }
            if (r() < rate2() && c.C16AcylCarCYT >= delta)
            {
                c.C16AcylCarCYT -= 1 * delta;
                c.C16AcylCarMAT += 1 * delta;

            }
            if (r() < rate3() && c.C16AcylCarMAT >= delta)
            {
                c.C16AcylCarMAT -= 1 * delta;
                c.C16AcylCoAMAT += 1 * delta;

            }
            if (r() < rate4() && c.C16AcylCoAMAT >= delta)
            {
                c.C16AcylCoAMAT -= 1 * delta;
                c.C16EnoylCoAMAT += 1 * delta;

            }
            if (r() < rate5() && c.C16EnoylCoAMAT >= delta)
            {
                c.C16EnoylCoAMAT -= 1 * delta;
                c.C16HydroxyacylCoAMAT += 1 * delta;

            }
            if (r() < rate6() && c.C16HydroxyacylCoAMAT >= delta)
            {
                c.C16HydroxyacylCoAMAT -= 1 * delta;
                c.C16KetoacylCoAMAT += 1 * delta;

            }
            
            if (r() < rate7() && c.C16KetoacylCoAMAT >= delta)
            {
                c.C16KetoacylCoAMAT -= 1 * delta;
                c.C14AcylCoAMAT += 1 * delta;
                c.AcetylCoAMAT += 1 * delta;

            }
            if (r() < rate8() && c.C14AcylCoAMAT >= delta)
            {
                c.C14AcylCoAMAT -= 1 * delta;
                c.C14EnoylCoAMAT += 1 * delta;

            }
            if (r() < rate9() && c.C14EnoylCoAMAT >= delta)
            {
                c.C14EnoylCoAMAT -= 1 * delta;
                c.C14HydroxyacylCoAMAT += 1 * delta;

            }
            if (r() < rate10() && c.C14HydroxyacylCoAMAT >= delta)
            {
                c.C14HydroxyacylCoAMAT -= 1  * delta;
                c.C14KetoacylCoAMAT += 1 * delta;
            }
            
            if (r() < rate11() && c.C14KetoacylCoAMAT >= delta)
            {
                c.C14KetoacylCoAMAT -= 1 * delta;
                c.C12AcylCoAMAT += 1 * delta;
                c.AcetylCoAMAT += 1 * delta;

            }
            if (r() < rate12() && c.C12AcylCoAMAT >= delta)
            {
                c.C12AcylCoAMAT -= 1 * delta;
                c.C12EnoylCoAMAT += 1 * delta;

            }
            if (r() < rate13() && c.C12EnoylCoAMAT >= delta)
            {
                c.C12EnoylCoAMAT -= 1 * delta;
                c.C12HydroxyacylCoAMAT += 1 * delta;

            }
            
            if (r() < rate14() && c.C12HydroxyacylCoAMAT >= delta)
            {
                c.C12HydroxyacylCoAMAT -= 1  * delta;
                c.C12KetoacylCoAMAT += 1 * delta;

            }
            
            if (r() < rate15() && c.C12KetoacylCoAMAT >= delta)
            {
                c.C12KetoacylCoAMAT -= 1 * delta;
                c.C10AcylCoAMAT += 1 * delta;
                c.AcetylCoAMAT += 1 * delta;

            }
            if (r() < rate16() && c.C10AcylCoAMAT >= delta)
            {
                c.C10AcylCoAMAT -= 1 * delta;
                c.C10EnoylCoAMAT += 1 * delta;

            }
            if (r() < rate17() && c.C10EnoylCoAMAT >= delta)
            {
                c.C10EnoylCoAMAT -= 1 * delta;
                c.C10HydroxyacylCoAMAT += 1 * delta;

            }
            if (r() < rate18() && c.C10HydroxyacylCoAMAT >= delta)
            {
                c.C10HydroxyacylCoAMAT -= 1 * delta;
                c.C10KetoacylCoAMAT += 1 * delta;

            }
            
            if (r() < rate19() && c.C10KetoacylCoAMAT >= delta)
            {
                c.C10KetoacylCoAMAT -= 1 * delta;
                c.C8AcylCoAMAT += 1 * delta;
                c.AcetylCoAMAT += 1 * delta;

            }
            if (r() < rate20() && c.C8AcylCoAMAT >= delta)
            {
                c.C8AcylCoAMAT -= 1 * delta;
                c.C8EnoylCoAMAT += 1 * delta;

            }
            if (r() < rate21() && c.C8EnoylCoAMAT >= delta)
            {
                c.C8EnoylCoAMAT -= 1 * delta;
                c.C8HydroxyacylCoAMAT += 1 * delta;

            }
            if (r() < rate22() && c.C8HydroxyacylCoAMAT >= delta)
            {
                c.C8HydroxyacylCoAMAT -= 1 * delta;
                c.C8KetoacylCoAMAT += 1 * delta;

            }
            
            if (r() < rate23() && c.C8KetoacylCoAMAT >= delta)
            {
                c.C8KetoacylCoAMAT -= 1 * delta;
                c.C6AcylCoAMAT += 1 * delta;
                c.AcetylCoAMAT += 1 * delta;

            }
            if (r() < rate24() && c.C6AcylCoAMAT >= delta)
            {
                c.C6AcylCoAMAT -= 1 * delta;
                c.C6EnoylCoAMAT += 1 * delta;

            }
            if (r() < rate25() && c.C6EnoylCoAMAT >= delta)
            {
                c.C6EnoylCoAMAT -= 1 * delta;
                c.C6HydroxyacylCoAMAT += 1 * delta;

            }
            if (r() < rate26() && c.C6HydroxyacylCoAMAT >= delta)
            {

                c.C6HydroxyacylCoAMAT -= 1 * delta;
                c.C6KetoacylCoAMAT += 1 * delta;

            }
            if (r() < rate27() && c.C6KetoacylCoAMAT >= delta)
            {
                c.C6KetoacylCoAMAT -= 1 * delta;
                c.C4AcylCoAMAT += 1 * delta;
                c.AcetylCoAMAT += 1 * delta;

            }
            if (r() < rate28() && c.C4AcylCoAMAT >= delta)
            {
                c.C4AcylCoAMAT -= 1 * delta;
                c.C4EnoylCoAMAT += 1 * delta;

            }
            if (r() < rate29() && c.C4EnoylCoAMAT >= delta)
            {
                c.C4EnoylCoAMAT -= 1 * delta;
                c.C4HydroxyacylCoAMAT += 1 * delta;
            }
            if(r() < rate30() && c.C4HydroxyacylCoAMAT >= delta)
            {
                c.C4HydroxyacylCoAMAT -= 1 * delta;
                c.C4AcetoacylCoAMAT += 1 * delta;
            }
            if(r() < rate31() && c.C4AcetoacylCoAMAT >= delta)
            {
                c.C4AcetoacylCoAMAT -= 1 * delta;
                c.AcetylCoAMAT += 1 * delta;
            }
            if(r() < rate32() && c.AcetylCoAMAT >= delta)
            {
                c.AcetylCoAMAT -= 7 * delta;
            }

            return c;
        }

        public const double delta = 1e-4;

        public double rate1()
        {
            double vC16AcylCarCYT = (d.v_cpt1 * ((c.C16AcylCoACYT * d.CarCYT) / (d.K_M_C16AcylCoACYT * d.K_M_CarCYT_s) - (c.C16AcylCarCYT * d.CoACYT) / (d.K_M_C16AcylCarCYT_p * d.K_M_CoACYT_p))) / (1 + c.C16AcylCoACYT / d.K_M_C16AcylCoACYT + c.C16AcylCarCYT / d.K_M_C16AcylCarCYT_p) / (1 + d.CarCYT / d.K_M_CarCYT_p + d.CoACYT / d.K_M_CoACYT_s);
            return vC16AcylCarCYT;
        }

        // C16AcylCarCYT -> C16AcylCarMAT
        public double rate2()
        {
            double vC16AcylCarMAT = (d.v_cact * (c.C16AcylCarCYT / d.K_M_C16AcylCarCYT_s * d.CarMAT / d.K_M_CarMAT_s - c.C16AcylCarMAT / d.K_M_C16AcylCarMAT_p * (d.CarCYT) / d.K_M_CarCYT_p)) / ((1 + c.C16AcylCarCYT / d.K_M_C16AcylCarCYT_s + c.C16AcylCarMAT / d.K_M_C16AcylCarMAT_p) / (1 + d.CarMAT / d.K_M_CarMAT_p + d.CarCYT / d.K_M_CarCYT_s));
            return vC16AcylCarMAT;
        }

        // C16AcylCarMAT -> C16AcylCoAMAT
        public double rate3()
        {
            double vC16AcylCoAMAT = (d.v_cpt2 * ((c.C16AcylCarMAT * d.CoAMAT) / (d.K_M_C16AcylCarMAT_s * d.K_M_CoAMAT_p) - (c.C16AcylCoAMAT * d.CarMAT) / (d.K_M_C16AcylCoAMAT_p * d.K_M_CarMAT_s))) / ((1 + c.C16AcylCarMAT / d.K_M_C16AcylCarMAT_s + c.C16AcylCoAMAT / d.K_M_C16AcylCoAMAT_p) / (1 + d.CoAMAT / d.K_M_CoAMAT_p + d.CarMAT / d.K_M_CarMAT_s));
            return vC16AcylCoAMAT;
        }

        // C16AcylCoAMAT -> C16EnoylCoAMAT
        public double rate4()
        {
            double vC16EnoylCoAMAT = (d.v_vlcad * (c.C16AcylCoAMAT / d.K_M_C16AcylCoAMAT_s - c.C16EnoylCoAMAT / d.K_M_C16EnoylCoAMAT_p)) / ((1 + c.C16AcylCoAMAT / d.K_M_C16AcylCoAMAT_s + c.C16EnoylCoAMAT / d.K_M_C16EnoylCoAMAT_p));
            return vC16EnoylCoAMAT;
        }

        // C16EnoylCoAMAT -> C16HydroxyacylCoAMAT
        public double rate5()
        {
            double vC16HydroxyacylCoAMAT = (d.v_crot * (c.C16EnoylCoAMAT / d.K_M_C16EnoylCoAMAT_s - c.C16HydroxyacylCoAMAT / d.K_M_C16HydroxyacylCoAMAT_p)) / ((1 + c.C16EnoylCoAMAT / d.K_M_C16EnoylCoAMAT_s + c.C16HydroxyacylCoAMAT / d.K_M_C16HydroxyacylCoAMAT_p));
            return vC16HydroxyacylCoAMAT;
        }

        // C16HydroxyacylCoAMAT -> C16KetoacylCoAMAT
        public double rate6()
        {
            double vC16KetoacylCoAMAT = (d.v_mschad * (c.C16HydroxyacylCoAMAT / d.K_M_C16HydroxyacylCoAMAT_s - c.C16KetoacylCoAMAT / d.K_M_C16KetoacylCoAMAT_p)) / ((1 + c.C16HydroxyacylCoAMAT / d.K_M_C16HydroxyacylCoAMAT_s + c.C16KetoacylCoAMAT / d.K_M_C16KetoacylCoAMAT_p));
            return vC16KetoacylCoAMAT;
        }

        public double rate7()
        {
            double vC14AcylCoAMAT = (d.v_mckat * ((c.C16KetoacylCoAMAT * d.CoAMAT) / (d.K_M_C16KetoacylCoAMAT_s * d.K_M_CoAMAT_p) - (c.C14AcylCoAMAT * d.AcetylCoAMAT) / (d.K_M_C14AcylCoAMAT_p * d.K_M_AcetylCoAMAT_p))) / ((1 + c.C16KetoacylCoAMAT / d.K_M_C16KetoacylCoAMAT_s + c.C14AcylCoAMAT / d.K_M_C14AcylCoAMAT_p) / (1 + d.CoAMAT / d.K_M_CoAMAT_p + d.AcetylCoAMAT / d.K_M_AcetylCoAMAT_p));
            return vC14AcylCoAMAT;
        }

        // C14AcylCoAMAT -> C14EnoylCoAMAT
        public double rate8()
        {
            double vC14EnoylCoAMAT = (d.v_vlcad * (c.C14AcylCoAMAT / d.K_M_C14AcylCoAMAT_s - c.C14EnoylCoAMAT / d.K_M_C14EnoylCoAMAT_p)) / ((1 + c.C14AcylCoAMAT / d.K_M_C14AcylCoAMAT_p + c.C14EnoylCoAMAT / d.K_M_C14EnoylCoAMAT_p));
            return vC14EnoylCoAMAT;
        }

        // C14EnoylCoAMAT -> C14HydroxyacylCoAMAT
        public double rate9()
        {
            double vC14HydroxyacylCoAMAT = (d.v_crot * (c.C14EnoylCoAMAT / d.K_M_C14EnoylCoAMAT_s - c.C14HydroxyacylCoAMAT / d.K_M_C14HydroxyacylCoAMAT_p)) / ((1 + c.C14EnoylCoAMAT / d.K_M_C14EnoylCoAMAT_s + c.C14HydroxyacylCoAMAT / d.K_M_C14HydroxyacylCoAMAT_p));
            return vC14HydroxyacylCoAMAT;
        }

        // C14HydroxyacylCoAMAT -> C14KetoacylCoAMAT
        public double rate10()
        {
            double vC14KetoacylCoAMAT = (d.v_mschad * (c.C14HydroxyacylCoAMAT / d.K_M_C14HydroxyacylCoAMAT_s - c.C14KetoacylCoAMAT / d.K_M_C14KetoacylCoAMAT_p)) / ((1 + c.C14HydroxyacylCoAMAT / d.K_M_C14HydroxyacylCoAMAT_s + c.C14KetoacylCoAMAT / d.K_M_C14KetoacylCoAMAT_p));
            return 1e-1 * vC14KetoacylCoAMAT;
        }

        // C14KetoacylCoAMAT -> C12AcylCoAMAT
        public double rate11()
        {
            double vC12AcylCoAMAT = (d.v_mckat * ((c.C14KetoacylCoAMAT * d.CoAMAT) / (d.K_M_C14KetoacylCoAMAT_s * d.K_M_CoAMAT_p) - (c.C12AcylCoAMAT * d.AcetylCoAMAT) / (d.K_M_C12AcylCoAMAT_p * d.K_M_AcetylCoAMAT_p))) / ((1 + c.C14KetoacylCoAMAT / d.K_M_C14KetoacylCoAMAT_s + c.C12AcylCoAMAT / d.K_M_C12AcylCoAMAT_p) / (1 + d.CoAMAT / d.K_M_CoAMAT_p + d.AcetylCoAMAT / d.K_M_AcetylCoAMAT_p));
            return vC12AcylCoAMAT;
        }

        // C12AcylCoAMAT -> C12EnoylCoAMAT
        public double rate12()
        {
            double vC12EnoylCoAMAT = (d.v_vlcad * (c.C12AcylCoAMAT / d.K_M_C12AcylCoAMAT_s - c.C12EnoylCoAMAT / d.K_M_C12EnoylCoAMAT_p)) / ((1 + c.C12AcylCoAMAT / d.K_M_C12AcylCoAMAT_s + c.C12EnoylCoAMAT / d.K_M_C12EnoylCoAMAT_p));
            return vC12EnoylCoAMAT;
        }

        // C12EnoylCoAMAT -> C12HydroxyacylCoAMAT
        public double rate13()
        {
            double vC12HydroxyacylCoAMAT = (d.v_crot * (c.C12EnoylCoAMAT / d.K_M_C12EnoylCoAMAT_s - c.C12HydroxyacylCoAMAT / d.K_M_C12HydroxyacylCoAMAT_p)) / ((1 + c.C12EnoylCoAMAT / d.K_M_C12EnoylCoAMAT_p + c.C12HydroxyacylCoAMAT / d.K_M_C12HydroxyacylCoAMAT_p));
            return vC12HydroxyacylCoAMAT;
        }

        // C12HydroxyacylCoAMAT -> C12KetoacylCoAMAT
        public double rate14()
        {
            double vC12KetoacylCoAMAT = (d.v_mschad * (c.C12HydroxyacylCoAMAT / d.K_M_C12HydroxyacylCoAMAT_s - c.C12KetoacylCoAMAT / d.K_M_C12KetoacylCoAMAT_p)) / ((1 + c.C12HydroxyacylCoAMAT / d.K_M_C12HydroxyacylCoAMAT_s + c.C12KetoacylCoAMAT / d.K_M_C12KetoacylCoAMAT_p));
            return vC12KetoacylCoAMAT;
        }

        // C12KetoacylCoAMAT -> C10AcylCoAMAT
        public double rate15()
        {
            double vC10AcylCoAMAT = (d.v_mckat * ((c.C12KetoacylCoAMAT * d.CoAMAT) / (d.K_M_C12KetoacylCoAMAT_s * d.K_M_CoAMAT_p) - (c.C10AcylCoAMAT * d.AcetylCoAMAT) / (d.K_M_C10AcylCoAMAT_p * d.K_M_AcetylCoAMAT_p))) / ((1 + c.C12KetoacylCoAMAT / d.K_M_C12KetoacylCoAMAT_s + c.C10AcylCoAMAT / d.K_M_C10AcylCoAMAT_p) / (1 + d.CoAMAT / d.K_M_CoAMAT_p + d.AcetylCoAMAT / d.K_M_AcetylCoAMAT_p));
            return vC10AcylCoAMAT;
        }

        // C10AcylCoAMAT -> C10EnoylCoAMAT
        public double rate16()
        {
            double vC10EnoylCoAMAT = (d.v_lcad * (c.C10AcylCoAMAT / d.K_M_C10AcylCoAMAT_s - c.C10EnoylCoAMAT / d.K_M_C10EnoylCoAMAT_p)) / ((1 + c.C10AcylCoAMAT / d.K_M_C10AcylCoAMAT_s + c.C10EnoylCoAMAT / d.K_M_C10EnoylCoAMAT_s));
            return vC10EnoylCoAMAT;
        }

        // C10EnoylCoAMAT -> C10HydroxyacylCoAMAT
        public double rate17()
        {
            double vC10HydroxyacylCoAMAT = (d.v_crot * (c.C10EnoylCoAMAT / d.K_M_C10EnoylCoAMAT_s - c.C10HydroxyacylCoAMAT / d.K_M_C10HydroxyacylCoAMAT_p)) / ((1 + c.C10EnoylCoAMAT / d.K_M_C10EnoylCoAMAT_s + c.C10HydroxyacylCoAMAT / d.K_M_C10HydroxyacylCoAMAT_p));
            return vC10HydroxyacylCoAMAT;
        }

        // C10HydroxyacylCoAMAT -> C10KetoacylCoAMAT
        public double rate18()
        {
            double vC10KetoacylCoAMAT = (d.v_mschad * (c.C10HydroxyacylCoAMAT / d.K_M_C10HydroxyacylCoAMAT_s - c.C10KetoacylCoAMAT / d.K_M_C10KetoacylCoAMAT_p)) / ((1 + c.C10HydroxyacylCoAMAT / d.K_M_C10HydroxyacylCoAMAT_s + c.C10KetoacylCoAMAT / d.K_M_C10KetoacylCoAMAT_p));
            return vC10KetoacylCoAMAT;
        }

        // C10KetoacylCoAMAT -> C8AcylCoAMAT
        public double rate19()
        {
            double vC8AcylCoAMAT = (d.v_mckat * ((c.C10KetoacylCoAMAT * d.CoAMAT) / (d.K_M_C10KetoacylCoAMAT_s * d.K_M_CoAMAT_p) - (c.C8AcylCoAMAT * d.AcetylCoAMAT) / (d.K_M_C8AcylCoAMAT_p * d.K_M_AcetylCoAMAT_p))) / ((1 + c.C10KetoacylCoAMAT / d.K_M_C10KetoacylCoAMAT_s + c.C8AcylCoAMAT / d.K_M_C8AcylCoAMAT_p) / (1 + d.CoAMAT / d.K_M_CoAMAT_p + d.AcetylCoAMAT / d.K_M_AcetylCoAMAT_p));
            return vC8AcylCoAMAT;
        }

        // C8AcylCoAMAT -> C8EnoylCoAMAT
        public double rate20()
        {
            double vC8EnoylCoAMAT = (d.v_lcad * (c.C8AcylCoAMAT / d.K_M_C8AcylCoAMAT_s - c.C8EnoylCoAMAT / d.K_M_C8EnoylCoAMAT_p)) / ((1 + c.C8AcylCoAMAT / d.K_M_C8AcylCoAMAT_s + c.C8EnoylCoAMAT / d.K_M_C8EnoylCoAMAT_p));
            return vC8EnoylCoAMAT;
        }

        // C8EnoylCoAMAT -> C8HydroxyacylCoAMAT
        public double rate21()
        {
            double vC8HydroxyacylCoAMAT = (d.v_crot * (c.C8EnoylCoAMAT / d.K_M_C8EnoylCoAMAT_s - c.C8HydroxyacylCoAMAT / d.K_M_C8HydroxyacylCoAMAT_p)) / ((1 + c.C8EnoylCoAMAT / d.K_M_C8EnoylCoAMAT_s + c.C8HydroxyacylCoAMAT / d.K_M_C8HydroxyacylCoAMAT_p));
            return vC8HydroxyacylCoAMAT;
        }

        // C8HydroxyacylCoAMAT -> C8KetoacylCoAMAT
        public double rate22()
        {
            double vC8KetoacylCoAMAT = (d.v_mschad * (c.C8HydroxyacylCoAMAT / d.K_M_C8HydroxyacylCoAMAT_s - c.C8KetoacylCoAMAT / d.K_M_C8KetoacylCoAMAT_p)) / ((1 + c.C8HydroxyacylCoAMAT / d.K_M_C8HydroxyacylCoAMAT_s + c.C8KetoacylCoAMAT / d.K_M_C8KetoacylCoAMAT_p));
            return vC8KetoacylCoAMAT;
        }

        // C8KetoacylCoAMAT -> C6AcylCoAMAT
        public double rate23()
        {
            double vC6AcylCoAMAT = (d.v_mckat * ((c.C8KetoacylCoAMAT * d.CoAMAT) / (d.K_M_C8KetoacylCoAMAT_s * d.K_M_CoAMAT_p) - (c.C6AcylCoAMAT * d.AcetylCoAMAT) / (d.K_M_C6AcylCoAMAT_p * d.K_M_AcetylCoAMAT_p))) / ((1 + c.C8KetoacylCoAMAT / d.K_M_C8KetoacylCoAMAT_s + c.C6AcylCoAMAT / d.K_M_C6AcylCoAMAT_p) / (1 + d.CoAMAT / d.K_M_CoAMAT_p + d.AcetylCoAMAT / d.K_M_AcetylCoAMAT_p));
            return vC6AcylCoAMAT;
        }

        // C6AcylCoAMAT -> C6EnoylCoAMAT
        public double rate24()
        {
            double vC6EnoylCoAMAT = (d.v_mcad * (c.C6AcylCoAMAT / d.K_M_C6AcylCoAMAT_s - c.C6EnoylCoAMAT / d.K_M_C6EnoylCoAMAT)) / ((1 + c.C6AcylCoAMAT / d.K_M_C6AcylCoAMAT_s + c.C6EnoylCoAMAT / d.K_M_C6EnoylCoAMAT));
            return vC6EnoylCoAMAT;
        }

        // C6EnoylCoAMAT -> C6HydroxyacylCoAMAT
        public double rate25()
        {
            double vC6HydroxyacylCoAMAT = (d.v_crot * (c.C6EnoylCoAMAT / d.K_M_C6EnoylCoAMAT - c.C6HydroxyacylCoAMAT / d.K_M_C6HydroxyacylCoAMAT)) / ((1 + c.C6EnoylCoAMAT / d.K_M_C6EnoylCoAMAT + c.C6HydroxyacylCoAMAT / d.K_M_C6HydroxyacylCoAMAT));
            return vC6HydroxyacylCoAMAT;
        }

        // C6HydroxyacylCoAMAT -> C6KetoacylCoAMAT
        public double rate26()
        {
            double vC6KetoacylCoAMAT = (d.v_mschad * (c.C6HydroxyacylCoAMAT / d.K_M_C6HydroxyacylCoAMAT - c.C6KetoacylCoAMAT / d.K_M_C6KetoacylCoAMAT_p)) / ((1 + c.C6HydroxyacylCoAMAT / d.K_M_C6HydroxyacylCoAMAT + c.C6KetoacylCoAMAT / d.K_M_C6KetoacylCoAMAT_p));
            return vC6KetoacylCoAMAT;
        }

        // C6KetoacylCoAMAT -> C4AcylCoAMAT
        public double rate27()
        {
            double vC4AcylCoAMAT = (d.v_mckat * ((c.C6KetoacylCoAMAT * d.CoAMAT) / (d.K_M_C6KetoacylCoAMAT_s * d.K_M_CoAMAT_p) - (c.C4AcylCoAMAT * d.AcetylCoAMAT) / (d.K_M_C4AcylCoAMAT_p * d.K_M_AcetylCoAMAT_p))) / ((1 + c.C6KetoacylCoAMAT / d.K_M_C6KetoacylCoAMAT_s + c.C4AcylCoAMAT / d.K_M_C4AcylCoAMAT_p) / (1 + d.CoAMAT / d.K_M_CoAMAT_p + d.AcetylCoAMAT / d.K_M_AcetylCoAMAT_p));
            return vC4AcylCoAMAT;
        }

        // C4AcylCoAMAT -> C4EnoylCoAMAT
        public double rate28()
        {
            double vC4EnoylCoAMAT = (d.v_mcad * (c.C4AcylCoAMAT / d.K_M_C4AcylCoAMAT_s - c.C4EnoylCoAMAT / d.K_M_C4EnoylCoAMAT_p)) / ((1 + c.C4AcylCoAMAT / d.K_M_C4AcylCoAMAT_s + c.C4EnoylCoAMAT / d.K_M_C4EnoylCoAMAT_p));
            return vC4EnoylCoAMAT;
        }

        // C4EnoylCoAMAT -> C4HydroxyacylCoAMAT
        public double rate29()
        {
            double vC4HydroxyacylCoAMAT = (d.v_crot * (c.C4EnoylCoAMAT / d.K_M_C4EnoylCoAMAT_s - c.C4HydroxyacylCoAMAT / d.K_M_C4HydroxyacylCoAMAT_p)) / ((1 + c.C4EnoylCoAMAT / d.K_M_C4EnoylCoAMAT_s + c.C4HydroxyacylCoAMAT / d.K_M_C4HydroxyacylCoAMAT_p));
            return vC4HydroxyacylCoAMAT;
        }

        // C4HydroxyacylCoAMAT -> C4AcetoacylCoAMAT
        public double rate30()
        {
            double vC4KetoacylCoAMAT = (d.v_mschad * (c.C4HydroxyacylCoAMAT / d.K_M_C4HydroxyacylCoAMAT_s - c.C4AcetoacylCoAMAT / d.K_M_C4AcetoacetylCoAMAT_p)) / ((1 + c.C4HydroxyacylCoAMAT / d.K_M_C4HydroxyacylCoAMAT_s + c.C4AcetoacylCoAMAT / d.K_M_C4AcetoacetylCoAMAT_p));
            return vC4KetoacylCoAMAT;
        }

        // C4AcetoacylCoAMAT -> AcetylCoAMAT
        public double rate31()
        {
            double vAcetylCoAMAT = (d.v_mckat * ((c.C4AcetoacylCoAMAT * d.CoAMAT) / (d.K_M_C4AcetoacetylCoAMAT_s * d.K_M_CoAMAT_p) - d.AcetylCoAMAT / d.K_M_AcetylCoAMAT_p)) / ((1 + c.C4AcetoacylCoAMAT / d.K_M_C4AcetoacetylCoAMAT_s + d.CoAMAT / d.K_M_CoAMAT_p + d.AcetylCoAMAT / d.K_M_AcetylCoAMAT_s));
            return vAcetylCoAMAT;
        }

        public double rate32()
        {
            double a = d.rate50_const;
            double b = c.AcetylCoAMAT;
            double _c = 0;

            double V57 = a * (b - _c);
            return V57;
        }

        public double[] GetRates()
        {
            set_noised_constants();
            return new double[]
            {
                rate1(),
                rate2(),
                rate3(),
                rate4(),
                rate5(),
                rate6(),
                rate7(),
                rate8(),
                rate9(),
                rate10(),
                rate11(),
                rate12(),
                rate13(),
                rate14(),
                rate15(),
                rate16(),
                rate17(),
                rate18(),
                rate19(),
                rate20(),
                rate21(),
                rate22(),
                rate23(),
                rate24(),
                rate25(),
                rate26(),
                rate27(),
                rate28(),
                rate29(),
                rate30(),
                rate31(),
                rate32()
            };
        }

        public string[] GetRatesNames()
        {
            return new string[]
            {
                "rate1",
                "rate2",
                "rate3",
                "rate4",
                "rate5",
                "rate6",
                "rate7",
                "rate8",
                "rate9",
                "rate10",
                "rate11",
                "rate12",
                "rate13",
                "rate14",
                "rate15",
                "rate16",
                "rate17",
                "rate18",
                "rate19",
                "rate20",
                "rate21",
                "rate22",
                "rate23",
                "rate24",
                "rate25",
                "rate26",
                "rate27",
                "rate28",
                "rate29",
                "rate30",
                "rate31",
                "rate32"
            };
        }
    }
}
