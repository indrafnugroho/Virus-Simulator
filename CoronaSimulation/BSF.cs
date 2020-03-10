using System;
using Entity;
using ReadFile;
using System.Collections;
using System.Collections.Generic;

namespace AlgCompute
{
    public class BFS
    {
        static Queue<Tuple<char,char>> ProcessQ= new Queue<Tuple<char,char>>(); //Queue <From, To>

        public static void addAdjToQueue(Vertex V)
        {
            Dictionary<char, Tuple<bool, double>>.KeyCollection Target = V.neighbors.Keys;
            char From = V.city.ID;
            foreach(char To in Target)
            {
                BFS.ProcessQ.Enqueue(new Tuple<char, char>(From,To)); //add <From, To>
            }
        }
            
        public static bool IsInfected(Vertex V, char to, int currentTime)
        {
            double I = V.city.infectedPopulation(currentTime - V.city.day);
            double S = I * V.neighbors[to].Item2;
            if(S>1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void BFSCompute(int days, char Infected)
        {
            //Declare temp Var
            Tuple<char, char> CurrTuple;

            Graph Map = ReadFromFile.province; //Take Graph
            //init status
            Map.vertices[Infected].city.day = 0;

            for(int i = 1; i <= days; i++) //i represent day Status
            {
                //init Queue
                BFS.addAdjToQueue(Map.vertices[Infected]);
                //BFS
                while (BFS.ProcessQ.Count>0)
                {
                    CurrTuple = BFS.ProcessQ.Dequeue();//get tuple of <From, To> and "From" is Infected
                    if(BFS.IsInfected(Map.vertices[CurrTuple.Item1],CurrTuple.Item2,i))
                    {
                        if(!Town.IsInfected(Map.vertices[CurrTuple.Item2]))
                        {
                            BFS.addAdjToQueue(Map.vertices[CurrTuple.Item2]);
                            Map.vertices[CurrTuple.Item2].city.day = i;
                        }
                        double temp = Map.vertices[CurrTuple.Item1].neighbors[CurrTuple.Item2].Item2;
                        Map.vertices[CurrTuple.Item1].neighbors[CurrTuple.Item2] = new Tuple<bool, double>(true,temp);
                    }
                } 
            }
        }
    }
}