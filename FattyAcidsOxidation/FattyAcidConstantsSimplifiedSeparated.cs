using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FattyAcidsOxidation
{
    public class FattyAcidConstantsSimplifiedSeparated : IConstants
    {
        public static FattyAcidConstantsSimplifiedSeparated GetTrainedConstants()
        {
            string json = "{\"v_cpt1\":0.11528361784485947,\"CarCYT\":155.37359314138163,\"K_M_CarMAT_s\":44.602124341990674,\"K_M_C16AcylCarMAT_s\":3.442137151226095,\"CoACYT\":0.8468155725470968,\"K_M_C16AcylCoACYT\":2.644512367554618,\"K_M_CarCYT_s\":221.45452893630602,\"v_cpt2\":0.03523423170517743,\"CoAMAT\":1214.7436389766497,\"AcetylCoAMAT\":28.818925536554126,\"K_M_C14EnoylCoAMAT_s\":2.9217389950046773,\"K_M_C14HydroxyacylCoAMAT_s\":0.8873886197223788,\"C12AcylCarCYT\":0.0014521978788859529,\"K_M_C12AcylCoACYT\":8.767625241436892,\"K_M_C12AcylCarCYT\":25.17853168825551,\"K_M_C12AcylCarMAT_s\":64.07919729922631,\"K_M_C12AcylCoAMAT_s\":0.06936737905865115,\"K_M_C14KetoacylCoAMAT_s\":3.4879999950866747,\"K_M_AcetylCoAMAT_s\":151.98671834785512,\"K_M_C16AcylCarCYT_s\":503.28581704715043,\"K_M_CoACYT_s\":196.5971798562826,\"v_cact\":0.3427708211919056,\"CarMAT\":183.13571743087945,\"K_M_CoAMAT_s\":38.8433861354568,\"K_M_C16AcylCoAMAT_s\":0.05266179977954729,\"v_vlcad\":0.23590874541375334,\"K_M_C12EnoylCoAMAT_s\":0.05130782053355558,\"K_M_C12HydroxyacylCoAMAT_s\":0.13101927709091157,\"K_M_C12KetoacylCoAMAT_s\":28.85854667900035,\"K_M_C10AcylCoACYT\":3.1093313623727465,\"K_M_C10AcylCarCYT_s\":5.3605981402673955,\"K_M_C10AcylCarMAT_s\":6.110940621089041,\"K_M_C10AcylCoAMAT_s\":0.6690959485538216,\"v_lcad\":0.10593962360093143,\"K_M_C10EnoylCoAMAT_s\":4.884446630221381,\"K_M_C10HydroxyacylCoAMAT_s\":2.0747864857877296,\"K_M_C10KetoacylCoAMAT_s\":0.6014115642991283,\"K_M_C8AcylCoACYT\":0.7732768615573655,\"K_M_C8AcylCarCYT_s\":7.387477623198317,\"K_M_C8AcylCarMAT_s\":55.05233472032171,\"K_M_C8AcylCoAMAT_s\":1.547534871929969,\"K_M_C8EnoylCoAMAT_s\":1.7375703423678357,\"K_M_C8HydroxyacylCoAMAT_s\":2.1762682826074,\"K_M_C8KetoacylCoAMAT_s\":9.29380374805716,\"K_M_C6AcylCoACYT\":39.94925375113704,\"K_M_C6AcylCarCYT_s\":0.4407276952387462,\"K_M_C6AcylCarMAT_s\":41.69381370889092,\"K_M_C16EnoylCoAMAT_s\":0.16615932985737134,\"v_crot\":1.3786896964454347,\"K_M_C16HydroxyacylCoAMAT_s\":0.0421879152105785,\"v_mschad\":0.521661226726191,\"K_M_C16KetoacylCoAMAT_s\":6.9932633828449475,\"K_M_C14AcylCoACYT\":0.9297307179195593,\"K_M_C14AcylCarCYT\":309.5561092000071,\"K_M_C14AcylCarMAT_s\":58.65118631053082,\"K_M_C14AcylCoAMAT_s\":0.008965805725734114,\"v_mckat\":0.05972860062596125,\"K_M_C6AcylCoAMAT_s\":0.795377624765532,\"v_mcad\":0.13234175054842393,\"K_M_C6EnoylCoAMAT\":0.07403151000738338,\"K_M_C6HydroxyacylCoAMAT\":2.835764370118826,\"K_M_C6KetoacylCoAMAT_s\":36.875607662663015,\"K_M_C4AcylCoACYT\":1.1286980756528189,\"K_M_C4AcylCarCYT_s\":9.213458488893826,\"K_M_C4AcylCarMAT_s\":0.8404844725157772,\"K_M_C4AcylCoAMAT_s\":0.7522317900284947,\"K_M_C4EnoylCoAMAT_s\":0.22987298043035997,\"K_M_C4HydroxyacylCoAMAT_s\":5.854046799081733,\"K_M_C4AcetoacetylCoAMAT_s\":0.029076211247449843,\"rate50_const\":0.13098338017445438,\"rate50_const2\":0.039259221125973326,\"K_M_CarMAT_p\":589.8347163408179,\"K_M_C16AcylCarMAT_p\":1026.4082396622744,\"K_M_CarCYT_p\":67.60326980448544,\"K_M_C14EnoylCoAMAT_p\":1588.2516651826766,\"K_M_C14HydroxyacylCoAMAT_p\":4.593281747711517,\"K_M_C12AcylCarMAT_p\":81.21407819235564,\"K_M_C12AcylCoAMAT_p\":0.1769674765764751,\"K_M_C14KetoacylCoAMAT_p\":1.2688275076020896,\"K_M_AcetylCoAMAT_p\":41.46854707223197,\"K_M_C16AcylCarCYT_p\":7.901645780116042,\"K_M_CoACYT_p\":60.24170450890395,\"K_M_CoAMAT_p\":66.84831248771144,\"K_M_C16AcylCoAMAT_p\":2.0626896516635607,\"K_M_C12EnoylCoAMAT_p\":554.3565029784536,\"K_M_C12HydroxyacylCoAMAT_p\":0.2179271154496476,\"K_M_C12KetoacylCoAMAT_p\":44.88370986629515,\"K_M_C10AcylCarCYT_p\":64.51667603255306,\"K_M_C10AcylCarMAT_p\":51.0,\"K_M_C10AcylCoAMAT_p\":0.18947430700350962,\"K_M_C10EnoylCoAMAT_p\":3.07692342561646,\"K_M_C10HydroxyacylCoAMAT_p\":3.247832926422459,\"K_M_C10KetoacylCoAMAT_p\":4.2754740335067485,\"K_M_C8AcylCarCYT_p\":238.2398671781845,\"K_M_C8AcylCarMAT_p\":2.615882533770649,\"K_M_C8AcylCoAMAT_p\":5.98926849277578,\"K_M_C8EnoylCoAMAT_p\":2.6928542444010826,\"K_M_C8HydroxyacylCoAMAT_p\":2.079375229827543,\"K_M_C8KetoacylCoAMAT_p\":118.06862496933057,\"K_M_C6AcylCarCYT_p\":18.96687064619374,\"K_M_C6AcylCarMAT_p\":4.225387112379267,\"K_M_C16EnoylCoAMAT_p\":26125.02074353141,\"K_M_C16HydroxyacylCoAMAT_p\":1.0152284464581123,\"K_M_C16KetoacylCoAMAT_p\":0.8870560487844432,\"K_M_C14AcylCarMAT_p\":29.821585118427876,\"K_M_C14AcylCoAMAT_p\":1.9582770422622566,\"K_M_C6AcylCoAMAT_p\":0.29221612798257257,\"K_M_C6KetoacylCoAMAT_p\":0.03963965863691018,\"K_M_C4AcylCarCYT_p\":2.180977683752745,\"K_M_C4AcylCarMAT_p\":18.26271706781128,\"K_M_C4AcylCoAMAT_p\":13.780038272264967,\"K_M_C4EnoylCoAMAT_p\":2.337192146769423,\"K_M_C4HydroxyacylCoAMAT_p\":651.7782449142014,\"K_M_C4AcetoacetylCoAMAT_p\":479.8414283720975}";
            var c = JsonConvert.DeserializeObject<FattyAcidConstantsSimplifiedSeparated>(json);
            return c;
        }

        public double v_cpt1;
        public double CarCYT;
        public double K_M_CarMAT_s;

        public double K_M_CarMAT_p { get; set; }

        public double K_M_C16AcylCarMAT_s;

        public double K_M_C16AcylCarMAT_p { get; set; }

        public double CoACYT;
        public double K_M_C16AcylCoACYT;
        public double K_M_CarCYT_s;

        public double K_M_CarCYT_p { get; set; }

        public double v_cpt2;
        public double CoAMAT;

        public double AcetylCoAMAT;
        public double K_M_C14EnoylCoAMAT_s;

        public double K_M_C14EnoylCoAMAT_p { get; set; }

        public double K_M_C14HydroxyacylCoAMAT_s;

        public double K_M_C14HydroxyacylCoAMAT_p { get; set; }

        public double C12AcylCarCYT;
        public double K_M_C12AcylCoACYT;
        public double K_M_C12AcylCarCYT;
        public double K_M_C12AcylCarMAT_s;

        public double K_M_C12AcylCarMAT_p { get; set; }

        public double K_M_C12AcylCoAMAT_s;

        public double K_M_C12AcylCoAMAT_p { get; set; }

        public double K_M_C14KetoacylCoAMAT_s;

        public double K_M_C14KetoacylCoAMAT_p { get; set; }

        public double K_M_AcetylCoAMAT_s;

        public double K_M_AcetylCoAMAT_p { get; set; }

        public double K_M_C16AcylCarCYT_s;

        public double K_M_C16AcylCarCYT_p { get; set; }

        public double K_M_CoACYT_s;

        public double K_M_CoACYT_p { get; set; }

        public double v_cact;
        public double CarMAT;
        public double K_M_CoAMAT_s;

        public double K_M_CoAMAT_p { get; set; }

        public double K_M_C16AcylCoAMAT_s;

        public double K_M_C16AcylCoAMAT_p { get; set; }

        public double v_vlcad;

        public double K_M_C12EnoylCoAMAT_s;

        public double K_M_C12EnoylCoAMAT_p { get; set; }

        public double K_M_C12HydroxyacylCoAMAT_s;

        public double K_M_C12HydroxyacylCoAMAT_p { get; set; }

        public double K_M_C12KetoacylCoAMAT_s;

        public double K_M_C12KetoacylCoAMAT_p { get; set; }

        public double K_M_C10AcylCoACYT;
        public double K_M_C10AcylCarCYT_s;

        public double K_M_C10AcylCarCYT_p { get; set; }

        public double K_M_C10AcylCarMAT_s;

        public double K_M_C10AcylCarMAT_p { get; set; }

        public double K_M_C10AcylCoAMAT_s;

        public double K_M_C10AcylCoAMAT_p { get; set; }

        public double v_lcad;

        public double K_M_C10EnoylCoAMAT_s;

        public double K_M_C10EnoylCoAMAT_p { get; set; }

        public double K_M_C10HydroxyacylCoAMAT_s;

        public double K_M_C10HydroxyacylCoAMAT_p { get; set; }

        public double K_M_C10KetoacylCoAMAT_s;

        public double K_M_C10KetoacylCoAMAT_p { get; set; }

        public double K_M_C8AcylCoACYT;
        public double K_M_C8AcylCarCYT_s;

        public double K_M_C8AcylCarCYT_p { get; set; }

        public double K_M_C8AcylCarMAT_s;

        public double K_M_C8AcylCarMAT_p { get; set; }

        public double K_M_C8AcylCoAMAT_s;

        public double K_M_C8AcylCoAMAT_p { get; set; }

        public double K_M_C8EnoylCoAMAT_s;

        public double K_M_C8EnoylCoAMAT_p { get; set; }

        public double K_M_C8HydroxyacylCoAMAT_s;

        public double K_M_C8HydroxyacylCoAMAT_p { get; set; }

        public double K_M_C8KetoacylCoAMAT_s;

        public double K_M_C8KetoacylCoAMAT_p { get; set; }

        public double K_M_C6AcylCoACYT;
        public double K_M_C6AcylCarCYT_s;

        public double K_M_C6AcylCarCYT_p { get; set; }

        public double K_M_C6AcylCarMAT_s;

        public double K_M_C6AcylCarMAT_p { get; set; }

        public double K_M_C16EnoylCoAMAT_s;

        public double K_M_C16EnoylCoAMAT_p { get; set; }

        public double v_crot;


        public double K_M_C16HydroxyacylCoAMAT_s;

        public double K_M_C16HydroxyacylCoAMAT_p { get; set; }

        public double v_mschad;

        public double K_M_C16KetoacylCoAMAT_s;

        public double K_M_C16KetoacylCoAMAT_p { get; set; }

        public double K_M_C14AcylCoACYT;
        public double K_M_C14AcylCarCYT;
        public double K_M_C14AcylCarMAT_s;

        public double K_M_C14AcylCarMAT_p { get; set; }

        public double K_M_C14AcylCoAMAT_s;

        public double K_M_C14AcylCoAMAT_p { get; set; }

        public double v_mckat;
        public double K_M_C6AcylCoAMAT_s;

        public double K_M_C6AcylCoAMAT_p { get; set; }

        public double v_mcad;

        public double K_M_C6EnoylCoAMAT;
        public double K_M_C6HydroxyacylCoAMAT;
        public double K_M_C6KetoacylCoAMAT_s;

        public double K_M_C6KetoacylCoAMAT_p { get; set; }

        public double K_M_C4AcylCoACYT;
        public double K_M_C4AcylCarCYT_s;

        public double K_M_C4AcylCarCYT_p { get; set; }

        public double K_M_C4AcylCarMAT_s;

        public double K_M_C4AcylCarMAT_p { get; set; }

        public double K_M_C4AcylCoAMAT_s;

        public double K_M_C4AcylCoAMAT_p { get; set; }

        public double K_M_C4EnoylCoAMAT_s;

        public double K_M_C4EnoylCoAMAT_p { get; set; }

        public double K_M_C4HydroxyacylCoAMAT_s;

        public double K_M_C4HydroxyacylCoAMAT_p { get; set; }

        public double K_M_C4AcetoacetylCoAMAT_s;

        public double K_M_C4AcetoacetylCoAMAT_p { get; set; }

        public double rate50_const;
        public double rate50_const2;

        public FattyAcidConstantsSimplifiedSeparated()
        {
            v_cpt1 = 0.012;
            CarCYT = 200;
            CoACYT = 140;
            K_M_C16AcylCoACYT = 13.8;

            K_M_CarCYT_s = 250;
            K_M_CarCYT_p = 130;
            //K_M_CarCYT = 250;
            //K_M_CarCYT = 250;
            //K_M_CarCYT = 250;
            //K_M_CarCYT = 130;
            //K_M_CarCYT = 130;
            //K_M_CarCYT = 250;
            //K_M_CarCYT = 130;
            //K_M_CarCYT = 250;
            //K_M_CarCYT = 130;
            //K_M_CarCYT = 130;
            //K_M_CarCYT = 130;

            K_M_C16AcylCarCYT_s = 136;
            K_M_C16AcylCarCYT_p = 15;

            K_M_CoACYT_s = 40.7;
            //K_M_CoACYT = 40.7;
            //K_M_CoACYT = 40.7;
            //K_M_CoACYT = 40.7;
            K_M_CoACYT_p = 130;




            v_cact = 0.42;
            //v_cact = 0.42;

            CarMAT = 950;
            
            CarCYT = 200;
            //CarCYT = 200;

            K_M_CarMAT_s = 130;
            K_M_CarMAT_p = 350;
            //K_M_CarMAT = 350;
            //K_M_CarMAT = 130;
            //K_M_CarMAT = 350;
            //K_M_CarMAT = 130;
            //K_M_CarMAT = 350;
            //K_M_CarMAT = 130;
            //K_M_CarMAT = 130;
            //K_M_CarMAT = 350;
            //K_M_CarMAT = 130;
            //K_M_CarMAT = 350;





            K_M_C16AcylCarMAT_s = 15;
            K_M_C16AcylCarMAT_p = 51;

            v_cpt2 = 0.391;
            //v_cpt2 = 0.391;

            CoAMAT = 5000;

            CarMAT = 950;
            //CarMAT = 950;


            K_M_CoAMAT_s = 30;
            K_M_CoAMAT_p = 26.6;
            //K_M_CoAMAT = 30;
            //K_M_CoAMAT = 26.6;
            //K_M_CoAMAT = 30;
            //K_M_CoAMAT = 26.6;
            //K_M_CoAMAT = 26.6;
            //K_M_CoAMAT = 30;
            //K_M_CoAMAT = 26.6;
            //K_M_CoAMAT = 30;
            //K_M_CoAMAT = 26.6;
            //K_M_CoAMAT = 26.6;






            K_M_C16AcylCoAMAT_s = 38;
            K_M_C16AcylCoAMAT_p = 6.5;

            v_vlcad = 0.008;

            K_M_C16EnoylCoAMAT_s = 1.08;
            K_M_C16EnoylCoAMAT_p = 150;

            v_crot = 3.6;

            K_M_C16HydroxyacylCoAMAT_s = 40;
            K_M_C16HydroxyacylCoAMAT_p = 1.5;

            v_mschad = 1;

            K_M_C16KetoacylCoAMAT_s = 1.4;
            K_M_C16KetoacylCoAMAT_p = 1.1;


            K_M_C14AcylCoACYT = 13.8;
            K_M_C14AcylCarCYT = 136;

            K_M_C14AcylCarMAT_s = 15;
            K_M_C14AcylCarMAT_p = 51;

            K_M_C14AcylCoAMAT_s = 38;
            K_M_C14AcylCoAMAT_p = 13.83;
            //K_M_C14AcylCoAMAT = 4;


            v_mckat = 0.377;
            //v_mckat = 0.377;


            CoAMAT = 5000;
            
            AcetylCoAMAT = 30;
            //AcetylCoAMAT = 30;
            //AcetylCoAMAT = 30;
            //AcetylCoAMAT = 30;


            K_M_C14EnoylCoAMAT_s = 1.08;
            K_M_C14EnoylCoAMAT_p = 100;

            K_M_C14HydroxyacylCoAMAT_s = 45;
            K_M_C14HydroxyacylCoAMAT_p = 1.8;

            C12AcylCarCYT = 0.11;
            K_M_C12AcylCoACYT = 13.8;
            K_M_C12AcylCarCYT = 136;

            K_M_C12AcylCarMAT_s = 15;
            K_M_C12AcylCarMAT_p = 51;

            K_M_C12AcylCoAMAT_s = 38;
            K_M_C12AcylCoAMAT_p = 13.83;
            //K_M_C12AcylCoAMAT = 2.7;


            K_M_C14KetoacylCoAMAT_s = 1.2;
            K_M_C14KetoacylCoAMAT_p = 1.4;


            K_M_AcetylCoAMAT_s = 30;
            K_M_AcetylCoAMAT_p = 30;
            //K_M_AcetylCoAMAT = 30;
            //K_M_AcetylCoAMAT = 30;
            //K_M_AcetylCoAMAT = 30;
            //K_M_AcetylCoAMAT = 30;
            //K_M_AcetylCoAMAT = 30;



            v_vlcad = 0.008;

            K_M_C12EnoylCoAMAT_s = 1.08;
            K_M_C12EnoylCoAMAT_p = 25;

            K_M_C12HydroxyacylCoAMAT_s = 45;
            K_M_C12HydroxyacylCoAMAT_p = 3.7;

            K_M_C12KetoacylCoAMAT_s = 1.6;
            K_M_C12KetoacylCoAMAT_p = 1.3;


            K_M_C10AcylCoACYT = 13.8;

            K_M_C10AcylCarCYT_s = 136;
            K_M_C10AcylCarCYT_p = 136;


            K_M_C10AcylCarMAT_s = 15;
            K_M_C10AcylCarMAT_p = 51;

            K_M_C10AcylCoAMAT_s = 38;
            K_M_C10AcylCoAMAT_p = 13.83;
            //K_M_C10AcylCoAMAT = 24.3;


            v_lcad = 0.01;
            
            K_M_C10EnoylCoAMAT_s = 1.08;
            K_M_C10EnoylCoAMAT_p = 25;

            K_M_C10HydroxyacylCoAMAT_s = 45;
            K_M_C10HydroxyacylCoAMAT_p = 8.8;

            K_M_C10KetoacylCoAMAT_s = 2.3;
            K_M_C10KetoacylCoAMAT_p = 2.1;

            K_M_C8AcylCoACYT = 13.8;
            
            K_M_C8AcylCarCYT_s = 136;
            K_M_C8AcylCarCYT_p = 136;

            K_M_C8AcylCarMAT_s = 15;
            K_M_C8AcylCarMAT_p = 51;

            K_M_C8AcylCoAMAT_s = 38;
            K_M_C8AcylCoAMAT_p = 13.83;
            //K_M_C8AcylCoAMAT = 123;

            K_M_C8EnoylCoAMAT_s = 1.08;
            K_M_C8EnoylCoAMAT_p = 25;

            K_M_C8HydroxyacylCoAMAT_s = 45;
            K_M_C8HydroxyacylCoAMAT_p = 16.3;

            K_M_C8KetoacylCoAMAT_s = 4.1;
            K_M_C8KetoacylCoAMAT_p = 3.2;

            K_M_C6AcylCoACYT = 13.8;

            K_M_C6AcylCarCYT_s = 136;
            K_M_C6AcylCarCYT_p = 15;

            K_M_C6AcylCarMAT_s = 15;
            K_M_C6AcylCarMAT_p = 51;

            K_M_C6AcylCoAMAT_s = 38;
            K_M_C6AcylCoAMAT_p = 13.83;
            //K_M_C6AcylCoAMAT = 9.4;

            v_mcad = 0.081;
            K_M_C6EnoylCoAMAT = 1.08;
            K_M_C6HydroxyacylCoAMAT = 28.6;

            K_M_C6KetoacylCoAMAT_s = 5.8;
            K_M_C6KetoacylCoAMAT_p = 6.7;

            K_M_C4AcylCoACYT = 15;

            K_M_C4AcylCarCYT_s = 15;
            K_M_C4AcylCarCYT_p = 15;

            K_M_C4AcylCarMAT_s = 15;
            K_M_C4AcylCarMAT_p = 51;

            K_M_C4AcylCoAMAT_s = 38;
            K_M_C4AcylCoAMAT_p = 13.83;
            //K_M_C4AcylCoAMAT = 135;

            K_M_C4EnoylCoAMAT_s = 40;
            K_M_C4EnoylCoAMAT_p = 1.08;

            K_M_C4HydroxyacylCoAMAT_s = 45;
            K_M_C4HydroxyacylCoAMAT_p = 69.9;

            K_M_C4AcetoacetylCoAMAT_s = 16.9;
            K_M_C4AcetoacetylCoAMAT_p = 12.4;

            rate50_const = 1.0 / 30.0 * 0.01;
            rate50_const2 = 70;


            v_cpt1 *= 20;
        }

        public FattyAcidConstantsSimplifiedSeparated(double[] array)
        {
            v_cpt1 = array[0];
            CarCYT = array[1];
            CoACYT = array[2];
            K_M_C16AcylCoACYT = array[3];
            K_M_CarCYT_s = array[4];
            K_M_CarCYT_p = array[5];
            K_M_C16AcylCarCYT_s = array[6];
            K_M_C16AcylCarCYT_p = array[7];
            K_M_CoACYT_s = array[8];
            K_M_CoACYT_p = array[9];
            v_cact = array[10];
            CarMAT = array[11];
            CarCYT = array[12];
            K_M_CarMAT_s = array[13];
            K_M_CarMAT_p = array[14];
            K_M_C16AcylCarMAT_s = array[15];
            K_M_C16AcylCarMAT_p = array[16];
            v_cpt2 = array[17];
            CoAMAT = array[18];
            CarMAT = array[19];
            K_M_CoAMAT_s = array[20];
            K_M_CoAMAT_p = array[21];
            K_M_C16AcylCoAMAT_s = array[22];
            K_M_C16AcylCoAMAT_p = array[23];
            v_vlcad = array[24];
            K_M_C16EnoylCoAMAT_s = array[25];
            K_M_C16EnoylCoAMAT_p = array[26];
            v_crot = array[27];
            K_M_C16HydroxyacylCoAMAT_s = array[28];
            K_M_C16HydroxyacylCoAMAT_p = array[29];
            v_mschad = array[30];
            K_M_C16KetoacylCoAMAT_s = array[31];
            K_M_C16KetoacylCoAMAT_p = array[32];
            K_M_C14AcylCoACYT = array[33];
            K_M_C14AcylCarCYT = array[34];
            K_M_C14AcylCarMAT_s = array[35];
            K_M_C14AcylCarMAT_p = array[36];
            K_M_C14AcylCoAMAT_s = array[37];
            K_M_C14AcylCoAMAT_p = array[38];
            v_mckat = array[39];
            CoAMAT = array[40];
            AcetylCoAMAT = array[41];
            K_M_C14EnoylCoAMAT_s = array[42];
            K_M_C14EnoylCoAMAT_p = array[43];
            K_M_C14HydroxyacylCoAMAT_s = array[44];
            K_M_C14HydroxyacylCoAMAT_p = array[45];
            C12AcylCarCYT = array[46];
            K_M_C12AcylCoACYT = array[47];
            K_M_C12AcylCarCYT = array[48];
            K_M_C12AcylCarMAT_s = array[49];
            K_M_C12AcylCarMAT_p = array[50];
            K_M_C12AcylCoAMAT_s = array[51];
            K_M_C12AcylCoAMAT_p = array[52];
            K_M_C14KetoacylCoAMAT_s = array[53];
            K_M_C14KetoacylCoAMAT_p = array[54];
            K_M_AcetylCoAMAT_s = array[55];
            K_M_AcetylCoAMAT_p = array[56];
            v_vlcad = array[57];
            K_M_C12EnoylCoAMAT_s = array[58];
            K_M_C12EnoylCoAMAT_p = array[59];
            K_M_C12HydroxyacylCoAMAT_s = array[60];
            K_M_C12HydroxyacylCoAMAT_p = array[61];
            K_M_C12KetoacylCoAMAT_s = array[62];
            K_M_C12KetoacylCoAMAT_p = array[63];
            K_M_C10AcylCoACYT = array[64];
            K_M_C10AcylCarCYT_s = array[65];
            K_M_C10AcylCarCYT_p = array[66];
            K_M_C10AcylCarMAT_s = array[67];
            K_M_C10AcylCarMAT_p = array[68];
            K_M_C10AcylCoAMAT_s = array[69];
            K_M_C10AcylCoAMAT_p = array[70];
            v_lcad = array[71];
            K_M_C10EnoylCoAMAT_s = array[72];
            K_M_C10EnoylCoAMAT_p = array[73];
            K_M_C10HydroxyacylCoAMAT_s = array[74];
            K_M_C10HydroxyacylCoAMAT_p = array[75];
            K_M_C10KetoacylCoAMAT_s = array[76];
            K_M_C10KetoacylCoAMAT_p = array[77];
            K_M_C8AcylCoACYT = array[78];
            K_M_C8AcylCarCYT_s = array[79];
            K_M_C8AcylCarCYT_p = array[80];
            K_M_C8AcylCarMAT_s = array[81];
            K_M_C8AcylCarMAT_p = array[82];
            K_M_C8AcylCoAMAT_s = array[83];
            K_M_C8AcylCoAMAT_p = array[84];
            K_M_C8EnoylCoAMAT_s = array[85];
            K_M_C8EnoylCoAMAT_p = array[86];
            K_M_C8HydroxyacylCoAMAT_s = array[87];
            K_M_C8HydroxyacylCoAMAT_p = array[88];
            K_M_C8KetoacylCoAMAT_s = array[89];
            K_M_C8KetoacylCoAMAT_p = array[90];
            K_M_C6AcylCoACYT = array[91];
            K_M_C6AcylCarCYT_s = array[92];
            K_M_C6AcylCarCYT_p = array[93];
            K_M_C6AcylCarMAT_s = array[94];
            K_M_C6AcylCarMAT_p = array[95];
            K_M_C6AcylCoAMAT_s = array[96];
            K_M_C6AcylCoAMAT_p = array[97];
            v_mcad = array[98];
            K_M_C6EnoylCoAMAT = array[99];
            K_M_C6HydroxyacylCoAMAT = array[100];
            K_M_C6KetoacylCoAMAT_s = array[101];
            K_M_C6KetoacylCoAMAT_p = array[102];
            K_M_C4AcylCoACYT = array[103];
            K_M_C4AcylCarCYT_s = array[104];
            K_M_C4AcylCarCYT_p = array[105];
            K_M_C4AcylCarMAT_s = array[106];
            K_M_C4AcylCarMAT_p = array[107];
            K_M_C4AcylCoAMAT_s = array[108];
            K_M_C4AcylCoAMAT_p = array[109];
            K_M_C4EnoylCoAMAT_s = array[110];
            K_M_C4EnoylCoAMAT_p = array[111];
            K_M_C4HydroxyacylCoAMAT_s = array[112];
            K_M_C4HydroxyacylCoAMAT_p = array[113];
            K_M_C4AcetoacetylCoAMAT_s = array[114];
            K_M_C4AcetoacetylCoAMAT_p = array[115];
            rate50_const = array[116];
            rate50_const2 = array[117];
        }

        public IConstants CreateNew(double[] array)
        {
            return new FattyAcidConstantsSimplifiedSeparated(array);
        }

        public IConstants CreateOriginalConsts()
        {
            return new FattyAcidConstantsSimplifiedSeparated();
        }

        public double[] GetState()
        {
            return new double[]
            {
                v_cpt1,
            CarCYT,
            CoACYT,
            K_M_C16AcylCoACYT,
            K_M_CarCYT_s,
            K_M_CarCYT_p,
            K_M_C16AcylCarCYT_s,
            K_M_C16AcylCarCYT_p,
            K_M_CoACYT_s,
            K_M_CoACYT_p,
            v_cact,
            CarMAT,
            CarCYT,
            K_M_CarMAT_s,
            K_M_CarMAT_p,
            K_M_C16AcylCarMAT_s,
            K_M_C16AcylCarMAT_p,
            v_cpt2,
            CoAMAT,
            CarMAT,
            K_M_CoAMAT_s,
            K_M_CoAMAT_p,
            K_M_C16AcylCoAMAT_s,
            K_M_C16AcylCoAMAT_p,
            v_vlcad,
            K_M_C16EnoylCoAMAT_s,
            K_M_C16EnoylCoAMAT_p,
            v_crot,
            K_M_C16HydroxyacylCoAMAT_s,
            K_M_C16HydroxyacylCoAMAT_p,
            v_mschad,
            K_M_C16KetoacylCoAMAT_s,
            K_M_C16KetoacylCoAMAT_p,
            K_M_C14AcylCoACYT,
            K_M_C14AcylCarCYT,
            K_M_C14AcylCarMAT_s,
            K_M_C14AcylCarMAT_p,
            K_M_C14AcylCoAMAT_s,
            K_M_C14AcylCoAMAT_p,
            v_mckat,
            CoAMAT,
            AcetylCoAMAT,
            K_M_C14EnoylCoAMAT_s,
            K_M_C14EnoylCoAMAT_p,
            K_M_C14HydroxyacylCoAMAT_s,
            K_M_C14HydroxyacylCoAMAT_p,
            C12AcylCarCYT,
            K_M_C12AcylCoACYT,
            K_M_C12AcylCarCYT,
            K_M_C12AcylCarMAT_s,
            K_M_C12AcylCarMAT_p,
            K_M_C12AcylCoAMAT_s,
            K_M_C12AcylCoAMAT_p,
            K_M_C14KetoacylCoAMAT_s,
            K_M_C14KetoacylCoAMAT_p,
            K_M_AcetylCoAMAT_s,
            K_M_AcetylCoAMAT_p,
            v_vlcad,
            K_M_C12EnoylCoAMAT_s,
            K_M_C12EnoylCoAMAT_p,
            K_M_C12HydroxyacylCoAMAT_s,
            K_M_C12HydroxyacylCoAMAT_p,
            K_M_C12KetoacylCoAMAT_s,
            K_M_C12KetoacylCoAMAT_p,
            K_M_C10AcylCoACYT,
            K_M_C10AcylCarCYT_s,
            K_M_C10AcylCarCYT_p,
            K_M_C10AcylCarMAT_s,
            K_M_C10AcylCarMAT_p,
            K_M_C10AcylCoAMAT_s,
            K_M_C10AcylCoAMAT_p,
            v_lcad,
            K_M_C10EnoylCoAMAT_s,
            K_M_C10EnoylCoAMAT_p,
            K_M_C10HydroxyacylCoAMAT_s,
            K_M_C10HydroxyacylCoAMAT_p,
            K_M_C10KetoacylCoAMAT_s,
            K_M_C10KetoacylCoAMAT_p,
            K_M_C8AcylCoACYT,
            K_M_C8AcylCarCYT_s,
            K_M_C8AcylCarCYT_p,
            K_M_C8AcylCarMAT_s,
            K_M_C8AcylCarMAT_p,
            K_M_C8AcylCoAMAT_s,
            K_M_C8AcylCoAMAT_p,
            K_M_C8EnoylCoAMAT_s,
            K_M_C8EnoylCoAMAT_p,
            K_M_C8HydroxyacylCoAMAT_s,
            K_M_C8HydroxyacylCoAMAT_p,
            K_M_C8KetoacylCoAMAT_s,
            K_M_C8KetoacylCoAMAT_p,
            K_M_C6AcylCoACYT,
            K_M_C6AcylCarCYT_s,
            K_M_C6AcylCarCYT_p,
            K_M_C6AcylCarMAT_s,
            K_M_C6AcylCarMAT_p,
            K_M_C6AcylCoAMAT_s,
            K_M_C6AcylCoAMAT_p,
            v_mcad,
            K_M_C6EnoylCoAMAT,
            K_M_C6HydroxyacylCoAMAT,
            K_M_C6KetoacylCoAMAT_s,
            K_M_C6KetoacylCoAMAT_p,
            K_M_C4AcylCoACYT,
            K_M_C4AcylCarCYT_s,
            K_M_C4AcylCarCYT_p,
            K_M_C4AcylCarMAT_s,
            K_M_C4AcylCarMAT_p,
            K_M_C4AcylCoAMAT_s,
            K_M_C4AcylCoAMAT_p,
            K_M_C4EnoylCoAMAT_s,
            K_M_C4EnoylCoAMAT_p,
            K_M_C4HydroxyacylCoAMAT_s,
            K_M_C4HydroxyacylCoAMAT_p,
            K_M_C4AcetoacetylCoAMAT_s,
            K_M_C4AcetoacetylCoAMAT_p,
            rate50_const,
            rate50_const2,
        };
        }
    }
}
