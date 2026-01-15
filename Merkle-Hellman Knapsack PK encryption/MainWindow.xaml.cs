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

namespace Merkle_Hellman_Knapsack_PK_encryption
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MerkleHellman mh = new MerkleHellman();

        private async void MerkleClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string rezultat = await mh.EncryptAsync(InputMerkle.Text);
                OutputMerkle.Text = rezultat;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}