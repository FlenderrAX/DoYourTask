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
            this.Text = "DoYourTask - Flenderr's";
            this.taskName = taskName;
            this.taskTime = taskTime;
            this.taskPriority = taskPriority;
            this.taskTeam = taskTeam;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel1.Text = taskName;
            guna2HtmlLabel2.Text = $"Nom de la tâche : {taskName}<br/>" +
                                   $"Date de remise : {taskTime}<br/>" +
                                   $"Priorité de la tâche : {taskPriority}<br/>" +
                                   $"Équipe de la tâche : {taskTeam}";
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