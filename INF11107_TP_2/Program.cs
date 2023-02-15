using System;
using System.Collections.Generic;
using System.Linq;

namespace TP2_GestionDesSalaires
{
    class Program
    {
        static List<Employe> ListEmployes = new List<Employe>();
        static void Main(string[] args)
        {
            bool sortir = false;
            while (!sortir)
            {
                Console.Clear();
                char reponse;

                Console.WriteLine("Choisir l'action à faire parmi les options suivantes:");
                Console.WriteLine("1-Embaucher des employés");
                Console.WriteLine("2-Spécifier les détails pour les employés concernés");
                Console.WriteLine("3-Calculer et afficher les salaires ainsi que le salaire moyen");
                reponse = char.Parse(Console.ReadLine());
                Console.Clear();
                switch (reponse)
                {
                    case '1':
                        MenuEmbaucherEmploye();
                        break;

                    case '2':
                        MenuSpecifierDetail();
                        break;

                    case '3':
                        MenuCalculerSalaire();
                        break;


                    default:
                        Console.WriteLine("Votre choix n'est pas valide ,veuillez choisir une option de menu");
                        break;

                }
            }
        }

        //========================Menu Embaucher Employé========================================
        static void MenuEmbaucherEmploye()
        {
            char reponse;

            Console.WriteLine("Choisir la catégorie de l'employé:");
            Console.WriteLine("1-Bureau");
            Console.WriteLine("2-Par tâche");
            Console.WriteLine("3-Commercial");
            Console.WriteLine("4-Superviseur");
            Console.WriteLine("Sinon taper 5 pour sortir");
            reponse = char.Parse(Console.ReadLine());
            Console.Clear();
            switch (reponse)
            {
                case '1':
                    AjouterEmploye("Bureau");
                      
                    break;

                case '2':
                    AjouterEmploye("ParTache");
                    break;

                case '3':
                    AjouterEmploye("Commercial"); ;
                    break;

                case '4':
                    AjouterEmploye("Superviseur"); ;
                    break;

                case '5':
                  
                    break;


                default:
                    Console.WriteLine("Votre choix n'est pas valide ,veuillez choisir une option de menu");
                    break;

            }

            
        }

        //========================Ajouter employé========================================
        static void AjouterEmploye(string categorie) 
        {
            string nom, matricule, tel;
            float salaireFixe, tauxHoraire, montantObjectif;

            Console.WriteLine("Saisir le nom de l'employé");
            nom = Console.ReadLine();
            Console.WriteLine("Saisir le matricule de l'employé");
            matricule = Console.ReadLine();
            Console.WriteLine("Saisir le num de téléphone de l'employé");
            tel = Console.ReadLine();
            switch (categorie)
            {
                case "Bureau":
                    do
                    {
                        Console.WriteLine("Saisir le salaire fixe de l'employé:la valeur doit étre positive");
                        salaireFixe = float.Parse(Console.ReadLine());

                    } while (salaireFixe<=0);
                    
                    ListEmployes.Add(new Bureau(matricule,nom,tel,salaireFixe));
                    break;

                case "ParTache":
                    do
                    {
                        Console.WriteLine("Saisir le taux horaire de l'employé:la valeur doit étre positive");
                        tauxHoraire = float.Parse(Console.ReadLine());

                    } while (tauxHoraire <= 0);
                    
                    ListEmployes.Add(new Tache(matricule,nom,tel,tauxHoraire));
                    break;

                case "Commercial":
                    do
                    {
                        Console.WriteLine("Saisir le salaire fixe de l'employé:la valeur doit étre positive");
                        salaireFixe = float.Parse(Console.ReadLine());

                    } while (salaireFixe <= 0);
                    ListEmployes.Add(new Commercial(matricule, nom, tel, salaireFixe));
                    break;

                case "Superviseur":
                    do
                    {
                        Console.WriteLine("Saisir le salaire fixe de l'employé:la valeur doit étre positive");
                        salaireFixe = float.Parse(Console.ReadLine());

                    } while (salaireFixe <= 0);
                   
                    do
                    {
                        Console.WriteLine("Saisir le montant de l'objectif de vente:la valeur doit étre positive");
                        montantObjectif = float.Parse(Console.ReadLine());

                    } while (montantObjectif<=0);
                    
                    ListEmployes.Add(new Superviseur(matricule, nom, tel, salaireFixe,montantObjectif));
                    break;

                default:
                    break;
            }

            Console.Clear();
            Console.WriteLine("l'employé est ajouté avec succès.");
            Console.WriteLine("Taper sur entrer pour revenir au menu principal.");
            Console.ReadLine();
        }

        //========================Chercher employé par matricule========================================

        static Employe ChercherEmployeParMatricule(string matricule)
        {
          return  ListEmployes.Where(a => a.Matricule == matricule).FirstOrDefault();
        }

        //========================Menu spécifier détail========================================

        static void MenuSpecifierDetail()
        {
            float montantVente, totalDesVentes;
            int nbrHeures;
            string matricule;
            Console.Clear();

            Console.WriteLine("Saisir le matricule de l'employé à modifié");
            matricule = Console.ReadLine();
            Employe employe = ChercherEmployeParMatricule(matricule);
            if (employe==null)
            {
                Console.WriteLine("Aucun employé existe avec ce matricule");
                Console.WriteLine("Taper sur entrer pour revenir au menu principal.");
                Console.ReadLine();

            }
            else
            {
              string typeEmploye=employe.GetType().Name;
                switch (typeEmploye)
                {
                    case "Bureau":
                        Console.WriteLine("Aucun mise à jour possible pour les employés de catégorie Bureau");
                        
                        break;

                    case "Tache":
                        do
                        {
                            Console.WriteLine("Veuillez saisir le nombre d'heures travailées ");
                            nbrHeures = int.Parse(Console.ReadLine());

                        } while (nbrHeures<=0);
                       
                        Console.WriteLine("La modification est apportée.");
                        ((Tache)employe).NbrHeures = nbrHeures;
                        break;

                    case "Commercial":
                        do
                        {
                            Console.WriteLine("Saisir le montant des ventes du commercial");
                            montantVente = float.Parse(Console.ReadLine());

                        } while (montantVente <= 0);
                        ((Commercial)employe).MontantVente = montantVente;
                        Console.WriteLine("La modification est apportée.");

                        break;

                    case "Superviseur":
                        do
                        {
                            Console.WriteLine("Saisir le total des ventes du superviseur");
                            totalDesVentes = float.Parse(Console.ReadLine());

                        } while (totalDesVentes <= 0);
                        Console.WriteLine("La modification est apportée.");
                        ((Superviseur)employe).TotalDesVentes = totalDesVentes;
                        break;

                    default:
                        break;
                }
                Console.WriteLine("Taper sur entrer pour revenir au menu principal.");
                Console.ReadLine();
            }

        }

        //========================Menu calcul salaire========================================

        static void MenuCalculerSalaire()
        {
            float sommeDesSalaires = 0;
            float salaireMoyen =0;
            Console.WriteLine("Voici la liste des salaires des employés");
            foreach (var employe in ListEmployes)
            {
                employe.AfficherSalaire();
                sommeDesSalaires += employe.Salaire();  
            }
            if (ListEmployes.Count !=0)
            {
                salaireMoyen = sommeDesSalaires / ListEmployes.Count;

            }
            Console.WriteLine("=======================================================================");
            Console.WriteLine("Le salaire moyen est égale à :{0}", salaireMoyen);
            Console.WriteLine("Taper sur entrer pour revenir au menu principal.");
            Console.ReadLine();

        
}
    }
}
