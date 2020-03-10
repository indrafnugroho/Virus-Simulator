using System;
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
            Console.WriteLine(ReadFromFile.GraphData[0].Item1); //cuma nyoba akses

            //coba masukin ke queue tapi masih blm bisa akses si elemen sourcenya jadi masih coba pake A
            foreach (Tuple<char, char, double> value in ReadFromFile.GraphData.FindAll(element => (element.Item1 == 'A'))) 
            {
                qEdge.Enqueue(value);
            }

            Console.WriteLine($"isi elemen pertama : {qEdge.Dequeue().Item1} -> {qEdge.Dequeue().Item2} ");
        }
    }
}
