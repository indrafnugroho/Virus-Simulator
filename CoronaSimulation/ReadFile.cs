using System;
namespace ReadFile
{
    class ReadFromFile
    {
        public static void Read()
        {
            string[] files1 = System.IO.File.ReadAllLines(@"..\..\..\text1.txt");
            string[] files2 = System.IO.File.ReadAllLines(@"..\..\..\text2.txt");


            // System.Console.WriteLine("Contents of text1.txt = ");
            // foreach (string line1 in files1)
            // {
            //     Console.WriteLine(line1);
            // }

            Console.WriteLine("\nIni adalah File 1");
            int nEdge = Convert.ToInt32(files1[0]);
            Console.WriteLine($"ini adalah banyaknya edge : {nEdge}");

            for (int i = 1; i < nEdge; i++){
                string[] edges = files1[i].Split(' ');
                foreach (string edge in edges){
                    Console.WriteLine(edge);
                }
            }

            // System.Console.WriteLine("Contents of text2.txt = ");
            // foreach (string line2 in files2)
            // {
            //     Console.WriteLine(line2);
            // }

            Console.WriteLine("\nIni adalah File 2");
            string[] getnNode = files2[0].Split(' ');
            int nNode = Convert.ToInt32(getnNode[0]);
            var source = getnNode[1];

            System.Console.WriteLine($"ini adalah banyaknya node : {nNode}");
            System.Console.WriteLine($"ini adalah source-nya : {source}");

            for (int i = 1; i < nNode; i++){
                string[] nodes = files2[i].Split(' ');
                foreach (string node in nodes){
                    Console.WriteLine(node);
                }
            }

            // // Keep the console window open in debug mode.
            // Console.WriteLine("Press any key to exit.");
            // System.Console.ReadKey();
        }
    }
}