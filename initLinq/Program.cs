using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaoGites;

namespace initLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            int choix;
            List<int> liste = new List<int> { 4, 6, 1, 9, 5, 15, 8, 3, 20, 7};
            gitesEntities bd = new gitesEntities();
            do
            {
                do
                {

                    Console.WriteLine("1 - liste des nombres > 5 sans linq ");
                    Console.WriteLine("2 - liste des nombres > 5 avec linq triée");
                    Console.WriteLine("3 - liste des nombres > 5 triée en une seule requete");
                    Console.WriteLine("4 - liste des gites qui ont plus de 2 épis classés par ordre alphabétique ");
                    Console.WriteLine("5 - liste des gites qui ont plus de 2 épis classés par ordre alphabétique(objet anonyme)");
                    Console.WriteLine("6 - liste des gites réservés par le client CAMUS");
                    Console.WriteLine("7 - liste des gites réservés par le client CAMUS (jointure traditionnelle) ");
                    Console.WriteLine("8 -  nombre de gites réservés par contrat ");
                   	Console.WriteLine("9 -  chiffre d'affaires généré par client");
                    Console.WriteLine("10 - fin du traitement");


                    choix = Int32.Parse(Console.ReadLine());

                } while (choix < 0 || choix > 10);

                switch (choix)
                {
                    case 1:
                       
                        Console.WriteLine("1 - liste des nombres > 5 sans Linq");
                        foreach (int i in liste)
                        {
                            if (i > 5)
                            {
                                Console.WriteLine(i);
                            }
                        }
                                         
                        break;
                    case 2:
                        Console.WriteLine("2 - liste des nombres > 5 avec linq triée");
                        IEnumerable<int> requeteFiltree = from i in liste
                                                          where i > 5
                                                          select i;
                        foreach (int i in requeteFiltree)
                        {
                            Console.WriteLine(i);
                        }
                        
                        break;
                    case 3:
                        Console.WriteLine("3 - requête ordonnée en une seule requete");
                        IEnumerable<int> requete = from i in liste
                                                   where i > 5
                                                   orderby i
                                                   select i;
                        foreach (int i in requete)
                        {
                            Console.WriteLine(i);
                        }
                       
                        break;
                    case 4:

                         Console.WriteLine("4 - liste des gites qui ont plus de 2 épis classés par ordre alphabétique");
                            
                         IEnumerable<string> r1 = from git in bd.gites
                                                 where git.nbEpis > 2
                                                 orderby git.nomGite
                                                 select git.nomGite;
                        foreach (string nom in r1)
                        {
                            Console.WriteLine(nom);
                        }

                        break;
                    case 5:

                        Console.WriteLine("5 - liste des gites qui ont plus de 2 épis classés par ordre alphabétique(objet anonyme)");
                     /*   var req = from git in bd.gites
                                  where git.nbEpis > 2
                                  orderby git.nomGite
                                  select new { git.nomGite, git.villeGite };*/
                        var req = bd.gites.Where(g => g.nbEpis > 2).OrderBy(g => g.nomGite).Select(g => new { g.nomGite, g.villeGite });

                        foreach (var g in req)
                            Console.WriteLine(g.nomGite + " " + g.villeGite);
                       break;
                    case 6:
                       Console.WriteLine("6 - liste des gites réservés par le client CAMUS)");
                    /*   var r3 = from git in bd.gites
                                join plan in bd.plannings on git.numGite equals plan.numGite
                                join ctr in bd.contrats on plan.numContrat equals ctr.numContrat
                                join cli in bd.clients on ctr.numClient equals cli.numClient
                                where cli.nomClient == "CAMUS"
                                select new { git.nomGite, git.villeGite, ctr.numContrat };*/
                       var r3 = bd.gites.Join(bd.plannings, g => g.numGite, p => p.numGite, (g, p) => new { g.nomGite, g.villeGite, p.numContrat }).
                               Join(bd.contrats, p => p.numContrat, c => c.numContrat, (p, c) => new { p.nomGite, p.villeGite, p.numContrat, c.numClient }).
                               Join(bd.clients, c => c.numClient, cl => cl.numClient, (c, cl) => new { c.nomGite, c.villeGite, c.numContrat, c.numClient, cl.nomClient }).
                               Where(cl => cl.nomClient == "CAMUS").ToList();

                        
                       foreach (var obj in r3)
                       {
                           Console.WriteLine("Gites loués par JEANNEAU {0} \t {1} contrat n°{2}", obj.nomGite, obj.villeGite, obj.numContrat);
                       }
                        break;
                    case 7:
                        Console.WriteLine("7 - liste des gites réservés par le client CAMUS (jointure traditionnelle)");
                        var r4 = from git in bd.gites
                                 from plan in bd.plannings
                                 from ctr in bd.contrats
                                 from cli in bd.clients
                                 where git.numGite == plan.numGite
                                 && plan.numContrat == ctr.numContrat
                                 && ctr.numClient == cli.numClient
                                 && cli.nomClient == "CAMUS"
                                 select new { git.nomGite, git.villeGite, ctr.numContrat };
                        foreach (var obj in r4.Distinct())
                        {
                            Console.WriteLine("Gites loués par JEANNEAU {0} \t {1} contrat n°{2}", obj.nomGite, obj.villeGite, obj.numContrat);
                        }
                        break;
                    case 8:

                        Console.WriteLine("8 - nombre de gites loués par contrat ");
                        var req5 = from ctr in bd.contrats
                                   from plan in bd.plannings
                                   from cli in bd.clients
                                   where ctr.numContrat == plan.numContrat
                                   && ctr.numClient == cli.numClient
                                   group ctr by new { ctr.numContrat, cli.nomClient }
                                       into nbGitesContrat
                                       select new
                                       {
                                           nbGitesContrat.Key.numContrat,
                                           nbGitesContrat.Key.nomClient,
                                           nbreGites = nbGitesContrat.Count()
                                       };
                        foreach (var obj in req5)
                        {
                            Console.WriteLine("le client : {0} a loué {1} gite(s) avec le contrat n°{2}", obj.nomClient, obj.nbreGites,
                                obj.numContrat);
                        }
                        break;
						case 9:

                        Console.WriteLine("9 - chiffre d'affaires généré par client ");
                        var req6 = from ctr in bd.contrats
                                   from plan in bd.plannings
                                   from cli in bd.clients
                                   from tf in bd.tarifs
                                   from sem in bd.semaines
                                   where ctr.numContrat == plan.numContrat
                                   && ctr.numClient == cli.numClient
                                   && plan.numGite == tf.numGite
                                   && plan.numSemaine == sem.numsemaine
                                   && sem.numPeriode == tf.numPeriode
                                   group tf by new { cli.nomClient }
                                       into CaClient
                                       let CA = CaClient.Sum(i => i.prixSemaine)
                                       select new
                                       {
                                           CaClient.Key.nomClient,
                                           CA
                                       };
                        foreach (var obj in req6)
                        {
                            Console.WriteLine("le client : {0} a généré un chiffre d'affaires de {1} euros", obj.nomClient, obj.CA);
                        }
                      
        
                        break;
                    case 10:

                        Console.WriteLine("Fin du traitement");
                        break;
                   
                }
                Console.WriteLine("\n");
            }
            while (choix != 10);
            
            Console.ReadLine();
              
        }
    }
}
