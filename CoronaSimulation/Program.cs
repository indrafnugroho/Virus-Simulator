using System;
using System.Collections;
using Entity;
using ReadFile;
using System.Collections.Generic;

namespace CoronaSimulation
{
    public class Simulation
    {
        public static void Main()
        {
            ReadFromFile.Read();
            Queue<Tuple<char, char, double>> qEdge = new Queue<Tuple<char, char, double>>();

            Console.Write("Input Total Days Infected: ");
            int time = Convert.ToInt32(Console.ReadLine());
            ReadFromFile.Read();
            //ReadFromFile.EdgeData is data which contains Data of Edge
            //ReadFromFile.GraphData is data which contains Data of Graph

            //Init Graph
            Graph province = new Graph();

            for (int i = 0; i < property.nNode; i++) {
                Town T = new Town(ReadFromFile.GraphData[i].Item2, ReadFromFile.GraphData[i].Item1);                
            }


        }
    }
}
