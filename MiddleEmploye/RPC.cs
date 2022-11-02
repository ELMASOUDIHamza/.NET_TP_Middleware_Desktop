using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEmploye
{
    public interface RPC
    {
        String cin { get; set; }
        String nom { get; set; }
        String prenom { get; set; }
        double salaire { get; set; }

        void remplir(String cin, string nom, string prinom, double salaire);


        void augmenterSalaire();
        
    }
}
