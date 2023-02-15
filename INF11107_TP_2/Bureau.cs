using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_GestionDesSalaires
{
    class Bureau :Employe
    {
       protected float salaireFixe;

        public Bureau (string matricule,string nom,string tel,float salaireFixe):
            base(matricule, nom, tel)
        {
            if (salaireFixe<=0)
            {
                Console.WriteLine("Le salaire doit étre positif");
                salaireFixe = 0;
            }
            this.salaireFixe = salaireFixe;
            

        }
        public override float Salaire()
        {
            return salaireFixe;
        }












    }
}
