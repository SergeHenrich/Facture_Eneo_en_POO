using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facture_Eneo_en_POO
{
    class Facture
    {
        public Client Client { get; set; }
        private double MontantTotal;
        public double GetMontantTotal()
        {
            return MontantTotal;
        }

        private string DateEmission;
        public string GetDateEmission()
        {
            return DateEmission;
        }

        public Facture(Client client, double montantTotal)

        {
            Client = client;
            MontantTotal = montantTotal;
            DateEmission = DateTime.Now.ToString("dd-MM-yyyy");

        }

        public string GenererContenu()

        {

            return "Facture d'électricité pour " + Client.GetPrenom()  + " " + Client.GetNom() + " (ID: " + Client.GetIdentifiant() + ") émise le " + DateEmission + " :\n" +
        "Ville; " + Client.GetVille() + "\n" + "Quartier: " + Client.GetQuartier() + "\n" + "Consommation: " + Client.GetConsommation() + " kWh\n" +
        "Montant total: " + MontantTotal + " FCFA\n";

        }
    }
}
