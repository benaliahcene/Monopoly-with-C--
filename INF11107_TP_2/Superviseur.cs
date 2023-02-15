using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_GestionDesSalaires
{
    class Superviseur : Bureau
    {
        private float objectif;
        private float totalDesVentes = 0;


        

        public Superviseur(string matricule,string nom,string tel, float salaireFixe,float objectif):
            base(matricule, nom, tel, salaireFixe)
        {
            this.objectif = objectif;
        }

     
        public float TotalDesVentes
        {
            set
            {

                if (value > 0)
                {
                    totalDesVentes = value;
                }

            }


        }
        public override float Salaire()
        {
            if (totalDesVentes>=objectif)
            {
                return salaireFixe * 1.1f;
            }
            return salaireFixe;
        }







    }
}
