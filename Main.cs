using EasyPlants;
using EasyPlants.Paramétrage;
using EasyPlants.Production;

using EasyPlants.SuiviCommandes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPlants
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Mn_ListeUser_Click(object sender, EventArgs e)
        {
            Utilisateur Utilisateur = new Utilisateur();
            Utilisateur.ShowDialog();
        }

   

        private void Mn_PointVente_Click(object sender, EventArgs e)
        {
            PointVente PointVente = new PointVente();
            PointVente.ShowDialog();
        }

        private void Mn_Quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
            //Login f = new Login();
            //f.Dispose();
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.Equals((sender as Button).Name, @"CloseButton"))
            {

            }
        // Do something proper to CloseButton.
    else
            {

            }
        // Then assume that X has been clicked and act accordingly.
}

        private void Mn_Rayon_Click(object sender, EventArgs e)
        {
            DoubleForm f2 = new DoubleForm("Rayon","Liste des Rayons d'Articles");
            f2.Show();
        }

        private void Mn_Livreur_Click(object sender, EventArgs e)
        {
            DoubleForm f2 = new DoubleForm("Livreur", "Liste des Livreurs");
            f2.Show();
        }

        private void Mn_Banque_Click(object sender, EventArgs e)
        {
            DoubleForm f2 = new DoubleForm("Banque", "Liste des Banques");
            f2.Show();
        }

        private void Mn_Profil_Click(object sender, EventArgs e)
        {
            DoubleForm f2 = new DoubleForm("Profil", "Liste des Profils Utilisateurs");
            f2.Show();
        }

        private void Mn_MoyenTransport_Click(object sender, EventArgs e)
        {
            DoubleForm f2 = new DoubleForm("MoyenTrans", "Liste des Moyens de Transport");
            f2.Show();
        }

        private void Mn_TypeClient_Click(object sender, EventArgs e)
        {
            DoubleForm f2 = new DoubleForm("TypeClient", "Liste des Types de Clients");
            f2.Show();
        }

        private void Mn_ModeReg_Click(object sender, EventArgs e)
        {
            DoubleForm f2 = new DoubleForm("ModeRegl", "Liste des Modes de Règlements");
            f2.Show();
        }

        private void Mn_Colisage_Click(object sender, EventArgs e)
        {
            DoubleForm f2 = new DoubleForm("Colisage", "Liste des Colisages");
            f2.Show();
        }

        private void Mn_Unite_Click(object sender, EventArgs e)
        {
            DoubleForm f2 = new DoubleForm("Unite", "Liste des Unités de Mesure");
            f2.Show();
        }

        private void Mn_TypeProduction_Click(object sender, EventArgs e)
        {
            DoubleForm f2 = new DoubleForm("TypeProduction", "Liste des Types de Production");
            f2.Show();
        }

        private void Mn_TypeComptage_Click(object sender, EventArgs e)
        {
            DoubleForm f2 = new DoubleForm("TypeComptage", "Liste des Types de Comptage");
            f2.Show();
        }

        private void Mn_EspeceVar_Click(object sender, EventArgs e)
        {
            DoubleForm f2 = new DoubleForm("Espece", "Liste des Especes de Plantes");
            f2.Show();
        }

        private void Mn_Famille_Click(object sender, EventArgs e)
        {
            Famille f2 = new Famille();
            f2.Show();
        }

        private void Mn_Coordonnee_Click(object sender, EventArgs e)
        {
            Coordonnees f2 = new Coordonnees();
            f2.Show();
        }

        private void Mn_AchatConsigne_Click(object sender, EventArgs e)
        {
          Consignes.Achat frmAchat= new Consignes.Achat();
            frmAchat.Show();
        }

        private void Mn_SortieConsigne_Click(object sender, EventArgs e)
        {
            Consignes.Sortie frmSortie = new Consignes.Sortie();
            frmSortie.Show();
        }

        private void Mn_RetourConsigne_Click(object sender, EventArgs e)
        {
            Consignes.Retour frmRetour = new Consignes.Retour();
            frmRetour.Show();
        }

        private void Mn_EtatConsigne_Click(object sender, EventArgs e)
        {
            Consignes.Etatcs f2 = new Consignes.Etatcs();
           f2.Show();
        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            Stock.AjoutArticle f2 = new Stock.AjoutArticle();
            f2.Show();
        }
     
        //private void Mn_Compteurs_Click(object sender, EventArgs e)
        //{
        //    Compteurs compteur = new Compteurs();
        //    compteur.Show();
        //}

        private void Mn_ListPG_Click(object sender, EventArgs e)
        {
            PorteGref porteGref = new PorteGref();
            porteGref.Show();
        }

        

        private void radMenuItem4_Click(object sender, EventArgs e)
        {
            Stock.EtatStock f2 = new Stock.EtatStock();
            f2.Show();
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            Planning f2 = new Planning();
            f2.Show();
        }

        private void Mn_BL_Click(object sender, EventArgs e)
        {
            Livraison.BonLivraison f2 = new Livraison.BonLivraison();
            f2.Show();
        }

        private void Mn_ListeCommandes_Click(object sender, EventArgs e)
        {
            SuiviCommande suiv = new SuiviCommande();
            suiv.Show();
        }




        private void Mn_ListVariete_Click(object sender, EventArgs e)
        {
            Variete var = new Variete();
            var.Show();
        }

        private void Mn_ListPG_Click_1(object sender, EventArgs e)
        {
            PorteGref pr = new PorteGref();
            pr.Show();
        }

        

        

        private void Mn_BnComm_Click(object sender, EventArgs e)
        {
            Commande com = new Commande();
            com.Show();
        }
    }
}
