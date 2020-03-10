using System;
using System.Collections.Generic;
namespace Entity 
{
    public class Town
    {
        const double gamma = 0.25; //gamma constants

        public int day; //day the town being infected
        public char ID; //ID of Infected
        private int population { get; set; } //population of the Town

        public Town(int p, char ID) //constructor
        {
            this.day = -1;
            this.population = p;
            this.ID = ID;
        }
        public double infectedPopulation(int time) //Compute I, or pupulation infected
        { //Logistic Func I
            return ((double)this.population / (1 + Math.Pow(Math.Exp(this.population - 1), (-1) * gamma * time)));
        }

    }
    public class Vertex
        {
            public Town city;
            public Dictionary<char, Tuple<bool,double>> neighbors; //neighbors (key = name, value = (isInfectingPath,Tr))
            public Vertex(Town City)//Constructor
            {
                this.city = City;
                this.neighbors = new Dictionary<char, Tuple<bool, double>> ();
            }
            public void addNeighbors(char key, double weight)
            {
                this.neighbors[key] = new Tuple<bool, double>(false,weight);//add neighbors and set infecting path to false
            }
            public static bool IsInfected(Vertex V) //is the Town infected
            {
                if (V.city.day >= 0)
                {
                    return true;
                }
                return false;
            }
    }
    public class Graph
    {
        public Dictionary<char, Vertex> vertices; // Vertices (key = name, value = Vertex)

        public Graph() //Constructor
        {
            this.vertices = new Dictionary<char, Vertex>();
        }
        public void addVertex(Vertex V) //AddVertex to Graph
        {
            this.vertices[V.city.ID] = V;
        }
        public void addEdge (char key, char ID, double weight) 
        {
            if(this.vertices.ContainsKey(key))
            {
                this.vertices[key].addNeighbors(ID, weight);
            }
            else
            {
                Console.WriteLine("Error Not Found");
            }
        }
        public void printGraph()
        {
            Dictionary<char,Vertex>.ValueCollection Verteks = this.vertices.Values;
            foreach(Vertex val in Verteks)
            {
                Dictionary<char, Tuple<bool, double>>.KeyCollection neighbor = val.neighbors.Keys;
                foreach (char key in neighbor)
                {
                    Console.Write($"{val.city.ID}=({val.neighbors[key].Item2})=>{key}");
                    Console.WriteLine();
                }
                Console.WriteLine("Switch");
            }
        }
        
    }
}