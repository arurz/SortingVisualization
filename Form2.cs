using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingVisualization
{
    public partial class Form2 : Form
    {
        public static List<int> numbers = new List<int>();

        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string nums)
        {
            InitializeComponent();
            typeof(Control).GetProperty(
               "DoubleBuffered",
               BindingFlags.NonPublic |
               BindingFlags.Instance);

            string[] splitted = nums.Split(',');
            for (int i = 0; i < splitted.Length; i++)
                if (splitted[i] != "")
                    SelectionSort.numbers.Add(int.Parse(splitted[i]));
            SelectionSort.Create(this);
        }
        #region Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            if (SelectionSort.counter != SelectionSort.numbers.Count)
            {
                SelectionSort.Sort(SelectionSort.numbers);
                SelectionSort.counter++;
            }
            else
                SelectionSort.Create(this);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SelectionSort.numbers.Clear();
            SelectionSort.labels.Clear();
            SelectionSort.counter = 0;
            SelectionSort.smallest = 0;
            SelectionSort.j = 0;

            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i] is Button)
                    continue;
                else Controls.Remove(Controls[i]);
            }

            Random random = new Random();
            int n = random.Next(5, 13);

            for (int i = 0; i < n; i++)
                SelectionSort.numbers.Add(random.Next(1, 100));
            SelectionSort.Create(this);
            
        }
        #endregion
    }
}
