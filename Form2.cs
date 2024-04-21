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
        private string taskDesc;

        public Form2(string taskName, string taskTime, string taskPriority, string taskDesc)
        {
            InitializeComponent();
            this.taskName = taskName;
            this.taskTime = taskTime;
            this.taskPriority = taskPriority;
            this.taskDesc = taskDesc;
            this.Text = $"DoYourTask - {taskName}";
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel2.Text = $"<span style='color: #2a654c; font-weight: bold;'>Task name:</span> {taskName}<br/>" +
                $"<span style='color: #2a654c; font-weight: bold;'>Task description:</span> {taskDesc}<br/>" +
                $"<span style='color: #2a654c; font-weight: bold;'>Due date:</span> {taskTime}<br/>" +
                $"<span style='color: #2a654c; font-weight: bold;'>Task priority:</span> {taskPriority}";
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