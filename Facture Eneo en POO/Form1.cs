using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Facture_Eneo_en_POO
{
    public partial class Form1 : Form
    {
        private CalculateurFacture calculateurFacture;

        private Client client;
        private Facture facture;

        public Form1()
        {
            InitializeComponent();
            calculateurFacture = new CalculateurFacture();
        }

        private void ActiverDesactiverControls(bool enable)
        {

            txtNom.ReadOnly = !enable;

            txtPrenom.ReadOnly = !enable;
            txtVille.ReadOnly = !enable;

            txtQuartier.ReadOnly = !enable;

            txtIdentifiant.ReadOnly = !enable;

            txtConsommation.ReadOnly = !enable;

            rbBT.Enabled = !enable;

            rbMT.Enabled = !enable;

            rtbFacture.ReadOnly = !enable;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCalculer_Click(object sender, EventArgs e)
        {
            string nomClient = txtNom.Text;
            string prenomClient = txtPrenom.Text;

            string villeClient = txtVille.Text;

            string quartierClient = txtQuartier.Text;

            string identifiantClient = txtIdentifiant.Text;

            int consommation;

            if (int.TryParse(txtConsommation.Text, out consommation) && consommation >= 0)
            {

                double montantTotal;

                if (rbBT.Checked)
                {

                    montantTotal = calculateurFacture.CalculerFactureBT(consommation);
                }
                else if (rbMT.Checked)
                {
                    montantTotal = calculateurFacture.CalculerFactureMT(consommation);
                }

                else
                {
                    MessageBox.Show("Veuillez sélectionner une catégorie de client.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                client = new Client(nomClient, prenomClient, villeClient, quartierClient, identifiantClient, consommation);
                facture = new Facture(client, montantTotal);
                rtbFacture.Text = facture.GenererContenu();
            }

            else
            {

                MessageBox.Show("Veuillez saisir une consommation valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        private void btnModifier_Click(object sender, EventArgs e)
        {
            ActiverDesactiverControls(true);
            MessageBox.Show("Vous pouvez maintenant modifier la facture.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEnregister_Click(object sender, EventArgs e)
        {
            string nomClient = txtNom.Text;
            string prenomClient = txtPrenom.Text;

            string villeClient = txtVille.Text;

            string quartierClient = txtQuartier.Text;

            string identifiantClient = txtIdentifiant.Text;

            int consommation;

            if (int.TryParse(txtConsommation.Text, out consommation) && consommation >= 0)
            {

                double montantTotal;

                if (rbBT.Checked)
                {

                    montantTotal = calculateurFacture.CalculerFactureBT(consommation);
                }
                else if (rbMT.Checked)
                {
                    montantTotal = calculateurFacture.CalculerFactureMT(consommation);
                }

                else
                {
                    MessageBox.Show("Veuillez sélectionner une catégorie de client.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                client = new Client(nomClient, prenomClient, villeClient, quartierClient, identifiantClient, consommation);
                facture = new Facture(client, montantTotal);
                rtbFacture.Text = facture.GenererContenu();
            }

            else
            {

                MessageBox.Show("Veuillez saisir une consommation valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ActiverDesactiverControls(false);

            string dateEmission = DateTime.Now.ToString("yyyyMMdd");

            string nomFichier = "Facture_" + txtIdentifiant.Text + " " + dateEmission;

            int numSequence = 1;

            string cheminFichier;

            do
            {
                cheminFichier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),

            nomFichier + " " + numSequence + ".txt");

                if (!File.Exists(cheminFichier))

                {
                    break;

                }

                numSequence++;

            } while (true);

            File.WriteAllText(cheminFichier, rtbFacture.Text);

            MessageBox.Show("La modification de la facture a été enregistrée dans: " +

            cheminFichier, "Modification    enregistrée", MessageBoxButtons.OK,

            MessageBoxIcon.Information);

        }


        private void btnCharger_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Fichiers texte (*.txt)|*.txt Tous les fichiers (*.*)|*.*",

                FilterIndex = 1,
                RestoreDirectory = true

            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)

            {

                try

                {
                    string contenufacture = File.ReadAllText(openFileDialog.FileName);

                    rtbFacture.Text = contenufacture;

                }
                catch (Exception ex)

                {
                    MessageBox.Show("Une erreur s'est produite lors du chargement du fichier: " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
