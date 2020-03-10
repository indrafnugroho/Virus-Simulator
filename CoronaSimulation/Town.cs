using System;
using System.Collections.Generic;
namespace Entity 
{
    public class Town
    {
        const double gamma = 0.25;
        private int day { get; set; }
        public char ID;
        private int population { get; set; }
        public bool isInfected;

        public Town(int p, char ID)
        {
            this.day = 0;
            this.population = p;
            this.isInfected = false;
            this.ID = ID;
        }
        public double infectedPopulation(int time)
        { //Logistic Func I
            return ((double)population / (1 + Math.Pow(Math.Exp(population - 1), (-1) * gamma * time)));
        }
        public static double virusSpread(double I, double Tr)
        { //S
            return (I * Tr);
        }
    }
    public class Vertex
        {
            public Town city;
            public Dictionary<char, double> neighbors;
            public Vertex(Town City)
            {
                this.city = City;
                this.neighbors = new Dictionary<char,double> ();
            }
            public void addNeighbors(char key, double weight)
            {
                this.neighbors[key] = weight;
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
    }
}