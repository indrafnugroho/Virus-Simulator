using System;
using ReadFile;
using System.Collections.Generic;
using System.Windows.Forms;
using AlgCompute;
using Entity;
using System.Drawing;
using System.Drawing.Imaging;

namespace Visualization
{
    public class Visualisasi
    {
        public static Microsoft.Msagl.GraphViewerGdi.GViewer viewer;
        //public static Microsoft.Msagl.Drawing.Graph graph;

        public static void Visual()
        {
            Graph Map = ReadFromFile.province;
            //create a form 
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            //create a viewer object 
            viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 

            for (int i = 0; i < ReadFromFile.nEdge; i++) {
                graph.AddEdge(Char.ToString(ReadFromFile.EdgeData[i].Item1), Char.ToString(ReadFromFile.EdgeData[i].Item2));
            }

            //for (int i = 0; i < ReadFromFile.nNode; i++) {
            //   if (BFS.Map.vertices[vertices.Keys.ElementAt(i)].neighbors.Keys.ElementAt(i)) {
            //       graph.FindNode(char.ToString(BFS.Map.vertices.Keys.ElementAt(i))).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
            //   }
            //}

            foreach (KeyValuePair<char, Vertex> item in Map.vertices) {
                if (item.Value.city.day != -1) {
                    graph.FindNode(char.ToString(item.Key)).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                }
            }

            Microsoft.Msagl.GraphViewerGdi.GraphRenderer renderer = new Microsoft.Msagl.GraphViewerGdi.GraphRenderer(graph);
            renderer.CalculateLayout();
            int width = 50;
            Bitmap bitmap = new Bitmap(width, (int)(graph.Height * (width / graph.Width)), PixelFormat.Format32bppPArgb);
            renderer.Render(bitmap);
            bitmap.Save("test.JPG");
            graph.Write("Fauzan.jpg");

            //bind the graph to the viewer 
            viewer.Graph = graph;
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
        }
    }
}