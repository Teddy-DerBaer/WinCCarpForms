using System;
using System.IO;
using System.Net;
using System.Windows.Forms;


namespace WindowsFormsApp2
{

    public partial class Form1 : Form
    {



        public Form1()
        {
            
            InitializeComponent();

           
        }


      



        public const int NoMatches = -1;

        private void ListBox_DoubleClick(object sender, EventArgs e)
        {


            if (checkBox1.Enabled)
            {
                if (listBox1.SelectedIndex > NoMatches)
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
                else
                {
                    ListBox_toolTip.ToolTipTitle = "Fehler !!";
                    ListBox_toolTip.Show("Nicht's markiert gewesen !!", listBox1, 55, 299, 11000);

                }
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

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                label5.Text = "Es wurde folgende Datei geladen :\n\r\n\r" + filePath;
                try
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        listBox1.BeginUpdate();
                        string line = "";
                        string lineList = "";
                        while ((line = sr.ReadLine()) != null)
                        {
                            int index = listBox1.FindStringExact(line);
                            if (index == ListBox.NoMatches)
                            {
                                listBox1.Items.Add(line);
                            }
                            else
                            {

                                lineList = lineList + line + "\r\n";
                                ListBox_toolTip.ToolTipTitle = "Diese Namen sind schon vorhanden!!";
                                ListBox_toolTip.Show(lineList, listBox1, 55, 299, 11000);
                            }
                        }
                        listBox1.EndUpdate();
                    }
                }
                catch (Exception es)
                {

                    //Was schief gegangen ist.                                       
                    MessageBox.Show("Datei konnte nicht gelesen werden" + "\r\n\r\n" + es.Message, "Dateiinhalt unter Pfad:\r\n\r\n " + filePath, MessageBoxButtons.OK);
                }
            }
            else
            {
                label5.Text = "Es wurde keine Datei geladen \r\n\r\nDurch Abbruch vom Benutzer !!";
            }
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                try
                {

                    using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                    {
                        //listBox1.Enabled = true;
                        if (listBox1.Items.Count > 0)
                        {
                            listBox1.BeginUpdate();
                            foreach (string item in listBox1.Items)
                            {
                                sw.WriteLine(item);
                            }
                            label5.Text = "Dateien gespeichert unter : \r\n\r\n" + saveFileDialog1.FileName;
                            listBox1.EndUpdate();
                            listBox1.Items.Clear();

                        }
                        else
                        {

                            label5.Text = "Daten von ListBox nicht gespeichert : \r\n\r\nDie ListBox war LEER !!";

                        }
                    }
                }
                catch (Exception es)
                {
                    //Was schief gegangen ist.                                       
                    MessageBox.Show("Datei konnte nicht geschrieben werden" + "\r\n\r\n" + es.Message, "Dateiinhalt unter Pfad:\r\n\r\n " + saveFileDialog1.FileName, MessageBoxButtons.OK);

                }

            }
            else
            {
                label5.Text = "Es wurde keine Datei gespeichert \r\n\r\nDurch Abbruch vom Benutzer !!";

            }
        }

        private void UserHinzufuge_Btn_Click(object sender, EventArgs e)
        {
            if (txtBox1.Text != "")
            {
                listBox1.BeginUpdate();
                string line = txtBox1.Text.Trim();
                int index = listBox1.FindStringExact(line);
                if (index == ListBox.NoMatches)
                {
                    listBox1.Items.Add(line);

                }
                else
                {
                    ListBox_toolTip.ToolTipTitle = "Dieser Namen ist schon vorhanden!!";
                    ListBox_toolTip.Show(line, listBox1, 55, 299, 11000);

                }
                listBox1.EndUpdate();
                txtBox1.Clear();

            }
            else
            {
                ListBox_toolTip.ToolTipTitle = "Nicht's hinzugefügt";
                ListBox_toolTip.Show("Die Eingabe Liste war LEER !!", listBox1, 55, 299, 11000);

            }
        }

        private void Userlosche_BTN_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex > NoMatches)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);

            }
            else
            {
                ListBox_toolTip.ToolTipTitle = "Nicht's Gelöscht";
                ListBox_toolTip.Show("Es wurde vorher nicht's markiert !!", listBox1, 55, 299, 11000);

            }

        }

        static int hh = 0;

        private void IP_aktuel_Btn_Click(object sender, EventArgs e)
        {
            string ip = "";
            hh++;

            string url = "http://api.ipify.org";
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
                {
                    using (StreamReader str = new StreamReader(res.GetResponseStream()))
                    {
                        ip = str.ReadToEnd();
                        str.Close();
                        label7.Text = IPAddress.Parse(ip).ToString() + " " + hh;
                    }
                    res.Close();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("Eine Ausnahme erwischt!!!\n\r" + "Quelle : " + es.Source + "\n\r" + "Botschaft : " + es.Message);
                label7.Text = es.Message;
            }
        }
    }
}