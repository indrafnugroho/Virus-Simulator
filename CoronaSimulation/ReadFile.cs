using System;
namespace ReadFile
{
    class ReadFromFile
    {
        public static void Read()
        {
            // The files used in this example are created in the topic
            // How to: Write to a Text File. You can change the path and
            // file name to substitute text files of your own.

            // System.Console.WriteLine("Example 1");
            // // Example #1
            // // Read the file as one string.
            // string text = System.IO.File.ReadAllText(@"C:\Users\FAUZAN\Documents\Semester 4\1. Stima\Tubes-2-Stima\CoronaSimulation\text1.txt");

            // // Display the file contents to the console. Variable text is a string.
            // System.Console.WriteLine("Contents of text1.txt = {0}", text);

            // System.Console.WriteLine("Example 2");
            // Example #2
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] files1 = System.IO.File.ReadAllLines(@"C:\Users\FAUZAN\Documents\Semester 4\1. Stima\Tubes-2-Stima\CoronaSimulation\text1.txt");
            string[] files2 = System.IO.File.ReadAllLines(@"C:\Users\FAUZAN\Documents\Semester 4\1. Stima\Tubes-2-Stima\CoronaSimulation\text2.txt");


            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of text1.txt = ");
            foreach (string line1 in files1)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine(line1);
            }

            Console.WriteLine("\nIni adalah File 1");
            int nEdge = Convert.ToInt32(files1[0]);
            Console.WriteLine(nEdge);

            for (int i = 1; i < nEdge; i++){
                string[] edges = files1[i].Split(' ');
                foreach (string edge in edges){
                    // Use a tab to indent each line of the file.
                    Console.WriteLine(edge);
                }
            }


            System.Console.WriteLine("Contents of text2.txt = ");
            foreach (string line2 in files2)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine(line2);
            }

            Console.WriteLine("\nIni adalah File 2");

            string[] getnNode = files2[0].Split(' ');
            int nNode = Convert.ToInt32(getnNode[0]);
            var source = getnNode[1];


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