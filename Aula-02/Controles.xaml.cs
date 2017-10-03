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

namespace Aula_02
{
	/// <summary>
	/// Interaction logic for Controles.xaml
	/// </summary>
	public partial class Controles : Window
	{
		public Controles()
		{
			InitializeComponent();
		}



		private void button_Click(object sender, RoutedEventArgs e)
		{
			Resultado.Content = Entrada.Text;
		}

		private void Entrada_TextChanged(object sender, TextChangedEventArgs e)
		{
			Resultado.Content = Entrada.Text;
		}

		private void Azul_Checked(object sender, RoutedEventArgs e)
		{
			Resultado.Foreground = Brushes.Blue;
			Vermelho.IsChecked = false;
			Verde.IsChecked = false;
		}

		private void Vermelho_Checked(object sender, RoutedEventArgs e)
		{
			Resultado.Foreground = Brushes.Red;
			Verde.IsChecked = false;
			Vermelho.IsChecked = false;
		}

		private void Verde_Checked(object sender, RoutedEventArgs e)
		{
			Resultado.Foreground = Brushes.Green;
			Verde.IsChecked = false;
			Vermelho.IsChecked = false;
		}

		private void Palmeiras_Checked(object sender, RoutedEventArgs e)
		{
			Resultado.Content = Palmeiras.Name;
			Resultado.Foreground = Palmeiras.Foreground;
		}

		private void SaoPaulo_Checked(object sender, RoutedEventArgs e)
		{
			Resultado.Content = SaoPaulo.Name;
			Resultado.Foreground = SaoPaulo.Foreground;
		}

		private void Corinthians_Checked(object sender, RoutedEventArgs e)
		{
			Resultado.Content = Corinthians.Name;
			Resultado.Foreground = Corinthians.Foreground;
		}

		private void Paises_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ComboBoxItem item = (ComboBoxItem)Paises.SelectedItem;
			Resultado.Content = item.Content;
			Resultado.Foreground = item.Foreground;
		}

		private void checkBox_Checked(object sender, RoutedEventArgs e)
		{
			MessageBoxResult resposta = MessageBox.Show("O arquivo já existe, deseja regravar?", "REGRAVAR", MessageBoxButton.YesNoCancel);
			if (resposta == MessageBoxResult.Cancel)
			{
				Resultado.Content = "Cancelou";
			}
			else if (resposta == MessageBoxResult.Yes)
			{
				Resultado.Content = "Sim";
			}
			else if (resposta == MessageBoxResult.No)
			{
				Resultado.Content = "Não";
			}
		}

		private void button_Click_1(object sender, RoutedEventArgs e)
		{
			{
				this.Close();
			}
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (MessageBox.Show("Deseja relmente sair?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
			{
				
			} else
			{
				e.Cancel = true;
			}
		}

		
	}
}
