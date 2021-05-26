using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingVisualization
{
    public partial class Form1 : Form
    {
        private string nums = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nums = textBox1.Text;
            Form2 form = new Form2(nums);
            Hide();
            form.ShowDialog();
            Close();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            Random random = new Random();
            int n = random.Next(5, 13);

            for (int i = 0; i < n; i++)
                SelectionSort.numbers.Add(random.Next(1, 100));
            SelectionSort.Create(form);

            Hide();
            form.ShowDialog();
            Close();
        }
    }
}
