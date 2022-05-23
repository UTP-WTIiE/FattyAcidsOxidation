using FattyAcidsOxidation.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FattyAcidsOxidation
{
    public static class FattyAcidStateSimulation
    {
        public static List<FattyAcidState> SimulateOneCell(FattyAcidStateSimulationSettings parameters)
        {
            IComputer computer = parameters.GenerateComputerFn(parameters.Constants);

            Random b = new Random();
            var stateArray = parameters.InitialState.GetState().Select(x => x * (1.0 + parameters.NoiseAmplitude * b.NextGaussian())).ToArray();
            var noisedState = new FattyAcidState(stateArray);

            computer.SetCurrentState(noisedState);

            var list = new List<FattyAcidState>();

            for(int i = 0; i < parameters.SimulationSteps; i++)
            {
                if (i == 160000000)
                    i += 0;

                var result = computer.ComputeQueues();

                if (i % parameters.StepsPerSave == 0)
                    list.Add(result);
            }

            // test purposes only
            var a = computer.ComputeQueues();

            return list;
        }

        public static FattyAcidStateSimulationResult SimulateCells(FattyAcidStateSimulationSettings settings)
        {
            Dictionary<int, List<FattyAcidState>> results = new Dictionary<int, List<FattyAcidState>>();
            Enumerable.Range(0, settings.Cells)
                .AsParallel()
                .ForAll(x =>
                {
                    var result = SimulateOneCell(settings);
                    results.Add(x, result);
                });

            if (settings.SaveExperiments)
                settings.SaveIndividualSimulations(results, settings.Constants);

            List<FattyAcidState> averaged_result = null;

            if (settings.ComputeAverageSeries)
            {
                averaged_result = new List<FattyAcidState>();
                for(int i = 0; i < results.Values.First().Count; i++)
                {
                    var samples = results.Values.Select(x => x[i].GetState()).ToList();
                    var avg = samples.Aggregate((a, b) => a.Zip(b, (x, y) => x + y).ToArray());
                    avg = avg.Select(x => x / (double)(samples.Count)).ToArray();
                    averaged_result.Add(new FattyAcidState(avg));
                }

                if (settings.GenerateReport)
                    settings.GenerateAndSaveReport(averaged_result, settings.Constants);

                if (settings.SaveExperiments)
                {
                    settings.SaveAveragedSeries(averaged_result, settings.Constants);

                    if (settings.SaveAggregatedSeriesStd)
                        settings.SaveAggregatedSeriesStandardDeviation(results.Values.ToList());

                }


            }

            return new FattyAcidStateSimulationResult()
            {
                Averaged = averaged_result,
                Results = results
            };
        }
    }

    
}
