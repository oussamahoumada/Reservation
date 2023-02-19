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
    public partial class FinLocation : Form
    {
        public FinLocation()
        {
            InitializeComponent();
        }
        Db_Hotele db = new Db_Hotele();
        public void load()
        {
            var list = from r in db.Reservation 
                       where r.etat == false
                       select
                       new
                       {
                           CIN = r.CIN,
                           Maison = r.id_Maison,
                           Prix = r.prix,
                           Avance = r.avance,
                           prixTotale = (r.prix * r.duree),
                           Reste = ((r.prix * r.duree) - r.avance),
                           DateDebut = r.dateDebut,
                           DateFin = r.dateFin,
                           Durée = r.duree,
                           etat = r.etat
                       };
            dataGridView1.DataSource = list.ToList();
        }
        private void FinLocation_Load(object sender, EventArgs e)
        {
            comboBox2.DataSource = db.Client.ToList();
            comboBox2.ValueMember = "CIN";
            comboBox2.DisplayMember = "Nom";

            comboBox1.DataSource = db.Maison.ToList();
            comboBox1.ValueMember = "id_Maison";
            comboBox1.DisplayMember = "Num";

            load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var list = from r in db.Reservation
                       where r.etat==false
                       select
                       new
                       {
                           CIN = r.CIN,
                           Maison = r.id_Maison,
                           Prix = r.prix,
                           Avance = r.avance,
                           prixTotale = (r.prix * r.duree),
                           Reste = ((r.prix * r.duree) - r.avance),
                           DateDebut = r.dateDebut,
                           DateFin = r.dateFin,
                           Durée = r.duree,
                           etat = r.etat
                       };
            if (checkBox1.Checked)
            {
                string cin = comboBox2.SelectedValue.ToString();
                list.Where(item => item.CIN == cin);
            }
            if (checkBox1.Checked)
            {
                int msn = int.Parse(comboBox1.SelectedValue.ToString());
                list.Where(item => item.Maison == msn).Where(item => item.etat == false);
            }

            dataGridView1.DataSource = list.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow dt in dataGridView1.Rows)
            {
                if (dt.Cells[0].Value != null)
                {
                    int id =int.Parse(dt.Cells[1].Value.ToString());
                    Reservation r=db.Reservation.Find(id);
                    r.etat = true;
                    db.SaveChanges();
                }
            }
            load();
        }
    }
}
