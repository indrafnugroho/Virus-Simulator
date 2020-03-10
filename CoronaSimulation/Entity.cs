using System;
using System.Collections.Generic;
namespace Entity 
{
    public class Town
    {
        const double gamma = 0.25;
        public int day;
        public char ID;
        private int population { get; set; }

        public Town(int p, char ID)
        {
            this.day = -1;
            this.population = p;
            this.ID = ID;
        }
        public double infectedPopulation(int time)
        { //Logistic Func I
            return ((double)this.population / (1 + Math.Pow(Math.Exp(this.population - 1), (-1) * gamma * time)));
        }
        public static bool IsInfected(Vertex V)
        {
            if(V.city.day>=0)
            {
                return true;
            }
            return false;
        }
    }
    public class Vertex
        {
            public Town city;
            public Dictionary<char, Tuple<bool,double>> neighbors;
            public Vertex(Town City)
            {
                this.city = City;
                this.neighbors = new Dictionary<char, Tuple<bool, double>> ();
            }
            public void addNeighbors(char key, double weight)
            {
                this.neighbors[key] = new Tuple<bool, double>(false,weight);
            }
        }
    public class Graph
    {
        public Dictionary<char, Vertex> vertices;

        public Graph()
        {
            this.vertices = new Dictionary<char, Vertex>();
        }
        public void addVertex(Vertex V)
        {
            this.vertices[V.city.ID] = V;
        }
        public Vertex GetVertex(char key)
        {
            if (this.vertices.ContainsKey(key))
            {
                return this.vertices[key];
            }
            else
            {
                Console.WriteLine("Not Found");
            }
            return null;
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