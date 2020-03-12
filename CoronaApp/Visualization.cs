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

        public static int Search(List<Tuple<char,char>> list, Tuple<char, char> isi) {
            for (int i = 0; i < list.Count; i++) {
                if (list[i].Item1 == isi.Item1 && list[i].Item2 == isi.Item2) {
                    return 1;
                }
            }
            return 0;
        }

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

            List<Tuple<char, char>> busur = new List<Tuple<char,char>>();

            foreach (KeyValuePair<char, Vertex> item in Map.vertices)
            {
                foreach (KeyValuePair<char, Tuple<bool, double>> tetangga in item.Value.neighbors)
                {
                    if (tetangga.Value.Item1)
                    {
                        graph.AddEdge(Char.ToString(item.Key), Char.ToString(tetangga.Key)).Attr.Color = Microsoft.Msagl.Drawing.Color.Magenta;
                        var input = Tuple.Create(item.Key, tetangga.Key);
                        busur.Add(input);
                    }
                }
            }

            for (int i = 0; i < ReadFromFile.nEdge; i++) {
                var input = Tuple.Create(ReadFromFile.EdgeData[i].Item1, ReadFromFile.EdgeData[i].Item2);
                //var tambah = busur.FindAll(x => x == input);
                int cari = Search(busur, input);
                if (cari == 0) {
                    graph.AddEdge(Char.ToString(ReadFromFile.EdgeData[i].Item1), Char.ToString(ReadFromFile.EdgeData[i].Item2));
                }
                graph.FindNode(Char.ToString(ReadFromFile.EdgeData[i].Item1)).Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
            }

            foreach (KeyValuePair<char, Vertex> item in Map.vertices) {
                if (item.Value.city.day != -1) {
                    graph.FindNode(char.ToString(item.Key)).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                }
            }

            //bind the graph to the viewer 
            viewer.Graph = graph;
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
        }
    }
}