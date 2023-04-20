using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo_List
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            refresh();
        }

        void refresh()
        {
            StreamReader sr = new StreamReader("ToDo_List.txt");

            Output.Text = sr.ReadToEnd();

            sr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            StreamReader copy = new StreamReader("ToDo_List.txt");
            
            string cc = copy.ReadToEnd();

            copy.Close();



            StreamWriter sw = new StreamWriter("ToDo_List.txt");


            sw.Write(cc);

            sw.WriteLine(Input.Text);

            sw.Close();

            refresh();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            string search = Input.Text;

            Input.Text = "";

            var tempFile = Path.GetTempFileName();                                         
            var linesToKeep = File.ReadLines("ToDo_List.txt").Where(l => l != search);

            File.WriteAllLines(tempFile, linesToKeep);
            
            File.Delete("ToDo_List.txt");

            File.Move(tempFile, "ToDo_List.txt");

            refresh();

        }

        private void Clear_Click(object sender, EventArgs e)
        {

            StreamWriter sw = new StreamWriter("ToDo_List.txt");

            sw.Write("");

            sw.Close();

            refresh();

        }

        private void Output2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
