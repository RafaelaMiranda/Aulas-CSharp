using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Aula_02
{
    /// <summary>
    /// Interaction logic for Datas.xaml
    /// </summary>
    public partial class Datas : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer counter = new DispatcherTimer();
        public Datas()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += timer_Tick;
            timer.Start();

            counter.Interval = TimeSpan.FromMilliseconds(50);
            counter.Tick += counter_Tick;
            counter.Start();
            }

        int i;

        void counter_Tick(object sender, EventArgs e)
        {
            i++;
            count.Content = "Contagem: " + i;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            DataHoraAtual.Content = DateTime.Now.ToLongTimeString();
        }

        private void Calendario_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Dia.Content = "Dia: " + Calendario.SelectedDate.Value.Day.ToString();
            Mes.Content = "Mês: " + Calendario.SelectedDate.Value.Month.ToString() + " - " + Calendario.SelectedDate.Value.Date.ToString(" MMMM ");

            Ano.Content = "Ano: " + Calendario.SelectedDate.Value.Year.ToString();

            DiaSemana.Content = Calendario.SelectedDate.Value.Date.ToString("dddd");
            DataLonga.Content = Calendario.SelectedDate.Value.ToLongDateString();

            DateTimeUniversal.Content = Calendario.SelectedDate.Value.ToUniversalTime();

            //EXIBE DATAS FORMATADAS PARA OUTRAS CULTURAS
            String[] cultureNames = {"pt-BR", "en-US", "en-GB", "fr-FR", "de-DE", "ru-RU"};
            CultureDate.Content = "";
            foreach (var cultureName in cultureNames)
            {
                var culture = new CultureInfo(cultureName);
                CultureDate.Content += string.Format("{0}: {1}\n", cultureName, Calendario.SelectedDate.Value.ToString(culture));
            }
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            stop.IsEnabled = false;
            start.IsEnabled = true;
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            stop.IsEnabled = true;
            start.IsEnabled = false;
        }
    }
}
