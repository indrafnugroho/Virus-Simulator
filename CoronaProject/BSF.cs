using System;
using Entity;
using ReadFile;
using System.Collections.Generic;
using System.Collections;

namespace AlgCompute
{
    public class BFS
    {
        static Queue<Tuple<char,char>> ProcessQ= new Queue<Tuple<char,char>>(); //Queue <From, To>(City) that will processed

        public static void addAdjToQueue(Vertex V) //add all candidate Tuple to Queue
        {
            Dictionary<char, Tuple<bool, double>>.KeyCollection Target = V.neighbors.Keys; // Mapping Keys of neighbors that is destination Target
            char From = V.city.ID; //From City
            foreach(char To in Target)
            {
                BFS.ProcessQ.Enqueue(new Tuple<char, char>(From,To)); //add <From, To>(Queue) to Queue
            }
        }
            
        public static bool IsInfected(Vertex V, char to, int currentTime) //Check that the destination Target is being infected or not
        {
            double I = V.city.infectedPopulation(currentTime - V.city.day); //Calculate I
            double S = I * V.neighbors[to].Item2;//I * Tr(From, to) From = V.city.ID
            if(S>1) //Infected
            {
                return true;
            }
            return false;
        }

        public static void BFSCompute(int days, char Infected)
        {
            //Declare temp Var
            Tuple<char, char> CurrTuple;

            Graph Map = ReadFromFile.province; //Take Graph fromFile
            //init status
            Map.vertices[Infected].city.day = 0;

            for(int i = 1; i <= days; i++) //i represent day Status
            {
                //init Queue
                BFS.addAdjToQueue(Map.vertices[Infected]); //Queue must be initialized each enumeration
                //BFS
                while (BFS.ProcessQ.Count>0) //while Queue not Empty
                {
                    CurrTuple = BFS.ProcessQ.Dequeue();//get tuple of <From, To> , "From" is Infected
                    if (BFS.IsInfected(Map.vertices[CurrTuple.Item1],CurrTuple.Item2,i)) //Target Infected
                    {
                        if(!Vertex.IsInfected(Map.vertices[CurrTuple.Item2])) 
                        {
                            BFS.addAdjToQueue(Map.vertices[CurrTuple.Item2]); //add new Path to Queue
                            Map.vertices[CurrTuple.Item2].city.day = i; //Assign the Day that its get Infected
                        }
                        //if the city is already Infected, its path never processed again
                        double temp = Map.vertices[CurrTuple.Item1].neighbors[CurrTuple.Item2].Item2;//temp for Tr
                        Map.vertices[CurrTuple.Item1].neighbors[CurrTuple.Item2] = new Tuple<bool, double>(true,temp);//assign true to its edge, sign of infecting path 
                    }
                }
                BFS.ProcessQ.Clear();
            }
        }
        public static void printSol(int time)
        {
            Graph Map = ReadFromFile.province; //Take Graph fromFile
            Dictionary<char, Vertex>.ValueCollection Verteks = Map.vertices.Values;
            ArrayList SolList = new ArrayList();
            foreach (Vertex val in Verteks)
            {
                if (val.city.day >= 0)
                {
                    Dictionary<char, Tuple<bool, double>>.KeyCollection neighbor = val.neighbors.Keys;
                    foreach (char key in neighbor)
                    {
                        if(!SolList.Contains(val.city.ID))
                        {
                            SolList.Add(val.city.ID);
                        }
                        double S = val.city.infectedPopulation(time - val.city.day)* val.neighbors[key].Item2;
                        Console.Write($"{val.city.ID}=({val.neighbors[key].Item2})=>{key}, S = {S}");
                        Console.WriteLine();
                    }
                    Console.WriteLine("Switch City");
                }
            }
            Console.WriteLine("The City that infected ");
            for(int i = 0; i < SolList.Count; i++)
            {
                if(i==0)
                {
                    Console.Write(SolList[i]);
                }
                else
                {
                    Console.Write($"=>{SolList[i]}");
                }
            }
        }
    }
}