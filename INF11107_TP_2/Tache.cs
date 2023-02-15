using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_GestionDesSalaires
{
    class Tache : Employe 
    {
        private float tauxHoraire;
        private int nbrHeures;

        public Tache (string matricule,string nom,string tel,float tauxHoraire):
            base(matricule,nom,tel)
        {
            if (tauxHoraire<=0)
            {
                Console.WriteLine("le Taux doit étre positif");
                tauxHoraire = 0;
            }
            this.tauxHoraire = tauxHoraire;
            this.nbrHeures = 0;
        }
        public int NbrHeures 
        {
            set 
            {
                
                if (value>=0)
                {
                    nbrHeures = value;
                }
            
            }
        
        
        
        }
        public override float Salaire()
        {
            return nbrHeures*tauxHoraire;

        }












    }
}
