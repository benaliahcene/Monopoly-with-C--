using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_GestionDesSalaires
{
    class Commercial : Bureau
    {
        private float montantVente;

        public Commercial(string matricule, string nom, string tel, float salaireFixe) :
           base(matricule, nom, tel, salaireFixe)
        {
            this.montantVente = 0;
        }

        public Commercial(string matricule,string nom,string tel, float salaireFixe,float montantVente):
            base(matricule, nom, tel, salaireFixe)
        {
            this.montantVente = montantVente;
        }

        public float MontantVente 
        {
            set 
            {
                
                if (value>0)
                {
                    montantVente = value;
                }
            
            }
        
        
        }
        public override float Salaire()
        {
            return salaireFixe+0.001f*montantVente;
        }







    }
}
