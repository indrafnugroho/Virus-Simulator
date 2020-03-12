using System;
using System.Collections;
using Entity;
using Visualization;
using Cobavisual;
using ReadFile;
using System.Collections.Generic;
using AlgCompute;

namespace CoronaProject
{
    public class Simulation
    {
        public static void Main()
        {
            ReadFromFile.Read();
            Queue<char> QueueEdge = new Queue<char>();

            Console.Write("Input Total Days Infected: ");
            int time = Convert.ToInt32(Console.ReadLine());
            //ReadFromFile.EdgeData is data which contains Data of Edge
            //ReadFromFile.GraphData is data which contains Data of Graph

            //Init Graph G sudah di ReadFile
            ReadFromFile.province.printGraph();
            BFS.BFSCompute(time,ReadFromFile.source);
            BFS.printSol(time);

            int ppp = Convert.ToInt32(Console.ReadLine());

        }
    }
}
