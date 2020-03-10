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
            //ReadFromFile.GraphData is data which contains data of Graph

            //Init Graph

        }
    }
}
