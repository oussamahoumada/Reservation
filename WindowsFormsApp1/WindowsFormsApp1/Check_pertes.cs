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
    public partial class Check_pertes : Form
    {
        public Check_pertes()
        {
            InitializeComponent();
        }
        Db_Hotele db = new Db_Hotele();
        private void Gains_Load(object sender, EventArgs e)
        {
            var i = db.Pertes.OrderBy(it => it.datePert);
            dataGridView1.DataSource = i.ToList();
            var s = db.Pertes.Sum(it=>it.valeur);
            label1.Text = s.ToString();
        }
    }
}
