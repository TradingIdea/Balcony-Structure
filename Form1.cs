using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balcony_Structure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public double Safetyfactor_C1 { get; set; }
        public double Safetyfactor_C2 { get; set; }
        public double WeightBalcony { get; set; }
        public int LoadingType { get; set; }
        public int NumberOfPersons { get; set; }
        public double LoadWeight { get; set; }



        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;

            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 8);

            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.HeaderCell.Style.Font = new Font("Tahoma", 7, FontStyle.Bold);
            }

            if (comboBox1.SelectedIndex == 1)
            {
                textBox4.Text = "1.25";
                textBox2.Text = "1.5";
            }

            //textBox4.Text = comboBox1.SelectedIndex == 0 ? "1.5" : "1.25";
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == String.Empty || textBox3.Text == String.Empty)
            {
                MessageBox.Show("Please fill in all fields then try again...");
            }
            else
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    textBox5.Text = CalcuLoadWeight().ToString();
                    this.dataGridView1.Rows.Add(comboBox1.Text, NumberOfPersons, WeightBalcony, Safetyfactor_C1,
                                                 Safetyfactor_C2, LoadWeight);
                }
                else
                {
                    MessageBox.Show("Please select a type Loading of combobox...");
                }
            }

            if (comboBox1.SelectedIndex == 1)
            {
                if (textBox1.Text == String.Empty || textBox3.Text == String.Empty)
                {
                    MessageBox.Show("Please fill in all fields then try again...");
                }
            }

        }

        public double CalcuLoadWeight()
        {
            if (comboBox1.SelectedIndex == 1)
            {
                Safetyfactor_C1 = Convert.ToDouble(textBox4.Text);
                Safetyfactor_C2 = Convert.ToDouble(textBox2.Text);
            }
            WeightBalcony = Convert.ToDouble(textBox3.Text);
            NumberOfPersons = Convert.ToInt32(textBox1.Text);


            LoadWeight = WeightBalcony / NumberOfPersons;

            if (comboBox1.SelectedIndex == 1)
            {
                LoadWeight = (Safetyfactor_C1 * LoadWeight) + (Safetyfactor_C2 * 0);
            }
            return LoadWeight;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                textBox4.Text = "1.25";
                textBox2.Text = "1.5";
            }
            else
            {
                textBox4.Text = String.Empty;
                textBox2.Text = String.Empty;
            }

            textBox5.Text = String.Empty;
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }

        private void ClearAll_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
    }
}
