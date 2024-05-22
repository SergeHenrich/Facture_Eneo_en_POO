using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facture_Eneo_en_POO
{
    class CalculateurFacture
    {
        public double CalculerFactureBT(int consommation)
        {

            double total = 0;

            if (consommation <= 110)
            {
                total = consommation * 50;
            }
            else if (consommation <= 400)
            {
                total = (110 * 50) + ((consommation - 110) * 79);
            }
            else if (consommation <= 800)
            {
                total = (110 * 50) + (290 * 79) + ((consommation - 400) * 94);
            }
            else if (consommation <= 2000)
            {
                total = (110 * 50) + (298 * 79) + (488 * 94) + ((consommation - 800) * 99);
            }
            return total;
        }
        public double CalculerFactureMT(int consommation)
        {
            const double primeFixe = 3700;
            const double tarifParKWh = 150;

            return primeFixe + (tarifParKWh * consommation);
        }
    }
}
    

