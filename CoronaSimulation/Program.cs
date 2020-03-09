﻿using System;
using ReadFile;

namespace CoronaSimulation
{
    public class Program
    {
        
        public static void Main()
        {
            Console.Write("Input Total Days Infected: ");
            int time = Convert.ToInt32(Console.ReadLine());
            ReadFile.ReadFromFile.Read();

            // Console.WriteLine("Hello World!");
        }

    }

    public class Town
    {
        double gamma = 0.25;

        private int year { get; set; }
        private int population { get; set; }

        Town(int y, int p)
        {
            year = y;
            population = p;
        }

        public double infectedPopulation(int time) //Logistic Func I
        {
            return ((double) population / (1 + Math.Pow(Math.Exp(population - 1), (-1) * gamma * time)));
        }

        public double virusSpread(double I, double Tr) //S
        {
            return (I * Tr);
        }

    }
}
