using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Visualization;
using ReadFile;
using AlgCompute;

namespace CoronaApp
{
    public partial class CoronaGUI : Form
    {
        public static int daysInfected;
        public static bool isButtonClicked = false;
        public CoronaGUI()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "  ^ [0-9]"))
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            daysInfected = int.Parse(textBox1.Text);
            label2.Text = "Current\ndays: " + daysInfected.ToString();

            ReadFromFile.Read();
            Queue<char> QueueEdge = new Queue<char>();

            //ReadFromFile.EdgeData is data which contains Data of Edge
            //ReadFromFile.GraphData is data which contains Data of Graph

            if (isButtonClicked)
            {
                this.Controls.Remove(Visualisasi.viewer);
            }
            //Init Graph G sudah di ReadFile
            ReadFromFile.province.printGraph();
            BFS.BFSCompute(daysInfected, ReadFromFile.source);
            BFS.printSol(daysInfected);
            Visualisasi.Visual();
            
            //associate the viewer with the GUI 
            this.SuspendLayout();
            this.Controls.Add(Visualisasi.viewer);
            this.ResumeLayout();
            isButtonClicked = true;
            
        }

        private void CoronaGUI_Load(object sender, EventArgs e)
        {
            //this.Controls.Add(Visualisasi.viewer);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            daysInfected++;
            label2.Text = "Current\ndays: " + daysInfected.ToString();
            ReadFromFile.Read();
            Queue<char> QueueEdge = new Queue<char>();

            //ReadFromFile.EdgeData is data which contains Data of Edge
            //ReadFromFile.GraphData is data which contains Data of Graph

            this.Controls.Remove(Visualisasi.viewer);
            //Init Graph G sudah di ReadFile
            ReadFromFile.province.printGraph();
            BFS.BFSCompute(daysInfected, ReadFromFile.source);
            BFS.printSol(daysInfected);
            Visualisasi.Visual();

            //associate the viewer with the GUI 
            this.SuspendLayout();
            this.Controls.Add(Visualisasi.viewer);
            this.ResumeLayout();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (daysInfected > 0)
            {
                daysInfected--;
                label2.Text = "Current\ndays: " + daysInfected.ToString();
                ReadFromFile.Read();
                Queue<char> QueueEdge = new Queue<char>();

                //ReadFromFile.EdgeData is data which contains Data of Edge
                //ReadFromFile.GraphData is data which contains Data of Graph

                this.Controls.Remove(Visualisasi.viewer);
                //Init Graph G sudah di ReadFile
                ReadFromFile.province.printGraph();
                BFS.BFSCompute(daysInfected, ReadFromFile.source);
                BFS.printSol(daysInfected);
                Visualisasi.Visual();
                
                //associate the viewer with the GUI 
                this.SuspendLayout();
                this.Controls.Add(Visualisasi.viewer);
                this.ResumeLayout();
            }
        }
    }
}
