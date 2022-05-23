using FattyAcidsOxidation.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FattyAcidsOxidation
{
    public class FattyAcidGeneticAlgorithm
    {
        private FattyAcidGeneticAlgorithmSettings settings;
        private double rise_up = 0;
        Random b = new Random();

        private bool random_bool() => b.NextDouble() > 0.5;
        private double rand_mutation_magnitude() => b.NextDouble() * 2 - 1;

        private double geometric_random()
        {
            try
            {
                var a = b.NextDouble() * 2 - 1;
                var sign = a > 0 ? 1 : -1;
                a = Math.Abs(a);

                double mantis = Math.Pow(10, sign * Math.Log2(a));

                double cecha = b.Next(0, 10);
                double result = cecha * mantis;

                return result;
            }
            catch (Exception)
            {
                return geometric_random();
            }
        }

        private bool rand_mutation() => b.NextDouble() < settings.MutationChance;
        private int rand_parent_index(int max) => b.Next(0, max);

        public FattyAcidGeneticAlgorithm(FattyAcidGeneticAlgorithmSettings settings)
        {
            this.settings = settings;
        }

        private List<Entry> getBestStoredChromosomes<T>() where T : IConstants
        {
            var folder_name = Directory.GetDirectories(this.settings.PathToFolder)
                    .Select(x => Path.GetFileName(x))
                    .OrderByDescending(x => double.Parse(x))
                    .First();

            var best_saved_path = Path.Combine(this.settings.PathToFolder, folder_name);
            var chromosomes = Directory.GetFiles(best_saved_path)
                .Select(x => (name: Path.GetFileNameWithoutExtension(x), json: File.ReadAllText(x)))
                .Select(x => (name: x.name, c: JsonConvert.DeserializeObject<T>(x.json)))
                .Select(x => new Entry() { Chromosome = x.c, Run = null, Score = double.Parse(x.name) })
                .ToList();

            return chromosomes;
        }

        public T GetBestStoredChromosome<T>() where T : IConstants
        {
            var chromosomes = getBestStoredChromosomes<T>();
            var best = chromosomes.OrderByDescending(x => x.Score).First();

            var casted = (T)(best.Chromosome);
            return casted;
        }

        public void Run<T>() where T : IConstants
        {
            List<Entry> chromosomes = new List<Entry>();
            List<Entry> computed_chromosomes = new List<Entry>();
            double best_score_in_population = double.MinValue;

            // population initialization
            if (settings.RunBest && Directory.GetDirectories(this.settings.PathToFolder).Length > 0)
            {
                computed_chromosomes = getBestStoredChromosomes<T>();

                var to_add = Enumerable.Range(0, settings.Agents)
                    .Select(x => reproduce(computed_chromosomes[rand_parent_index(computed_chromosomes.Count)].Chromosome, computed_chromosomes[rand_parent_index(computed_chromosomes.Count)].Chromosome))
                    .Select(x=> new Entry() { Chromosome = x, Run = null, Score = double.MinValue})
                    .ToList();

                chromosomes = to_add;
            }
            else
            {
                chromosomes = Enumerable.Range(0, settings.Agents)
                    .Select(x => reproduce(settings.Consts, settings.Consts))
                    .Select(x => new Entry() { Chromosome = x, Score = double.MinValue, Run = null })
                    .ToList();
            }

            //experiment loop
            for(int epoch = 0; epoch < settings.Epochs; epoch++)
            {
                var current_population = new List<Entry>();

                // evaluate chromosomes
                chromosomes.AsParallel()
                    .ForAll(x => {
                        var evaluation = EvaluateAggregated(x.Chromosome);
                        current_population.Add(evaluation);
                    });

                chromosomes = current_population;

                // filter unwanted
                computed_chromosomes = chromosomes
                    .Concat(computed_chromosomes)
                    .OrderByDescending(x => x.Score)
                    .Take(settings.AgentsForReproduction)
                    .ToList();

                chromosomes.Clear();


                // save fitlered ones (if they were better than previous ones)
                if(best_score_in_population < computed_chromosomes[0].Score)
                {
                    rise_up = 0;

                    best_score_in_population = computed_chromosomes[0].Score;
                    string path = Path.Combine(settings.PathToFolder, best_score_in_population.ToString());
                    
                    if(Directory.Exists(path) == false)
                    {
                        Directory.CreateDirectory(path);

                        computed_chromosomes.ForEach(x => {
                            var json = JsonConvert.SerializeObject(x.Chromosome);
                            var chr_path = Path.Combine(path, $"{x.Score}.json");
                            File.WriteAllText(chr_path, json);
                        });

                        string best_chr_path = Path.Combine(path, "best_one_results");
                        Directory.CreateDirectory(best_chr_path);

                        var ss = new FattyAcidStateSimulationSettings(settings.GenerateComputerFn, settings.InitialState, computed_chromosomes[0].Chromosome, noiseAmplitude: 0)
                        {
                            ComputeRates = true,
                            ExperimentPath = best_chr_path,
                            Cells = 1,
                            GenerateReport = true,
                            SaveExperiments = true,
                            SaveAggregatedSeries = true
                        };

                        ss.GenerateAndSaveReport(computed_chromosomes[0].Run, computed_chromosomes[0].Chromosome);
                        ss.SaveAveragedSeries(computed_chromosomes[0].Run, computed_chromosomes[0].Chromosome);
                    }

                }
                else
                {
                    rise_up += settings.RiseUpIncrement;
                    Console.WriteLine($"Rise up: {rise_up}");
                }

                // presents results on the screen
                Console.WriteLine($"EPOCH: {epoch + 1}");
                computed_chromosomes.ForEach(x => Console.WriteLine(x.Score));
                Console.WriteLine();

                // repopulate
                var reproduced = Enumerable.Range(0, settings.Agents)
                    .Select(x => reproduce(computed_chromosomes[rand_parent_index(computed_chromosomes.Count)].Chromosome, computed_chromosomes[rand_parent_index(computed_chromosomes.Count)].Chromosome))
                    .Select(x=> new Entry()
                    {
                        Chromosome = x,
                        Run = null,
                        Score = double.MinValue
                    })
                    .ToList();

                chromosomes = reproduced;
            }
        }

        private class Entry
        {
            public IConstants Chromosome { get; set; }
            public double Score { get; set; }
            public List<FattyAcidState> Run { get; set; }
            
        }

        public IConstants reproduce(IConstants f1, IConstants f2)
        {
            IConstants f3 = null;
            do
            {
                f3 = attempt_reproduce(f1, f2);
            }
            while (f3 == null);
            return f3;
        }

        private IConstants attempt_reproduce(IConstants f1, IConstants f2)
        {

            var a1 = f1.GetState();
            var a2 = f2.GetState();

            var a3 = a1.Zip(a2, (a, b) => random_bool() ? a : b);

            // no weight can differ more than 100 times from the original
            double mutate_unti(double x, double original)
            {
                double new_x = x;
                while (true)
                {
                    var mutation_value = 1 + settings.MutationMagnitude * rand_mutation_magnitude();
                    if (mutation_value <= 0)
                        continue;

                    new_x = x * mutation_value;

                    var diff = Math.Max(new_x, original) / Math.Min(new_x, original);

                    if (diff < 1000000)
                        break;
                }

                return new_x;
            }

            var original = f1.CreateOriginalConsts().GetState();
            a3 = a3.Zip(original, (x,o) => rand_mutation() ? mutate_unti(x,o) : x);

            return f1.CreateNew(a3.ToArray());
        }
        private Entry Evaluate(IConstants chromosome)
        {
            var st = new FattyAcidStateSimulationSettings(settings.GenerateComputerFn, settings.InitialState, chromosome, noiseAmplitude: 0)
            {
                SimulationSteps = settings.SimulationSteps,
                StepsPerSave = settings.SimulationStepsPerSave
            };

            var run = FattyAcidStateSimulation.SimulateOneCell(st);

            var maxes = Enumerable.Range(0,run.First().GetState().Length)
                .Select(x => run.Select(y => y.GetState()[x]).Max())
                .ToArray();

            var mins = Enumerable.Range(0, run.First().GetState().Length)
                .Select(x => run.Select(y => y.GetState()[x]).Min())
                .ToArray();

            var ranges = maxes.Zip(mins, (a, b) => Math.Abs(a - b)).ToList();

            var avg = run
                .TakeLast(100)
                .Select(x => x.GetState())
                .Aggregate((a, b) => a.Zip(b, (x, y) => x + y).ToArray())
                .Select(x => x / 100)
                .ToArray();

            // measuring how many averaged signals are above 100 delta
            var above_threshold_score = avg.Select(x => x > 100 * FattyAcidStateComputerSimplifiedSeparated.delta ? 1 : x / (100 * FattyAcidStateComputerSimplifiedSeparated.delta)).Sum();

            // measuring average of the signal in the 50% of the run
            var p50_avg = run
                .Skip((int)(run.Count * 0.5))
                .Take(100)
                .Select(x => x.GetState())
                .Aggregate((a, b) => a.Zip(b, (x, y) => x + y).ToArray())
                .Select(x => x / 100)
                .ToArray();

            // measuring difference between mean state at 50% time and end mean
            double mape_max(double a, double b) => Math.Abs(a - b) / Math.Max(a, b);


            double penalty_for_zero_in_half = 1000;
            //var diff = p50_avg.Zip(avg, (a, b) => a > 0 ? Math.Pow(mape_max(a,b), 2) : penalty_for_zero_in_half).Sum();

            var diffs = p50_avg.Zip(avg, (a, b) => (middle: a, end: b))
                .Zip(ranges, (a, b) => (range: b, middle: a.middle, end: a.end))
                .Select(x => x.range == 0 ? (x.end > 0 ? 0 : penalty_for_zero_in_half) : Math.Pow((x.end - x.middle) / x.range, 2))
                .ToArray();
                
            var diff = diffs.Sum();

            // measuring distance from start to finish only for these, that actually have something during start
            //var start_diff = run.First().GetState().Zip(avg, (a,b) => a > 0 ? Math.Abs(b-a) / a : 0).Sum();

            var level_dropped = run.First().GetState().Zip(avg, (a, b) => b >= a ? 0 : Math.Pow(mape_max(a,b), 2)).Sum();

            var score = above_threshold_score - diff - level_dropped; // - start_diff;

            return new Entry()
            {
                Chromosome = chromosome,
                Run = run,
                Score = score
            };
        }

        private Entry EvaluateAggregated(IConstants chromosome)
        {
            var st = new FattyAcidStateSimulationSettings(settings.GenerateComputerFn, settings.InitialState, chromosome, noiseAmplitude: 0)
            {
                SimulationSteps = settings.SimulationSteps,
                StepsPerSave = settings.SimulationStepsPerSave
            };

            var run = FattyAcidStateSimulation.SimulateOneCell(st);


            double[] avg(IEnumerable<FattyAcidState> states)
            {
                return states
                    .Select(x => x.GetAggregatedState())
                    .Aggregate((a, b) => a.Zip(b, (x, y) => x + y).ToArray())
                    .Select(x => x / 100)
                    .ToArray();
            }

            var samples_to_one_third = (int)(run.Count / 3);
            var avg_one_third = avg(run.Skip(samples_to_one_third).Take(100));
            //var samples_to_three_fourth = (int)(0.75 * run.Count);
            //var three_fourth = run.Take(samples_to_three_fourth)
            //    .Select(x => x.GetAggregatedState())
            //    .ToList();

            //var maxes = new double[three_fourth.First().Length];
            //for(int i = 0; i < maxes.Length; i++)
            //{
            //    maxes[i] = three_fourth.Select(x => x[i]).Max();
            //}
                
            var avg_end = avg(run.TakeLast(100));


            var required_steps_one_third = new double[]
            {
                0.75,
                0.16,
                0.16,
                0.08,
                0.22,
                0.28,
                0.01
            };

            var required_steps_end = new double[]
            {
                0.22,
                0.04,
                0.16,
                0.04,
                0.18,
                0.50,
                0.04
            };

            var distances_one_third = avg_one_third
                .Zip(required_steps_one_third, (a, b) => Math.Pow((a - b) / b, 2))
                .Sum();

            var distances_end = avg_end
                .Zip(required_steps_end, (a, b) => Math.Pow((a - b) / b, 2))
                .Sum();

            var sum_one_third = avg_one_third.Sum();
            var sum_one_third_expected = required_steps_one_third.Sum();

            var sum_end = avg_end.Sum();
            var sum_end_expected = required_steps_end.Sum();

            var distance_sum_one_third = Math.Pow((sum_one_third - sum_one_third_expected) / sum_one_third_expected, 2);
            var distance_sum_end = Math.Pow((sum_end - sum_end_expected) / sum_end_expected, 2);

            var score = -1 * (distances_one_third + distances_end);
            //var score = -1 * (distance_sum_one_third + distance_sum_end);

            return new Entry()
            {
                Chromosome = chromosome,
                Run = run,
                Score = score
            };
        }
    }

    public class FattyAcidGeneticAlgorithmSettings
    {
        public string PathToFolder { get; set; }
        public int Agents { get; set; }
        public int AgentsForReproduction { get; set; }
        public bool SaveBestAgentPerformance { get; set; } = true;
        public int Epochs { get; set; }
        public double MutationChance { get; set; }
        public double MutationMagnitude { get; set; }
        public bool RunBest { get; set; } = false;
        public FattyAcidState InitialState { get; set; }
        public IConstants Consts { get; set; }
        public Func<IConstants, IComputer> GenerateComputerFn { get; set; }
        public int SimulationSteps { get; set; }
        public int SimulationStepsPerSave { get; set; }
        public double RiseUpIncrement { get; set; }

        public FattyAcidGeneticAlgorithmSettings(
            Func<IConstants, IComputer> generate_computer_fn, 
            string pathToFolder, 
            int agents, 
            int agentsForReproduction, 
            bool saveBestAgentPerformance, 
            int epochs, 
            double mutationChance, 
            double mutationMagnitude, 
            bool runBest, 
            FattyAcidState initialState, 
            IConstants consts
            )
        {
            this.GenerateComputerFn = generate_computer_fn;
            PathToFolder = pathToFolder ?? throw new ArgumentNullException(nameof(pathToFolder));
            Agents = agents;
            AgentsForReproduction = agentsForReproduction;
            SaveBestAgentPerformance = saveBestAgentPerformance;
            Epochs = epochs;
            MutationChance = mutationChance;
            MutationMagnitude = mutationMagnitude;
            RunBest = runBest;
            InitialState = initialState;
            Consts = consts ?? new FattyAcidConstantsSimplifiedSeparated();
        }
    }
}
