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
using Cobavisual;
using ReadFile;
using AlgCompute;

namespace CoronaApp
{
    public partial class CoronaGUI : Form
    {
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
            int daysInfected;
            daysInfected = int.Parse(textBox1.Text);

            ReadFromFile.Read();
            Queue<char> QueueEdge = new Queue<char>();

            //ReadFromFile.EdgeData is data which contains Data of Edge
            //ReadFromFile.GraphData is data which contains Data of Graph

            //Init Graph G sudah di ReadFile
            ReadFromFile.province.printGraph();
            BFS.BFSCompute(daysInfected, ReadFromFile.source);
            BFS.printSol(daysInfected);
            cobavisualisasi.Visualisasi();
        }

    }
}
