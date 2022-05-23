using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FattyAcidsOxidation
{
    public class FattyAcidStateSimulationSettings
    {
        public FattyAcidState InitialState;
        public Func<IConstants, IComputer> GenerateComputerFn;
        public IConstants Constants;
        public int SimulationSteps;
        public int StepsPerSave;
        public int Cells;
        public bool ComputeAverageSeries;
        public bool GenerateReport;
        public string ExperimentPath;
        public bool SaveExperiments;
        public bool ComputeRates;
        public bool SaveAggregatedSeries = true;
        public bool SaveAggregatedSeriesStd = true;
        public double NoiseAmplitude;

        public FattyAcidStateSimulationSettings(Func<IConstants, IComputer> generateComputerFn, FattyAcidState initialState, IConstants constants, double noiseAmplitude)
        {
            this.GenerateComputerFn = generateComputerFn;
            this.InitialState = initialState;
            this.Constants = constants;
            this.NoiseAmplitude = noiseAmplitude;
        }

        public string ReportPath() => Path.Combine(ExperimentPath, "report.txt");
        public string ReportRatesPath() => Path.Combine(ExperimentPath, "rates_report.txt");
        public void GenerateAndSaveReport(List<FattyAcidState> averaged_result, IConstants consts)
        {
            int chars_per_header_item = 30;
            string p(double a) => Math.Round(a, 5).ToString("0.00000");

            var start = averaged_result.First().GetState();
            var end = averaged_result.Last().GetState();
            var header = FattyAcidState.GetHeader();

            int middle_index = averaged_result.Count / 2;
            var middle = averaged_result[middle_index].GetState();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < header.Length; i++)
            {
                var linebreak = i < header.Length - 1 ? "\r\n" : "";

                string spaces = "";
                for (int j = 0; j < chars_per_header_item - header[i].Length; j++)
                    spaces += " ";

                sb.Append($"{header[i]}{spaces}: End: {p(end[i])} Middle: {p(middle[i])}, Start: {p(start[i])}{linebreak}");
            }

            using (var writer = new StreamWriter(ReportPath()))
            {
                writer.Write(sb.ToString());
            }

            if (ComputeRates)
                GenerateAndSaveRatesReport(averaged_result, consts);
        }

        public void GenerateAndSaveRatesReport(List<FattyAcidState> averaged_result, IConstants consts)
        {

            int chars_per_header_item = 30;
            string p(double a) => a > 0 ? Math.Round(a, 5).ToString("0.00000") : Math.Round(a, 5).ToString("0.0000");


            double[] c(FattyAcidState a)
            {
                var cc = GenerateComputerFn(consts);
                cc.SetCurrentState(a);
                return cc.GetRates();
            }

            var start = c(averaged_result.First());
            var end = c(averaged_result.Last());
            int middle_index = averaged_result.Count / 2;
            var middle = c(averaged_result[middle_index]);

            var header = GenerateComputerFn(consts).GetRatesNames();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < header.Length; i++)
            {
                var linebreak = i < header.Length - 1 ? "\r\n" : "";

                string spaces = "";
                for (int j = 0; j < chars_per_header_item - header[i].Length; j++)
                    spaces += " ";

                sb.Append($"{header[i]}{spaces}: End: {p(end[i])} Middle: {p(middle[i])}, Start: {p(start[i])}{linebreak}");
            }

            using (var writer = new StreamWriter(ReportRatesPath()))
            {
                writer.Write(sb.ToString());
            }
        }

        public void SaveAveragedSeries(List<FattyAcidState> averaged_state, IConstants consts)
        {
            var path = Path.Combine(this.ExperimentPath, "averaged_series.csv");
            var header = FattyAcidState.GetHeader();

            var tosave = averaged_state.Select(x => x.GetState()).ToList();

            SaveCsvFile(path, header, tosave);

            if (SaveAggregatedSeries)
            {
                var aggregated_path = Path.Combine(this.ExperimentPath, "averaged_aggregated_series.csv");
                var aggregated_to_save = averaged_state.Select(x => x.GetAggregatedState()).ToList();
                SaveCsvFile(aggregated_path, FattyAcidState.AggregatedStateHeader, aggregated_to_save);
            }

            if (ComputeRates)
            {
                var rates_path = Path.Combine(this.ExperimentPath, "averaged_series_rates.csv");
                SaveRatesCsvFile(rates_path, averaged_state, consts);
            }
        }

        public void SaveAggregatedSeriesStandardDeviation(List<List<FattyAcidState>> results)
        {
            var stds = new List<double[]>();
            for (int i = 0; i < results.First().Count; i++)
            {
                var samples = results.Select(x => x[i].GetAggregatedState()).ToList();
                var avg = samples.Aggregate((a, b) => a.Zip(b, (x, y) => x + y).ToArray());
                avg = avg.Select(x => x / (double)(samples.Count)).ToArray();

                var std = new double[avg.Length];
                for(int j = 0; j < samples.Count; j++)
                {
                    var sample = samples[j];
                    for(int k = 0; k < sample.Length; k++)
                    {
                        std[k] += Math.Pow(sample[k] - avg[k], 2);
                    }
                }

                for (int j = 0; j < std.Length; j++)
                    std[j] /= (double)(samples.Count);

                stds.Add(std);
                
            }

            var aggregated_path_std = Path.Combine(this.ExperimentPath, "averaged_aggregated_series_std.csv");
            SaveCsvFile(aggregated_path_std, FattyAcidState.AggregatedStateHeader, stds);
        }

        public void SaveIndividualSimulations(Dictionary<int, List<FattyAcidState>> results, IConstants consts)
        {
            var path = Path.Combine(ExperimentPath, "individual simulations");
            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);

            var header = FattyAcidState.GetHeader();

            foreach (var key_value in results)
            {
                var p = Path.Combine(path, $"{key_value.Key.ToString()}.csv");
                SaveCsvFile(p, header, key_value.Value.Select(x => x.GetState()).ToList());
            }

            if (ComputeRates)
            {
                var rates_path = Path.Combine(ExperimentPath, "individual simulations rates");
                if (Directory.Exists(rates_path) == false)
                    Directory.CreateDirectory(rates_path);

                foreach (var key_value in results)
                {
                    var p = Path.Combine(rates_path, $"{key_value.Key.ToString()}.csv");
                    SaveRatesCsvFile(p, key_value.Value, consts);
                }
            }
        }
        public void SaveRatesCsvFile(string path, List<FattyAcidState> states, IConstants consts)
        {
            var rates = states
                .Select(x =>
                {
                    var c = GenerateComputerFn(consts);
                    c.SetCurrentState(x);
                    return c.GetRates();
                })
                .ToList();

            var header = GenerateComputerFn(consts).GetRatesNames();
            SaveCsvFile(path, header, rates);
        }
        public void SaveCsvFile(string path, string[] headerArray, List<double[]> states)
        {
            StringBuilder sb = new StringBuilder();
            var header = headerArray.Aggregate((a, b) => $"{a};{b}");

            sb.Append($"{header}\r\n");

            for (int i = 0; i < states.Count; i++)
            {
                var linebreak = i < states.Count - 1 ? "\r\n" : "";

                var line = states[i]
                    .Select(x => x.ToString().Replace(',', '.'))
                    .Aggregate((a, b) => $"{a};{b}");

                sb.Append($"{line}{linebreak}");
            }

            using (var writer = new StreamWriter(path))
            {
                writer.Write(sb.ToString());
            }
        }
    }
}
