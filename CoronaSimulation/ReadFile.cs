using System;
using System.Collections;
using System.Collections.Generic;

namespace ReadFile
{
    static class property
    {
        public static int nEdge;
        public static int nNode;
        public static char source;
    }
    class ReadFromFile
    {
        public static List<Tuple<char, char, double>> EdgeData = new List<Tuple<char, char, double>>();
        public static List<Tuple<char, int>> GraphData = new List<Tuple<char, int>>();

        public static void Read()
        {
            string[] files1 = System.IO.File.ReadAllLines(@"..\..\..\text1.txt");
            string[] files2 = System.IO.File.ReadAllLines(@"..\..\..\text2.txt");

            Console.WriteLine("\nIni adalah File 1");
            property.nEdge = Convert.ToInt32(files1[0]);
            Console.WriteLine($"ini adalah banyaknya edge : {property.nEdge}");

            for (int i = 1; i <= property.nEdge; i++){
                string[] edges = files1[i].Split(' ');
                for (int j = 0; j < edges.Length; j++)
                {
                    //Extract Data <From, To, Tr(From, To)>
                    if(j%3==2 )
                    {
                        ReadFromFile.EdgeData.Add(new Tuple<char, char, double>(
                            Convert.ToChar(edges[j-2]),
                            Convert.ToChar(edges[j-1]),
                            double.Parse(edges[j], System.Globalization.CultureInfo.InvariantCulture) //replacing separator '.' with ','
                            ));
                    }
                }
            }


            Console.WriteLine("\nIni adalah File 2");
            string[] getnNode = files2[0].Split(' ');
            property.nNode = Convert.ToInt32(getnNode[0]);
            property.source = char.Parse(getnNode[1]);

            Console.WriteLine($"ini adalah source-nya : {property.source}");
            Console.WriteLine($"ini adalah banyaknya node : {property.nNode}");

            for (int i = 1; i <= property.nNode; i++){
                string[] nodes = files2[i].Split(' ');
                for (int j = 0; j < nodes.Length; j++)
                {
                    //extract data <Town, P(A)>
                    if (j % 2 == 1)
                    {
                        ReadFromFile.GraphData.Add(new Tuple<char, int>(
                            Convert.ToChar(nodes[j - 1]),
                            Convert.ToInt32(nodes[j])
                            ));
                    }
                }
            }
        }
    }
}