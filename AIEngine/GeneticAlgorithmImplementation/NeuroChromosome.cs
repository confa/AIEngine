﻿using System.Collections.Generic;
using GeneticAlgorithm.Interfaces;
using NeuralNetworkCore;

namespace AIEngine.GeneticAlgorithmImplementation
{
    public class NeuroChromosome : IChromosome<Neuron>
    {
        public List<IGen<Neuron>> Gens { get; set; }
        public double FittnessValue { get; set; }
    }
}