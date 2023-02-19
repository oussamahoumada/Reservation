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
    public partial class PertesForm : Form
    {
        public PertesForm()
        {
            InitializeComponent();
        }
        Db_Hotele db = new Db_Hotele();
        private void button1_Click(object sender, EventArgs e)
        {
            Pertes p = new Pertes();
            p.Descrip = textBox1.Text;
            p.valeur = double.Parse(textBox2.Text);
            p.datePert = dateTimePicker1.Value;
        }

        private void PertesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
