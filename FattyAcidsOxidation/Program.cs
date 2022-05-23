using Newtonsoft.Json;
using System;
using System.IO;

namespace FattyAcidsOxidation
{
    class Program
    {

        public static void RunGeneticAlgorithm(string path_to_chromosomes, double noiseAmplitude = 0.1, int chromosomes_count = 10, int chromosomes_for_reproduction = 4,
            int epochs = 1000, double mutation_chance = 0.1, double mutation_amplitude = 1.0, FattyAcidState? initalState = null, FattyAcidConstantsSimplifiedSeparated initialConsts = null,
            int simulationSteps = 6000000, int simulationStepsPerSave = 2000
            )
        {
            if (Directory.Exists(path_to_chromosomes) == false)
            {
                Directory.CreateDirectory(path_to_chromosomes);
            }

            var settings = new FattyAcidGeneticAlgorithmSettings(
                generate_computer_fn: (consts) => {
                    return new FattyAcidStateComputerSimplifiedSeparated(consts as FattyAcidConstantsSimplifiedSeparated, noiseAmplitude);
                },
                pathToFolder: path_to_chromosomes,
                agents: chromosomes_count,
                agentsForReproduction: chromosomes_for_reproduction,
                saveBestAgentPerformance: true,
                epochs: epochs,
                mutationChance: mutation_chance,
                mutationMagnitude: mutation_amplitude,
                runBest: true,
                initialState: initalState.HasValue ? initalState.Value : FattyAcidState.LiteratureStart(),
                consts: initialConsts != null ? initialConsts : FattyAcidConstantsSimplifiedSeparated.GetTrainedConstants()
            )
            {
                SimulationSteps = simulationSteps,
                SimulationStepsPerSave = simulationStepsPerSave
            };

            var algorithm = new FattyAcidGeneticAlgorithm(settings);
            algorithm.Run<FattyAcidConstantsSimplifiedSeparated>();
        }

        public static void RunSimulation(string experimentPath, FattyAcidConstantsSimplifiedSeparated _consts = null, double noise_amplitude = 0.1, int cells = 50, int simulationSteps = 6000000, int stepsPerSave = 2000)
        {
            var initial_state = FattyAcidState.LiteratureStart();
            var consts = _consts != null ? _consts : FattyAcidConstantsSimplifiedSeparated.GetTrainedConstants();

            var settings = new FattyAcidStateSimulationSettings(
                generateComputerFn: (consts) => {
                    return new FattyAcidStateComputerSimplifiedSeparated(consts as FattyAcidConstantsSimplifiedSeparated, noise_amplitude: noise_amplitude);
                },
                initialState: initial_state,
                constants: consts,
                noiseAmplitude: noise_amplitude
            );
            settings.Cells = cells;
            settings.ComputeAverageSeries = true;
            settings.ComputeRates = true;
            settings.ExperimentPath = experimentPath;
            settings.GenerateReport = true;
            settings.SaveExperiments = true;
            settings.SimulationSteps = simulationSteps;
            settings.StepsPerSave = stepsPerSave;

            FattyAcidStateSimulation.SimulateCells(settings);
        }
            
        static void Main(string[] args)
        {
            // running a simulation
            RunSimulation(@"[Type path to output folder here]");

            // running a genetic algorihtm for training purposes
            // RunGeneticAlgorithm(@"[Type path to output folder here]");
        }


    }
}
