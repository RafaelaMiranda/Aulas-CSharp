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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aula_01
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class Controles : Window
	{
		public Controles()
		{
			InitializeComponent();
		}

		private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
		{

			Label.Content = TextBox.Text;
			Label1.Content = TextBox.GetLineLength(0).ToString();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			TextBox.Clear();
		}
	}
}

