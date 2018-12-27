using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ListBox_DoubleClick(object sender, EventArgs e)
        {


            if (checkBox1.Enabled)
            {
                comboBox1.Items.Clear();
                string text = listBox1.SelectedItem.ToString();
                string[] TArray;
                TArray = text.Split(';');
                for (int i = 0; i < TArray.Length; ++i)
                {
                    comboBox1.Items.Add(TArray[i]);
                }

                comboBox1.Enabled = true;
                checkBox1.Enabled = false;
                checkBox1.Checked = true;
                checkBox2.Checked = false;
                listBox1.Enabled = false;
            }



            
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Checked = true;
                checkBox1.Enabled = false;
                checkBox2.Checked = false;

            }
            else
            {
                //this->checkBox1->Enabled = false;

                comboBox1.Enabled = true;
                listBox1.Enabled = true;

            }
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {


            if (checkBox1.Enabled)
            {



            }
            else
            {


                if (checkBox2.Checked)
                {
                    checkBox1.Enabled = true;
                    //this->checkBox1->Checked = false;
                }
                else
                {


                    checkBox1.Enabled = false;
                    checkBox1.Checked = true;
                }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
