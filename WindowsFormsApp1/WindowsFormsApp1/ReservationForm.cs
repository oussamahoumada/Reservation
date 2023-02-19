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
    public partial class ReservationForm : Form
    {
        public ReservationForm()
        {
            InitializeComponent();
        }
        Db_Hotele db = new Db_Hotele();
        private void ReservationForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = db.Client.ToList();
            comboBox1.ValueMember = "CIN";
            comboBox1.DisplayMember = "Nom";

            comboBox2.DataSource = db.Maison.ToList();
            comboBox2.ValueMember = "id_Maison";
            comboBox2.DisplayMember = "Num";            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idm = int.Parse(comboBox2.SelectedValue.ToString());
            //maison
            Maison maison = db.Maison.Find(idm);

            //reservation
            Reservation r = new Reservation();
            r.id_Maison = idm;
            r.CIN = comboBox1.SelectedValue.ToString();
            r.avance = double.Parse(textBox3.Text);
            r.dateDebut = dateTimePicker1.Value;
            r.dateFin = dateTimePicker2.Value;
            r.date_reservation = DateTime.Now;
            r.etat = false;
            db.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //dernier location du maison 
            int idm = int.Parse(comboBox2.SelectedValue.ToString());
            //int num = int.Parse(comboBox2.Text);
            //Maison m = db.Maison.Find(idm);
            //var res = db.Reservation.Where(item => item.id_Maison == m.id_Maison).Where(it=>it.etat==false);
            var list = from r in db.Reservation 
                       where r.etat == false
                       && r.id_Maison==idm
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
    }
}
