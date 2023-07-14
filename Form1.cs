using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DYT_CS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "DoYourTask - Flenderr's";
        }

        public void guna2Button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox1.Text) & string.IsNullOrEmpty(guna2ComboBox1.Text) & string.IsNullOrEmpty(guna2ComboBox2.Text))
            {
                MessageBox.Show("Vous devez remplir les champs !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string text = guna2TextBox1.Text + ":" + guna2DateTimePicker1.Value.ToShortDateString() + ":" + guna2ComboBox2.SelectedItem.ToString() + ":" + guna2ComboBox1.SelectedItem.ToString();
                Console.WriteLine(text);
                var task_name = text.Split(':')[0];
                string sPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\save.txt";
                System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath, true);
                SaveFile.WriteLine(text);
                SaveFile.ToString();
                SaveFile.Close();
                checkedListBox1.Items.Add(task_name);
                guna2TextBox1.Text = String.Empty;
                guna2DateTimePicker1.Value = DateTime.Now;
                guna2ComboBox1.SelectedItem = null;
                guna2ComboBox2.SelectedItem = null;
            }
        }

        public void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            checkedListBox1.SelectedItem.ToString();
        }

        public void guna2Button8_Click_1(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Vous devez séléctionner une tâche !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var systemPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                string sPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\save.txt";
                string[] readText = File.ReadAllLines(sPath);
                foreach (string s in readText)
                {
                    string split_text = s.Split(':')[0];
                    if (checkedListBox1.SelectedItem.ToString() == split_text)
                    {
                        string task_name = split_text;
                        string task_time = s.Split(':')[1];
                        string task_priority = s.Split(':')[2];
                        string task_team = s.Split(':')[3];
                        Form2 f2 = new Form2(task_name, task_time, task_priority, task_team);
                        f2.Show();
                    }
                }
            }

        }

        public void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        public void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\save.txt";
            if (File.Exists(sPath) == false)
            {
                DialogResult dialogResult = MessageBox.Show("Le fichier de sauvegarde de tâche est introuvable !\nVoulez vous le créer ?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    File.Create(sPath);
                    DialogResult created_succes = MessageBox.Show("Le fichier a été créé avec succès !", "Fichier de sauvegarde", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (created_succes == DialogResult.OK)
                    {
                        Application.Exit();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            else if (File.Exists(sPath))
            {
                string[] readText = File.ReadAllLines(sPath);
                foreach (string s in readText)
                {
                    string split_text = s.Split(':')[0];
                    checkedListBox1.Items.Add(split_text);
                }
            }
        }

        private void guna2Button12_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button13_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Vous devez séléctionner une tâche !", "Error", MessageBoxButtons.OK ,MessageBoxIcon.Warning);
            }
            else
            {
                int element = checkedListBox1.SelectedIndex;
                string sPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\save.txt";
                string word = Convert.ToString(checkedListBox1.SelectedItem);  
                var oldLines = System.IO.File.ReadAllLines(sPath);
                var newLines = oldLines.Where(line => !line.Contains(word));
                System.IO.File.WriteAllLines(sPath, newLines);
                FileStream obj = new FileStream(sPath, FileMode.Append);
                obj.Close();
                checkedListBox1.Items.RemoveAt(element);
            }
        }
    }
}
