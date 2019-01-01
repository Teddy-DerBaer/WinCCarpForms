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


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public const int NoMatches = -1;

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ListBox_DoubleClick(object sender, EventArgs e)
        {


            if (checkBox1.Enabled)
            {
                comboBox1.Items.Clear();
                comboBox1.ResetText();

                string text = listBox1.SelectedItem.ToString();
                string[] TArray;
                TArray = text.Split(';');
                comboBox1.BeginUpdate();
                for (int i = 0; i < TArray.Length; ++i)
                {
                    comboBox1.Items.Add(TArray[i]);
                }
                comboBox1.EndUpdate();               
                

                comboBox1.Refresh();
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
                }
                else
                {


                    checkBox1.Enabled = false;
                    checkBox1.Checked = true;
                }

            }
        }

        private void ComboBox_Click(object sender, EventArgs e)
        {

            string text = comboBox1.SelectedItem.ToString();

            System.Windows.Forms.Clipboard.SetDataObject(text, true);



        }

        private void Open_Btn_Click(object sender, EventArgs e)
        {

            string filePath = string.Empty;

            if (openFileDialog1.ShowDialog() == DialogResult.OK )
            {
                filePath = openFileDialog1.FileName;
                label5.Text = "Es wurde folgende Datei geladen :\n\r\n\r" + filePath; 
                filePath = openFileDialog1.FileName;
                try
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        string line = "";
                        string lineList = ""; 
                        while ((line = sr.ReadLine()) != null)
                        {
                            int index =listBox1.FindStringExact(line);
                            if (index == ListBox.NoMatches)
                            {
                                listBox1.Items.Add(line);
                            }
                            else
                            {
                                lineList = lineList + line + "\r\n";
                                ListBox_toolTip.Show(lineList, listBox1 ,55 ,299,11000 );
                               // MessageBox.Show("Name -> " + line + " <-ist schon vorhanden !!", "Ist schon Vorhanden!!" , MessageBoxButtons.OK);
                            }
                        }
                    }
                }
                catch (Exception es)
                {

                    //Was schief gegangen ist.                                       
                    MessageBox.Show("Datei konnte nicht gelesen werden" + "\r\n\r\n" + es.Message, "Dateiinhalt unter Pfad:\r\n\r\n " + filePath , MessageBoxButtons.OK);
                }
            }
            else
            {
                label5.Text = "Es wurde keine Datei geladen \r\n\r\nDurch Abbruch vom Benutzer !!";
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {

            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //System.IO.File.WriteAllText(saveFileDialog1.FileName, ??=);
            }
            else
            {



            }

            

           
        }
    }
}
