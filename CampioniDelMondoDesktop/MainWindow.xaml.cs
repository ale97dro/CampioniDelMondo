using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CampioniDelMondo
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (object x in grid.Children)
            {
                if (x.GetType() == typeof(Button))
                    ((Button)x).Click += Cannavaro;
            }

            
            informazioniBtn.Click -= Cannavaro;
            informazioniBtn.Click += Informazioni;

            try
            {
                if (Utility.VerificaAggiornamento())
                {
                    Properties.Settings.Default.Esito = "1";
                    new FinestraEsito().ShowDialog();
                }
            }
            catch
            {

            }
        }

        private void Cannavaro(object sender, EventArgs e)
        {
            SoundPlayer player = null;
            Button x = sender as Button;

            try //se è la prima volta che passo di qui
            {
                player.Stop();
            }
            catch
            {

            }

            switch (x.Content.ToString())
            {
                case "Cannavaro, Cannavaro!":
                    player = new SoundPlayer(RisorseAudio.CannavaroAudio);
                    break;
                case "Francesco Totti!":
                    player = new SoundPlayer(RisorseAudio.FrancescoTotti);
                    break;
                case "Inzaghi, Inzaghi, Super Pippo Inzaghi!":
                    player = new SoundPlayer(RisorseAudio.InzaghiInzaghi);
                    break;
                case "Dentro Del Piero!":
                    player = new SoundPlayer(RisorseAudio.DentroDelPiero);
                    break;
                case "Andiamo a Berlino!":
                    player = new SoundPlayer(RisorseAudio.AndiamoABerlino);
                    break;
                case "Goooool! Materazzi!":
                    player = new SoundPlayer(RisorseAudio.GolMaterazzi);
                    break;
                case "Siamo Campioni del Mondo!":
                    player = new SoundPlayer(RisorseAudio.CampioniDelMondo);
                    break;
                case "Alzala alta Capitano!":
                    player = new SoundPlayer(RisorseAudio.AlzalaAlta);
                    break;
            }
            player.Play();
        }

        private void Informazioni(object sender, EventArgs e)
        {
            new Informazioni().ShowDialog();
        }
    }
}
