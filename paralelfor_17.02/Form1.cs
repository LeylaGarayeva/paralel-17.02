using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paralelfor_17._02
{

    public partial class Form1 : Form
    {
        int sum = 0;
        int sum2 = 0;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task task= new Task(() => {

                for (int i = 0; i < 999999999; i++)
            {
                progressBar1.Value = i/10000000;
            }}
           );

            task.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task task2 = new Task(() => {

                for (int i = 0; i < 999999999; i++)
                {
                    progressBar2.Value = i / 10000000;
                }
            } 
          );
            task2.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
            Task task3 = new Task(() =>
            {
                Stopwatch timer = new Stopwatch();
                StreamReader sr = new StreamReader("C:/Users/P502/Documents/Visual Studio 2017/test.txt");
                timer.Start();
                var mytext = sr.ReadToEnd();
                sr.Close();
                sum+= mytext.Length;
               // MessageBox.Show(mytext.Length.ToString() + " time: " + timer.ElapsedMilliseconds.ToString());
            });

            Task task4 = new Task(() => {
                Stopwatch timer2 = new Stopwatch();
                StreamReader sr2 = new StreamReader("C:/Users/P502/Documents/Visual Studio 2017/test.txt");
                timer2.Start();
                var mytext2 = sr2.ReadToEnd();
                sr2.Close();
                sum2 += mytext2.Length;
                // MessageBox.Show(mytext2.Length.ToString() + " time: " + timer2.ElapsedMilliseconds.ToString());
            });
            task3.Start();
            task4.Start();
            Task.WaitAll(task3,task4);
            
            MessageBox.Show((sum + sum2).ToString());
        }





        private void button4_Click(object sender, EventArgs e)
        {
            Task task5 = new Task(() => { 
            Stopwatch timer2 = new Stopwatch();
            StreamReader sr2 = new StreamReader("C:/Users/P502/Documents/Visual Studio 2017/reader.txt");
            timer2.Start();
            var mytext2 = sr2.ReadToEnd();
            sr2.Close();
            MessageBox.Show(mytext2.Length.ToString() + " time: " + timer2.ElapsedMilliseconds.ToString());
        });

            task5.Start();
        }
    }
    
}
