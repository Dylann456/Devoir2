using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BiblioAction;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Action
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
  
        Dictionary<string, List<BiblioAction.ActionAchetee>> dico;
        List<BiblioAction.ActionReelle> lesActionsReelles;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dico = new Dictionary<string, List<ActionAchetee>>();
            #region jeu d'essais pour le dico
            dico.Add
                ("Enzo", new List<ActionAchetee>()
{
                new ActionAchetee()
                {
                    CodeAction = "AAPL",
                    NomAction = "Apple",
                    ValeurAction = 200,
                    PrixAchat = 210,
                    Quantite = 10
                },
                new ActionAchetee()
                {
                    CodeAction = "MSFT",
                    NomAction = "Microsoft",
                    ValeurAction = 140,
                    PrixAchat = 100,
                    Quantite = 50
                },
                new BiblioAction.ActionAchetee()
                {
                    CodeAction = "TWTR",
                    NomAction = "Twitter",
                    ValeurAction = 40,
                    PrixAchat = 35,
                    Quantite = 20
                },
                new ActionAchetee()
                {
                    CodeAction = "IBM",
                    NomAction = "International Business Machines",
                    ValeurAction = 140,
                    PrixAchat = 110,
                    Quantite = 40
                }
}
);
            dico.Add
            ("Noa", new List<ActionAchetee>()
                {
                new ActionAchetee()
                {
                    CodeAction = "FB",
                    NomAction = "Facebook",
                    ValeurAction = 180,
                    PrixAchat = 210,
                    Quantite = 10
                },
                new ActionAchetee()
                {
                    CodeAction = "AXA",
                    NomAction = "Axa assurances",
                    ValeurAction = 25,
                    PrixAchat = 15,
                    Quantite = 20
                },
                new ActionAchetee()
                {
                    CodeAction = "SAP",
                    NomAction = "SAP SE",
                    ValeurAction = 120,
                    PrixAchat = 100,
                    Quantite = 30
                }
            }
            );
            dico.Add
            ("Lilou", new List<ActionAchetee>()
                {
                new ActionAchetee()
                {
                    CodeAction = "TWTR",
                    NomAction = "Twitter",
                    ValeurAction = 40,
                    PrixAchat = 25,
                    Quantite = 50
                },
                new ActionAchetee()
                {
                    CodeAction = "INTC",
                    NomAction = "Intel Corporation",
                    ValeurAction = 50,
                    PrixAchat = 35,
                    Quantite = 15
                },
                new ActionAchetee()
                {
                    CodeAction = "VMW",
                    NomAction = "VMware",
                    ValeurAction = 145,
                    PrixAchat = 150,
                    Quantite = 30
                },
                new ActionAchetee()
                {
                    CodeAction = "TXN",
                    NomAction = "Texas Instrument Incorporated",
                    ValeurAction = 130,
                    PrixAchat = 140,
                    Quantite = 25
                }
            }
            );
            #endregion

            #region jeu d'essais pour la liste de toutes les actions réelles
            lesActionsReelles = new List<ActionReelle>();
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "AAPL",
                    NomAction = "Apple",
                    ValeurAction = 200
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "MSFT",
                    NomAction = "Microsoft",
                    ValeurAction = 14
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "TWTR",
                    NomAction = "Twitter",
                    ValeurAction = 40
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "IBM",
                    NomAction = "International Business Machines",
                    ValeurAction = 140
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "FB",
                    NomAction = "Facebook",
                    ValeurAction = 180
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "AXA",
                    NomAction = "Axa assurances",
                    ValeurAction = 25
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "SAP",
                    NomAction = "SAP SE",
                    ValeurAction = 120
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "INTC",
                    NomAction = "Intel Corporation",
                    ValeurAction = 50
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "VMW",
                    NomAction = "VMware",
                    ValeurAction = 145
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "TXN",
                    NomAction = "Texas Instrument Incorporated",
                    ValeurAction = 130
                }
            );
            #endregion
            lvTraders.ItemsSource = dico.Keys;
        }
        private void LvTraders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvTraders.ItemsSource = dico.Keys;
            if (lvTraders.SelectedItem != null)
            {
                lvActionAchetee.ItemsSource = null;
                lvActionAchetee.ItemsSource = dico[lvTraders.SelectedItem.ToString()];
            }
            //affichage du montant du portefeuille
            double montant = 0;
            foreach (ActionAchetee a in dico[lvTraders.SelectedItem.ToString()])
            {
                montant += a.Quantite * a.PrixAchat;
            }
            txtMontantP.Text = montant.ToString();
        }

        private void LvActionAchetee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvActionReelle.SelectedItem != null)
            {

            }
        }

        private void LvActionReelle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void BtnAchat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Vendre_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
