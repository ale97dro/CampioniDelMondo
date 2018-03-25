using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CampioniDelMondo
{
    /// <summary>
    /// Logica di interazione per Informazioni.xaml
    /// </summary>
    public partial class Informazioni : Window
    {
        public Informazioni()
        {
            InitializeComponent();
        }

        private void go_siteClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Documents.Hyperlink chiamante = (System.Windows.Documents.Hyperlink)sender;

            if (chiamante.Name == "sitoHyp")
                Utility.LanciaSito("http://basoftware.altervista.org/");
            else
                Utility.LanciaSito("http://basoftware.altervista.org/campioni-del-mondo/");
        }

        private void aggiornamentosBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Utility.VerificaAggiornamento())
                {
                    Properties.Settings.Default.Esito = "1";
                    new FinestraEsito().ShowDialog();
                }
                else
                {
                    Properties.Settings.Default.Esito = "2";
                    new FinestraEsito().ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("Errore connessione internet");
            }
        }
    }
}
