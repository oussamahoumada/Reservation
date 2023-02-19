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
    public partial class AjouterClient : Form
    {
        public AjouterClient()
        {
            InitializeComponent();
        }
        Db_Hotele db = new Db_Hotele();
        private void button1_Click(object sender, EventArgs e)
        {
            if (db.Client.Find(textBox1.Text)!=null) 
            {
                MessageBox.Show("exist deja");
                return;
            }
            Client c = new Client();
            c.CIN = textBox1.Text;
            c.Nom = textBox2.Text;
            c.Tel = textBox3.Text;
            db.Client.Add(c);
            db.SaveChanges();
        }
    }
}