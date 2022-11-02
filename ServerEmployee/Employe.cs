using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerEmployee
{
    public class Employe : MarshalByRefObject, MiddleEmploye.RPC
    {
        public String cin { get; set; }
        public string nom { get; set; }
        public string prenom {get; set; }
        public double salaire { get; set; }

        public void remplir(String cin, string nom, string prenom, double salaire)
        {
            this.cin = cin;
            this.nom = nom;
            this.prenom = prenom;
            this.salaire = salaire;
        }

        public void augmenterSalaire()
        {
             this.salaire += 1000;
        }


    }
}


