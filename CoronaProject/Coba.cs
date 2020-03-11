using System;
using ReadFile;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cobavisual {
    public class cobavisualisasi {
        public static void Visualisasi() {
            //create a form 
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            //create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 

            for (int i = 0; i < ReadFromFile.nEdge; i++) {
                graph.AddEdge(Char.ToString(ReadFromFile.EdgeData[i].Item1), Char.ToString(ReadFromFile.EdgeData[i].Item2)); 
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