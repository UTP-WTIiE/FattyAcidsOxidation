# FattyAcidsOxidation

This repository contains the C# code responsible for simulation of Fatty Acids Beta-Oxidation using Queue Theory approach. The code can be used by running the FattyAcidsOxidation/Program.cs file. In this file the method "Main" is responsible for running the program.

In order to run the simulation write the path to folder where simulation output should be stored.

```
static void Main(string[] args)
        {
            // running a simulation
            RunSimulation(@"[Type path to output folder here]");

        }
```

You can modify the simulation parameters by providing them to `RunSimulation` method. The method accepts these optional parameters:

- `_consts` - customly trained constant values parametrizing the model. The trained values are used as a default.
- `noise_amplitude` - amplitude of gaussian noise applied to the simulation
- `cells` - amount of cells simulated. Each cell has its own simulation independent from others. Each cell is computed in the parallel to each other.
- `simulationSteps` - number of steps that to simulate
- `stepsPerSave` - number of simulation steps to be processed for one step to be saved. This is a mechanism preventing too high RAM consumption and available hard disk space depletion. 'stepsPerSave' equal to 1 means that all steps are saved. 'stepsPerSave' equal to 1000 means that only one step for every thousand steps is recorder.

