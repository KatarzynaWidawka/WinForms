using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OstatecznyprogramPUM
{
    public partial class CiagFibonacciego : Form
    {
        public CiagFibonacciego()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        volatile int n;
        volatile int wynik;
        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            if(textBox1.Text!="")
            {
                n = int.Parse(textBox1.Text);
                progressBar1.Maximum = n - 1;
                progressBar1.Step = 1;
                progressBar1.Value = 1;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void progressBar1_Click(object sender, EventArgs e) {  }
        
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            int f1 = 0; //wartość pierwszego elementu
            int f2 = 1; //wartość drugiego elementu
            for (int i=0;i<n-1;i++)
            {
               
                wynik= f1 + f2;
                f1 = f2;
                f2 = wynik;


                System.Threading.Thread.Sleep(200);
                progressBar1.Invoke(new Action(() => progressBar1.PerformStep()));
                textBox2.Invoke(new Action(() => textBox2.Text = wynik.ToString()));
            }
            
            

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        { textBox2.Text = "Wynik:" + wynik; }
        private void CiagFibonacciego_Load(object sender, EventArgs e) { }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
