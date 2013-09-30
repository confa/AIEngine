﻿using System;
using FizzWare.NBuilder;
using GeneticAlgorithm;
using GeneticAlgorithm.Implementation.Common;
using GeneticAlgorithm.Interfaces;
using System.Linq;

namespace AIEngine
{
    class Program
    {
        public static GeneticAlgorithm<int> GeneticAlgorithm { get; set; }
        public const int PopulationCount = 300;
        public const int GensCount = 8;

        public Program()
        {
            IFittnessFunction<int> fittnessFunction = new ChessIntFittnessFunction();
            ICrossover<int> crossover = new IntOneDotCrossover();
            ISelection<int> selection = new RouletteIntSelection();
            IMutation<int> mutation = new IntMutation(2, 10);
            ITerminate<int> terminate = new ChessIntTerminate();
            
            GeneticAlgorithm = new GeneticAlgorithm<int>(fittnessFunction, selection, crossover, mutation, terminate);
            var generator = new UniqueRandomGenerator();

            for (var i = 0; i < PopulationCount; i++)
            {
                var chromosome = new IntChromosome();
                for (int j = 0; j < GensCount; j++)
                {
                    chromosome.Gens.Add(new IntGen(generator.Next(0, 8)));
                }
                GeneticAlgorithm.Population.Add(chromosome);
                generator.Reset();
            }
        }

        static void Main(string[] args)
        {
            var s = new Program();

            GeneticAlgorithm.StartIterations(() =>
                {
                    Console.WriteLine(GeneticAlgorithm.Population.FirstOrDefault(x => x.FittnessValue == GeneticAlgorithm.Population.Max(y => y.FittnessValue)));
                });

            Console.Read();
        }
    }
}
