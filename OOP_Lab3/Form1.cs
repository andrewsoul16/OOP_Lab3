using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OOP_Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] ints;

        public void Read()
        {
            try
            {
                StreamReader reader = new StreamReader("source.txt");

                String source = reader.ReadLine();

                reader.Close();

                ints = source.Split(' ').Select(Int32.Parse).ToArray();

                for(int i = 0; i < 15; i++)
                {
                    tbSource.Text += ints[i];
                    tbSource.Text += " ";
                }                
            }
            catch(Exception e)
            {
                MessageBox.Show("Exception: "+e.Message);
            }
        }

        public void InsertionSort()
        {
            for (int i = 1; i < 15; i++)
            {
                int temp = ints[i];

                if (ints[i]>ints[i-1])
                {
                    continue;
                }
                else
                {
                    int j = i;

                    while (temp<=ints[j-1])
                    {
                        ints[j] = ints[j - 1];
                        
                        j--;

                        if (j == 0) break;
                    }

                    ints[j] = temp;
                }               
            }
        }

        public void SelectionSort()
        {
            for (int i = 0; i < 14; i++)
            {
                int min = i;

                for (int j = i + 1; j < 15; j++)
                    {
                    if (ints[j] < ints[min])
                    {
                        min = j;        
                    }
                }
                int dummy = ints[i];
                ints[i] = ints[min];
                ints[min] = dummy;
            }
        }

        public void BubbleSort()
        {
                int temp;
                for (int i = 0; i < ints.Length - 1; i++)
                {
                    for (int j = 0; j < ints.Length - i - 1; j++)
                    {
                        if (ints[j + 1] < ints[j])
                        {
                            temp = ints[j + 1];
                            ints[j + 1] = ints[j];
                            ints[j] = temp;
                        }
                    }
                }
        }

        public void ShellSort()
        {
            int step = ints.Length / 2;
            while (step > 0)
            {
                int i, j;
                for (i = step; i < ints.Length; i++)
                {
                    int value = ints[i];
                    for (j = i - step; (j >= 0) && (ints[j] > value); j -= step)
                        ints[j + step] = ints[j];
                    ints[j + step] = value;
                }
                step /= 2;
            }
        }

        int start = 0;
        int end;

        public void QuickSort(int start,int end)
        {
            int pivot = end / 2;
            int temp;

            while (start < end)
            {
                if (ints[start] > ints[end])
                {
                    temp = ints[end];
                    ints[end] = ints[start];
                    ints[start] = temp;
                }
                start++;
                end--;
            }

            start = 0;


            //QuickSort()
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Read();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbSorted.Text != null)
            {
                tbSorted.Text = "";
            }

            //InsertionSort();
            //SelectionSort();
            //BubbleSort();
            //ShellSort();
            //QuickSort();

            for (int i = 0; i < 15; i++)
            {
                tbSorted.Text += ints[i];
                tbSorted.Text += " ";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
