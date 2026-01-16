using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Substitutie_monoalfabetica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void BtnCriptare_Click(object sender, RoutedEventArgs e)
        {
            TxtResult.Text = Substitutie.Encrypt(TxtInput.Text);
        }

        private void BtnDecriptare_Click(object sender, RoutedEventArgs e)
        {
            TxtResult.Text = Substitutie.Decrypt(TxtInput.Text);
        }

        private void BtnAnaliza_Click(object sender, RoutedEventArgs e)
        {
            TxtResult.Text = Substitutie.AnalizaFrecventa(TxtInput.Text);
        }
    }
}