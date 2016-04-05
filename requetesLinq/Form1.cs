using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DaoGites;

namespace requetesLinq
{
    delegate void RequeteLinq();
    public partial class Fm_principal : Form
    {
        private gitesEntities bd;
        private List<RequeteLinq> lesRequetes;
        public Fm_principal()
        {
            InitializeComponent();
            bd = new gitesEntities();
            lesRequetes = new List<RequeteLinq>();
            listerRequetes();
        }
        private void listerRequetes()
        {
            cb_requete.Items.Add("requete0");
            lesRequetes.Add(requete0);
            cb_requete.Items.Add("requete1");
            lesRequetes.Add(requete1);
            cb_requete.Items.Add("requete2");
            lesRequetes.Add(requete2);
            cb_requete.Items.Add("requete3");
            lesRequetes.Add(requete3);
            cb_requete.Items.Add("requete4");
            lesRequetes.Add(requete4);
            cb_requete.Items.Add("requete5");
            lesRequetes.Add(requete5);
            cb_requete.Items.Add("requete6");
            lesRequetes.Add(requete6);
            cb_requete.Items.Add("requete7");
            lesRequetes.Add(requete7);
            cb_requete.Items.Add("requete8");
            lesRequetes.Add(requete8);
        }
        private void requete0()
        {
            var req = from g in bd.gites
                      select g.nomGite;
            foreach (string nom in req)
            {
                tb_resultat.AppendText(nom);
                tb_resultat.AppendText(Environment.NewLine);
            }

        }
        private void requete1()
        {
            var req1 = from g in bd.gites
                       from t in bd.tarifs
                       where g.numGite == t.numGite
                       select new {g.nomGite, t.numPeriode, t.prixSemaine };
            foreach (var t in req1)
            {
                tb_resultat.AppendText(t.nomGite+ " coûte  " + t.prixSemaine + " pendant la période "+ t.numPeriode);
                tb_resultat.AppendText(Environment.NewLine);
            }

        }

        private void requete2()
        {
            var req2 = from c in bd.contrats
                       where c.annule == 1
                       select new { c.numContrat, c.dateContrat, c.numClient };
            foreach (var t in req2)
            {
                tb_resultat.AppendText("le contrat n° "+ t.numContrat + " réservé le " + t.dateContrat + " par le client n° " + t.numClient +
                    " a été annulé");
                tb_resultat.AppendText(Environment.NewLine);
            }
        }

        private void requete3()
        {
            var req3 = from ctr in bd.contrats
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
            foreach (var t in req3)
            {
                tb_resultat.AppendText("le client " + t.nomClient + " a rapporté un montant total de " + t.CA );
                tb_resultat.AppendText(Environment.NewLine);
            }
        }

        private void requete4()
        {
            var req4 = from ctr in bd.contrats
                       from plan in bd.plannings
                       from tf in bd.tarifs
                       from sem in bd.semaines
                       where ctr.numContrat == plan.numContrat
                       && plan.numGite == tf.numGite
                       && plan.numSemaine == sem.numsemaine
                       && sem.numPeriode == tf.numPeriode
                       group tf by new { ctr.numContrat }
                           into CaContrat
                           let CA = CaContrat.Sum(i => i.prixSemaine)
                           select new
                           {
                               CaContrat.Key.numContrat,
                               CA
                           };
            foreach (var t in req4)
            {
                tb_resultat.AppendText("le contrat n° " + t.numContrat + " a permis de réaliser un chiffre d'affaire de " + t.CA);
                tb_resultat.AppendText(Environment.NewLine);
            }
        }

        private void requete5()
        {
            var req5 = from ctr in bd.contrats
                       from plan in bd.plannings
                       from cli in bd.clients
                       from g in bd.gites
                       where ctr.numContrat == plan.numContrat
                       && ctr.numClient == cli.numClient
                       && plan.numGite == g.numGite
                       select new { cli.nomClient };
                       
            foreach (var t in req5.Distinct())
            {
                tb_resultat.AppendText("le client " +t.nomClient + " a au moins loué un gite");
                tb_resultat.AppendText(Environment.NewLine);
            }
        }
        private void requete6()
        {
            var req6 = from ctr in bd.contrats
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

            foreach (var t in req6.Distinct())
            {
                tb_resultat.AppendText("le client " + t.nomClient + " a loué plus de 3 gites");
                tb_resultat.AppendText(Environment.NewLine);
            }
        }

        private void requete7()
        {
            var req71 = from ctr in bd.contrats
                       from plan in bd.plannings
                       from cli in bd.clients
                       from s in bd.semaines
                       from p in bd.periodes
                       where ctr.numContrat == plan.numContrat
                       && ctr.numClient == cli.numClient
                       && plan.numSemaine == s.numsemaine
                       && s.numPeriode == p.numPeriode
                      && p.numPeriode == 1
                       select cli;

            var req72 = from ctr in bd.contrats
                        from plan in bd.plannings
                        from cli in bd.clients
                        from s in bd.semaines
                        from p in bd.periodes
                        where ctr.numContrat == plan.numContrat
                        && ctr.numClient == cli.numClient
                        && plan.numSemaine == s.numsemaine
                        && s.numPeriode == p.numPeriode
                       && p.numPeriode == 2
                        select cli;

            var req7 = req71.Union(req72);

            foreach (var t in req7.Distinct())
            {
                tb_resultat.AppendText("le client " + t.nomClient + " a loué un gîte à la fois en période 1 et en période 2");
                tb_resultat.AppendText(Environment.NewLine);
            }
        }

        private void requete8()
        {

        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            if (cb_requete.SelectedIndex != -1)
            {
                tb_resultat.Clear();
                lesRequetes[cb_requete.SelectedIndex]();
            }

        }

    }
}
