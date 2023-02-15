using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_GestionDesSalaires
{
    abstract class Employe
    {
        protected string matricule;
        protected string nom;
        protected string tel;
        public Employe(string matricule,string nom,string tel) 
        {
            this.matricule = matricule;
            this.nom = nom;
            this.tel = tel;

        }

        public string Matricule
        {
            get
            {
                return matricule;
            }
            set
            {
                matricule = value;
            }
        }

        public abstract float Salaire();
        

        public virtual void AfficherSalaire()
        {
            Console.WriteLine("Le salaire de l'employé {0} est :{1}", nom, Salaire());
        }





















    }

}
