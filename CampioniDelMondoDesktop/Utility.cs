using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CampioniDelMondo
{
    class Utility
    {
        /// <summary>
        /// Verifica la presenza di un nuovo aggiornamento del software
        /// </summary>
        /// <returns>True se nuova versione disponibile</returns>
        public static bool VerificaAggiornamento()
        {
            WebRequest wr = WebRequest.Create(new Uri("http://basoftware.altervista.org/backup/Version/CampioniDelMondoVersion.txt"));
            WebResponse ws = wr.GetResponse();
            StreamReader sr = new StreamReader(ws.GetResponseStream());

            string current_version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string new_version = sr.ReadToEnd();

            if (!current_version.Contains(new_version))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Apre una pagina web con il browser predefinito del sistema
        /// </summary>
        /// <param name="url">Url del sito da aprire</param>
        public static void LanciaSito(string url)
        {
            System.Diagnostics.Process.Start(url);
        }

        /// <summary>
        /// Converte un immagine Bitmap (es. immagini da file risorse) a immagine per Image.Source
        /// </summary>
        /// <param name="bitmap">Immagine da convertire</param>
        /// <returns>Ritorna immagine da impostare</returns>
        public static BitmapImage ToBitmapImage(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        /// <summary>
        /// Crea un colore da assegnare a proprietà colore (es. Backgroud)
        /// </summary>
        /// <param name="color">Colore da cui creare il pennello</param>
        /// <returns>Pennello del colore desiderato</returns>
        public static System.Windows.Media.Brush CreateBrush(string color)
        {
            var converter = new BrushConverter();

            try
            {
                return (System.Windows.Media.Brush)converter.ConvertFrom(color);
            }
            catch
            {
                return null;
            }
        }
    }
}
