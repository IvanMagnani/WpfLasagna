using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Magnani.Ivan._5I.WpfLasagna
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        async private void fnLasagna(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();
                btnLasagna.Background = Brushes.DarkRed;
                List<Lasagna> lasagne = JsonConvert.DeserializeObject<List<Lasagna>>(await client.GetStringAsync("https://flr.azurewebsites.net/api/lasagna"));
                btnLasagna.Background = Brushes.Lime;
                lswLasagna.ItemsSource = lasagne;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                btnLasagna.Background = Brushes.Lime;
            }
        }

        public class Lasagna
        {
            public string nome { get; set; }
            public string peso { get; set; }
            public string urlImmagine { get; set; }
        }

        private void LswLasagna_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            btnLasagna.Background = Brushes.LimeGreen; //Ho provato a cambiare il colore del bottone quando si entra, ma non ci sono riuscito
        }
    }
}
