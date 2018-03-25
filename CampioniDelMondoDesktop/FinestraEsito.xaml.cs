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
    /// Logica di interazione per FinestraEsito.xaml
    /// </summary>
    public partial class FinestraEsito : Window
    {
        public FinestraEsito()
        {
            InitializeComponent();

            switch (Properties.Settings.Default.Esito)
            {
                case "1":
                    update_grid2.Visibility = Visibility.Visible;
                    window.Width = 266;
                    window.Height = 183;
                    update_grid2.Background = Utility.CreateBrush("#FF2CC4FD");
                    update_grid2.Background.Opacity = 0.75;
                    button_updateGrid.Background = Utility.CreateBrush("#37c940");
                    img_updateImg.Source = Utility.ToBitmapImage(Immagini.Pollice_Verde);
                    window.Title = "Aggiornamento disponibile!";
                    text_updateTxt.Text = "Aggiornamento disponibile!";
                    scaricare_updateBtn.Content = "Scarica";
                    ignora_updateBtn.Content = "Ignora";
                    break;
                case "2":
                    no_updateGrid.Visibility = Visibility.Visible;
                    no_updateGrid.Background = Utility.CreateBrush("#FF2CC4FD");
                    no_updateGrid.Background.Opacity = 0.75;
                    window.Width = 266;
                    window.Height = 183;
                    button_no_updateGrid.Background = Utility.CreateBrush("#37c940");
                    img_update_okImg.Source = Utility.ToBitmapImage(Immagini.Pollice_Verde);
                    window.Title = "Ultima versione";
                    text_no_updateTxt.Text = "Disponi già dell'ultima versione!";
                    break;
            }
        }

        private void scaricare_updateBtn_Click(object sender, RoutedEventArgs e)
        {
            Utility.LanciaSito("http://basoftware.altervista.org/campioni-del-mondo/");
            this.Close();
        }

        private void ignora_updateBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void chiudi_updateBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
