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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        Db_Hotele db = new Db_Hotele();
        private void Home_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = db.Client.ToList();
            comboBox1.ValueMember = "CIN";
            comboBox1.DisplayMember = "Nom";

            comboBox2.DataSource = db.Maison.OrderByDescending(item=>item.id_Maison).ToList();
            comboBox2.ValueMember = "id_Maison";
            comboBox2.DisplayMember = "Num";

            var list = from m in db.Maison
                       join r in db.Reservation on
                       m.id_Maison equals r.id_Maison
                       join c in db.Client
                       on r.CIN equals c.CIN
                       orderby r.dateDebut descending
                       where r.etat==false
                       select
                       new{
                            CIN = r.CIN,
                            Maison = m.Num,
                            Prix = r.prix,
                            Avance = r.avance,
                            prixTotale = (r.prix * r.duree),
                            Reste = ((r.prix * r.duree) - r.avance), 
                            DateDebut = r.dateDebut,
                            DateFin = r.dateFin,
                            Durée= r.duree,
                            etat=r.etat
                       };
            dataGridView1.DataSource = list.ToList();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var list = from m in db.Maison
                       join r in db.Reservation on
                       m.id_Maison equals r.id_Maison
                       join c in db.Client
                       on r.CIN equals c.CIN
                       select
                       new
                       {
                           CIN = r.CIN,
                           Maison = m.Num,
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
                string cin = comboBox1.SelectedValue.ToString();
                list.Where(item => item.CIN == cin);
            }
            if (checkBox1.Checked)
            {
                int msn = int.Parse(comboBox2.SelectedValue.ToString());
                list.Where(item => item.Maison == msn).Where(item => item.etat==false);
            }

            dataGridView1.DataSource = list.ToList();
        }
    }
}