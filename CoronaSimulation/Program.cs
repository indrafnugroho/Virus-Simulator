using System;
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
        }
    }
}
