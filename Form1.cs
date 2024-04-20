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
using Guna.UI2.WinForms;

namespace DYT_CS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string appVersion = "v0.1.1";
            this.Text = $"DoYourTask - {appVersion}";
        }

        public void guna2Button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox1.Text) || string.IsNullOrEmpty(richTextBox1.Text) || string.IsNullOrEmpty(guna2ComboBox2.Text))
            {
                MessageBox.Show("You must fill in the fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                string taskLongDate = guna2DateTimePicker1.Value.ToString();
                string taskDate = taskLongDate.Split(' ')[0];
                string taskTime = taskLongDate.Split(' ')[1];
                int taskDay = Int32.Parse(taskDate.Split('/')[0]);
                int taskMonth = Int32.Parse(taskDate.Split('/')[1]);
                int taskYear = Int32.Parse(taskDate.Split('/')[2]);
                int taskHour = Int32.Parse(taskTime.Split(':')[0]);
                int taskMinute = Int32.Parse(taskTime.Split(':')[1]);
                int taskSeconds = Int32.Parse(taskTime.Split(':')[2]);
                
                string taskDetails = $"{guna2TextBox1.Text}:{taskDay}/{taskMonth}/{taskYear} - {taskHour}/{taskMinute}/{taskSeconds}:{guna2ComboBox2.SelectedItem}:{richTextBox1.Text}";
                string taskName = taskDetails.Split(':')[0];
                string taskPriority = taskDetails.Split(':')[2];
                string savePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "save.txt");

                using (StreamWriter saveFile = new StreamWriter(savePath, true))
                {
                    saveFile.WriteLine(taskDetails);
                }
                listBox1.Items.Add($"{taskName} - {taskPriority}");

                ResetForm();
            }
        }

        private void ResetForm()
        {
            guna2TextBox1.Text = String.Empty;
            guna2DateTimePicker1.Value = DateTime.Now;
            richTextBox1.Text = String.Empty;
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
                string selectedTaskName = listBox1.SelectedItem.ToString().Split('-')[0].Trim();
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
                    listBox1.Items.Add($"{taskName.Split(':')[0]} - {taskName.Split(':')[2]}");
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
                string selectedTaskName = listBox1.SelectedItem.ToString().Split('-')[0].TrimEnd();
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

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}