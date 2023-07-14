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
        private string task_nom;
        private string task_temps;
        private string task_priorite;
        private string task_equipe;
        
        public string TaskNom
        {
            get { return task_nom; }
        }
        public string TaskTemps
        {
            get { return task_temps; }
        }
        public string TaskPrio
        {
            get { return task_priorite; }
        }
        public string TaskEquipe
        {
            get { return task_equipe; }
        }

        public Form2(string task_name,string task_time, string task_priority, string task_team)
        {
            InitializeComponent();
            this.Text = "DoYourTask - Flenderr's";
            task_nom = task_name;
            task_temps = task_time;
            task_priorite = task_priority;
            task_equipe = task_team;
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel1.Text = task_nom;
            guna2HtmlLabel2.Text = "Nom de la tâche : " + task_nom + "<br/>" + "Date de remise : " + task_temps + "<br/>" + "Priorité de la tâche : " + task_priorite + "<br/>" + "Équipe de la tâche : " + task_equipe;
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            
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
