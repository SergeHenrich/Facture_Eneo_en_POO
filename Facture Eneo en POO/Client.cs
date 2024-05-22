using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facture_Eneo_en_POO
{
    class Client
    {
        private string Nom;
        public string GetNom()
        {
            return Nom;
        }

        private string Prenom;
        public string GetPrenom()
        {
            return Prenom;
        }

        private string Ville;
        public string GetVille()
        {
            return Ville;
        }
        private string Quartier;
        public string GetQuartier()
        {
            return Quartier;
        }
        private string Identifiant;
        public string GetIdentifiant()
        {
            return Identifiant;
        }
        private int Consommation;

        public int GetConsommation()
        {
            return Consommation;
        }
        public Client(string nom, string prenom, string ville, string quartier, string identifiant, int consommation)

        {

            Nom = nom;
            Prenom = prenom;
            Ville = ville;
            Quartier = quartier;
            Identifiant = identifiant;
            Consommation = consommation;
        }
    }
}
