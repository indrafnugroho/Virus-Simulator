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
        public static Microsoft.Msagl.Drawing.Graph graph;

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
                graph.FindNode(Char.ToString(ReadFromFile.EdgeData[i].Item1)).Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
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

            //bind the graph to the viewer 
            viewer.Graph = graph;
            //associate the viewer with the form 
            form.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            form.Controls.Add(viewer);
            form.ResumeLayout();
            //show the form 
            form.ShowDialog();

        }
    }
}