using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DYT_CS
{
    public partial class Form2 : Form
    {
        private string taskName;
        private string taskTime;
        private string taskPriority;
        private string taskTeam;

        public Form2(string taskName, string taskTime, string taskPriority, string taskTeam)
        {
            InitializeComponent();
            this.taskName = taskName;
            this.taskTime = taskTime;
            this.taskPriority = taskPriority;
            this.taskTeam = taskTeam;
            this.Text = $"DoYourTask - {taskName}";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel1.Text = taskName;
            guna2HtmlLabel2.Text = $"Task name: {taskName}<br/>" +
                                   $"Due date: {taskTime}<br/>" +
                                   $"Task priority: {taskPriority}<br/>" +
                                   $"Task team: {taskTeam}";
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}