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
        private int? indexToRemove = null;

        public Form1()
        {
            InitializeComponent();
            this.Text = "DoYourTask - Flenderr's";
        }

        public void guna2Button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox1.Text) || string.IsNullOrEmpty(guna2ComboBox1.Text) || string.IsNullOrEmpty(guna2ComboBox2.Text))
            {
                MessageBox.Show("You must fill in the fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string taskDetails = $"{guna2TextBox1.Text}:{guna2DateTimePicker1.Value.ToShortDateString()}:{guna2ComboBox2.SelectedItem}:{guna2ComboBox1.SelectedItem}";
                Console.WriteLine(taskDetails);
                string taskName = taskDetails.Split(':')[0];
                string savePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "save.txt");
                using (StreamWriter saveFile = new StreamWriter(savePath, true))
                {
                    saveFile.WriteLine(taskDetails);
                }
                listBox1.Items.Add(taskName);
                ResetForm();
            }
        }

        private void ResetForm()
        {
            guna2TextBox1.Text = String.Empty;
            guna2DateTimePicker1.Value = DateTime.Now;
            guna2ComboBox1.SelectedItem = null;
            guna2ComboBox2.SelectedItem = null;
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
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a task!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string selectedTaskName = listBox1.SelectedItem.ToString();
                string savePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "save.txt");
                string[] taskLines = File.ReadAllLines(savePath);
                foreach (string line in taskLines)
                {
                    string[] taskDetails = line.Split(':');
                    if (taskDetails[0] == selectedTaskName)
                    {
                        Form2 form2 = new Form2(taskDetails[0], taskDetails[1], taskDetails[2], taskDetails[3]);
                        form2.Show();
                        break;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string savePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "save.txt");
            if (!File.Exists(savePath))
            {
                DialogResult dialogResult = MessageBox.Show("The task save file could not be found!\nDo you want to create it?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    File.Create(savePath).Close();
                    MessageBox.Show("The file has been successfully created!", "Save File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                string[] taskNames = File.ReadAllLines(savePath);
                foreach (string taskName in taskNames)
                {
                    listBox1.Items.Add(taskName.Split(':')[0]);
                }
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a task!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string selectedTaskName = listBox1.SelectedItem.ToString();
                string savePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "save.txt");
                var taskLines = File.ReadAllLines(savePath).Where(line => !line.Contains(selectedTaskName));
                File.WriteAllLines(savePath, taskLines);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void guna2Button12_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button13_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}