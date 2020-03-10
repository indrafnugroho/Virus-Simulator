using System;
using System.Collections;
using Entity;
using ReadFile;

namespace CoronaSimulation
{
    public class Simulation
    {
        public static void Main()
        {
            Console.Write("Input Total Days Infected: ");
            int time = Convert.ToInt32(Console.ReadLine());
            ReadFromFile.Read();
            //ReadFromFile.EdgeData is data which contains Data of Edge
            //ReadFromFile.GraphData is data which contains data of Graph

            //Init Graph


        }
    }
}
