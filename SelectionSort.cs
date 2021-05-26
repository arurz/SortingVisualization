using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingVisualization
{
    public class SelectionSort : Form
    {
        public static int counter = 0;
        public static int smallest = 0;
        public static int j = 0;

        public static List<int> numbers = new List<int>();
        public static List<Label> labels = new List<Label>();
        private static Form2 form = new Form2();

        private static Color[] colors = new Color[]
        {
            Color.LightGreen, //sorted item color
            Color.Gray,       //selected item color 
            Color.Blue,       //smallest item color
            Color.Red         //not sorted item color
        };


        public static void Sort(List<int> numbers)
        {
            smallest = counter;
            for (j = counter + 1; j < numbers.Count; j++)
            {
                if (numbers[j] < numbers[smallest])
                    smallest = j;
            }
            swap();
        }

        private static void swap()
        {
            Create(form);
            int temp = numbers[smallest];
            numbers[smallest] = numbers[counter];
            numbers[counter] = temp;
        }

        public static void Create(Form2 form2)
        {
            form = form2;
            for (int i = form.Controls.Count-1; i >= 0; i--)
            {
                if (form.Controls[i] is Button)
                    continue;
                else form.Controls.Remove(form.Controls[i]);
            }
            labels.Clear();
            build(form);
        }

        private static void build(Form2 form)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                Label label = new Label();
                label.Text = numbers[i].ToString();
                label.AutoSize = false;
                label.BorderStyle = BorderStyle.FixedSingle;

                if(counter == numbers.Count())
                    label.BackColor = colors[0]; //green

                else if(i == smallest)
                    label.BackColor = colors[2]; //blue

                else if (i == counter)
                    label.BackColor = colors[1]; //grey
                    
                else if (i < counter)
                    label.BackColor = colors[0]; //green

                else
                    label.BackColor = colors[3]; //red
                    

                if (i != 0)
                {
                    var x = labels[i - 1].Location.X;
                    var y = labels[0].Location.Y;
                    label.Location = new Point(x += 50, y);
                }

                switch (numbers[i])
                {
                    case 1:
                        label.Size = new Size(40, numbers[i] * 14);
                        break;
                    case 2:
                        label.Size = new Size(40, numbers[i] * 8);
                        break;
                    default:
                        label.Size = new Size(40, numbers[i] * 6);
                        break;
                }
                labels.Add(label);
                form.Controls.Add(label);
            }
        }
    }
}
      
