using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class parent : Form
    {
        public parent()
        {
            this.WindowState = FormWindowState.Maximized;

            InitializeComponent();
        }

        
        public void del()
        {
            foreach (Form childFormm in MdiChildren)
            {
                childFormm.Close();
            }
        }

        private void parent_Load(object sender, EventArgs e)
        {
            del();
            Home childForm = new Home();
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            del();
            Home childForm = new Home();
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            del();
            ReservationForm childForm = new ReservationForm();
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            del();
            AjouterClient childForm = new AjouterClient();
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            del();
            PertesForm childForm = new PertesForm();
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            del();
            Check_pertes childForm = new Check_pertes();
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            del();
            FinLocation childForm = new FinLocation();
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void parent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
